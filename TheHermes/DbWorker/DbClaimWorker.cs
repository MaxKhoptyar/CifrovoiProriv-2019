using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Microsoft.AspNet.Identity;
using TheHermesEntities;
using System.Security.Cryptography;
using System.Text;
using Extentions;
using TheHermesEntities.Common;

namespace DbWorker
{
    public class DbClaimWorker
    {
        public static List<CommonType> GetClaimTypes()
        {
            var f = Enum.GetValues(typeof(ClaimType));
            var resultList = new List<CommonType>();
            foreach (var e in f)
            {
                resultList.Add(new CommonType() { Id = (int)e, Name = e.DescriptionAttr() });
            }
            return resultList;
        }

        public static CreateClaimResult CreateClaim(Claim claim)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var userInfo = context.UserInfo.FirstOrDefault(o => o.UserGuid == claim.UserGuid);
                if (userInfo != null)
                {
                    claim.OrganisationGuid = userInfo.OrganisationGuid;
                    var dbClaim = context.Claim.FirstOrDefault(
                            c => c.TypeId == claim.TypeId &&
                                c.OrganisationGuid == claim.OrganisationGuid && c.StatusId != 6);

                    if (dbClaim != null)
                    {
                        if (dbClaim.UserGuid == claim.UserGuid)
                        {
                            return CreateClaimResult.DublicateCreate;
                        }
                        else
                        {
                            var claimUserCollaboration = context.ClaimUserCollaboration.FirstOrDefault(c => c.UserGuid == claim.UserGuid);
                            if (claimUserCollaboration != null)
                            {
                                return CreateClaimResult.DublicateMerge;
                            }
                            else
                            {
                                claimUserCollaboration = new ClaimUserCollaboration();
                                claimUserCollaboration.UserGuid = claim.UserGuid;
                                claimUserCollaboration.AccompanyingMessage = claim.AccompanyingMessage;
                                claimUserCollaboration.ClaimId = dbClaim.Id;
                                context.ClaimUserCollaboration.Add(claimUserCollaboration);
                                context.SaveChanges();
                                return CreateClaimResult.Merge;
                            }
                        }
                    }
                    else
                    {
                        claim.StatusId = 1;
                        claim.DateTimeUpdate = DateTime.Now;
                        context.Claim.Add(claim);
                        context.SaveChanges();

                        DbNotififcationWorker.AddCreateClaimNotificationUser(claim, context);
                        DbNotififcationWorker.AddCreateClaimNotificationOrganisation(claim, context);
                        return CreateClaimResult.Success;
                    }
                }
                return CreateClaimResult.NeedAddInfo;
            }
        }

        public static List<ClaimInfo> GetClaimForAdmin()
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var claimInfo = new List<ClaimInfo>();
                var claims = context.Claim.Where(c => c.StatusId != 5 && c.StatusId != 6).ToList();
                foreach (var e in claims)
                {
                    var ci = new ClaimInfo();
                    ci.StatusId = (ClaimLifeStatus)e.StatusId;
                    ci.TypeId = (ClaimType)e.TypeId;
                    ci.ClaimId = e.Id;
                    ci.DateTimeUpdate = e.DateTimeUpdate;
                    claimInfo.Add(ci);
                }
                return claimInfo;
            }
        }

        public static ClaimInfo GetClaimForWork(int claimId)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var claim = context.Claim.FirstOrDefault(c => c.Id == claimId);
                if (claim != null)
                {
                    var ci = new ClaimInfo();
                    ci.StatusId = (ClaimLifeStatus)claim.StatusId;
                    ci.TypeId = (ClaimType)claim.TypeId;
                    ci.ClaimId = claim.Id;
                    ci.DateTimeUpdate = claim.DateTimeUpdate;
                    ci.Message = claim.AccompanyingMessage;

                    var organisation = context.OrganisationInfo.FirstOrDefault(o => o.OrganisationGuid == claim.OrganisationGuid);
                    if (organisation != null)
                    {
                        ci.OrganisationName = organisation.Name;
                    }
                    return ci;
                }
                return null;
            }
        }

        public static void OpenRatingClaim(int claimId)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var claim = context.Claim.FirstOrDefault(c => c.Id == claimId);
                if (claim != null)
                {
                    claim.StatusId = (int)ClaimLifeStatus.Evaluation;
                    claim.DateTimeUpdate = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        public static void CloseRatingClaim(int claimId)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var claim = context.Claim.FirstOrDefault(c => c.Id == claimId);
                if (claim != null)
                {
                    claim.StatusId = (int)ClaimLifeStatus.Сompletion;
                    claim.DateTimeUpdate = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        public static Dictionary<int, ClaimInfo> GetClaims(List<Notification> notification)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var claimIds = notification.Select(n => n.ClaimId);
                var claims = context.Claim.Where(c => claimIds.Contains(c.Id)).ToList();
                var d = new Dictionary<int, ClaimInfo>();
                foreach (var e in claims)
                {
                    var ci = new ClaimInfo();
                    ci.StatusId = (ClaimLifeStatus)e.StatusId;
                    ci.TypeId = (ClaimType)e.TypeId;
                    ci.ClaimId = e.Id;
                    ci.DateTimeUpdate = e.DateTimeUpdate;
                    d[e.Id] = ci;
                }
                return d;
            }
        }

        public static ClaimInfo GetClaim(int claimId)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var claim = context.Claim.FirstOrDefault(c => c.Id == claimId);
                if (claim != null)
                {
                    var ci = new ClaimInfo();
                    ci.StatusId = (ClaimLifeStatus)claim.StatusId;
                    ci.TypeId = (ClaimType)claim.TypeId;
                    ci.ClaimId = claim.Id;
                    ci.DateTimeUpdate = claim.DateTimeUpdate;
                    ci.Message = claim.AccompanyingMessage;
                    return ci;
                }
                return null;
            }
        }

        public static CreateClaimResult CollaborateClaim(User user, int claimId, string accompanyingMessage)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var colaborateClaim = context.ClaimUserCollaboration.FirstOrDefault(c => c.UserGuid == user.Guid && c.ClaimId == claimId);
                if (colaborateClaim != null)
                {
                    return CreateClaimResult.DublicateMerge;
                }
                else
                {
                    colaborateClaim = new ClaimUserCollaboration();
                    colaborateClaim.AccompanyingMessage = accompanyingMessage;
                    colaborateClaim.ClaimId = claimId;
                    colaborateClaim.UserGuid = user.Guid;
                    context.ClaimUserCollaboration.Add(colaborateClaim);
                    context.SaveChanges();

                    return CreateClaimResult.Success;
                }
            }
        }

        public static List<ClaimInfo> GetMarkedClaimsByUser(User user)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var collaborationClaims = context.ClaimUserCollaboration.Where(c => c.UserGuid == user.Guid).ToList();
                var listIdClaims = collaborationClaims.Select(c => c.ClaimId);

                var list = context.Claim.Where(x => x.UserGuid == user.Guid || listIdClaims.Contains(x.Id)).ToList();
                var resultList = new List<ClaimInfo>();
                foreach (var e in list)
                {
                    var ci = new ClaimInfo();
                    ci.StatusId = (ClaimLifeStatus)e.StatusId;
                    ci.TypeId = (ClaimType)e.TypeId;
                    ci.ClaimId = e.Id;
                    ci.DateTimeUpdate = e.DateTimeUpdate;
                    ci.Message = e.AccompanyingMessage;
                    resultList.Add(ci);
                }
                return resultList;
            }
        }

        public static List<ClaimInfo> GetMarkedClaimsByOrganisation(User user)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var list = context.Claim.Where(x => x.OrganisationGuid == user.Guid).ToList();
                var resultList = new List<ClaimInfo>();
                foreach (var e in list)
                {
                    var ci = new ClaimInfo();
                    ci.StatusId = (ClaimLifeStatus)e.StatusId;
                    ci.TypeId = (ClaimType)e.TypeId;
                    ci.ClaimId = e.Id;
                    ci.DateTimeUpdate = e.DateTimeUpdate;
                    ci.Message = e.AccompanyingMessage;
                    resultList.Add(ci);
                }
                return resultList;
            }
        }

        public static List<CommonType> GetClaimRatings()
        {
            var f = Enum.GetValues(typeof(RatingType));
            var resultList = new List<CommonType>();
            foreach (var e in f)
            {
                resultList.Add(new CommonType() { Id = (int)e, Name = e.DescriptionAttr() });
            }
            return resultList;
        }

        public static CreateRatingResult CreateRating(User user, int claimId, int ratingId, string message)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var rating = context.Rating.FirstOrDefault(r => r.ClaimId == claimId && r.UserGuid == user.Guid);
                if (rating == null)
                {
                    var r = new Rating();
                    r.ClaimId = claimId;
                    r.UserGuid = user.Guid;
                    r.RatingId = ratingId;
                    r.Message = message;

                    context.Rating.Add(r);
                    context.SaveChanges();
                    return CreateRatingResult.Success;
                }
                else
                {
                    return CreateRatingResult.Dublicate;
                }
            }
        }

        public static void CreateStatisticRating(OrganisationInfo newDbOrganisation, TheHermesEntities.TheHermesEntities context)
        {
            var sr = 0.05 * newDbOrganisation.LawerStatistic + 0.1 * newDbOrganisation.ManagementArea + 0.05 * newDbOrganisation.InformationResourses
                + 0.1 * newDbOrganisation.Tariffs + 0.05 * newDbOrganisation.Profitability + 0.05 * newDbOrganisation.Staff;
            sr += 4;
            context.StatisticRating.Add(new StatisticRating()
            {
                OrganisationGuid = newDbOrganisation.OrganisationGuid,
                Rating = (float)sr
            });
        }

        public static List<StatisticRating> GetStatistic()
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var r = context.StatisticRating.ToList();
                return r;
            }
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNet.Identity;
using TheHermesEntities;
using System.Security.Cryptography;
using System.Text;
using TheHermesEntities.Common;

namespace DbWorker
{
    public class DbNotififcationWorker
    {
        public static void AddCreateClaimNotificationUser(Claim claim)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                AddCreateClaimNotificationUser(claim,context);
            }
        }
        public static void AddCreateClaimNotificationUser(Claim claim, TheHermesEntities.TheHermesEntities context)
        {
            var users = context.UserInfo.Where(u => u.OrganisationGuid == claim.OrganisationGuid && u.UserGuid != claim.UserGuid).ToList();
            var listNotification = new List<Notification>();
            var date = DateTime.Now;
            foreach (var u in users)
            {
                var n = new Notification();
                n.UserGuid = u.UserGuid;
                n.Date = date;
                n.ClaimId = claim.Id;
                n.NotificationType = (int) NotificationType.NotificationAddVoice;
                n.IsConfirm = false;
                listNotification.Add(n);
            }
            context.Notification.AddRange(listNotification);
            context.SaveChanges();
        }
        public static void AddCreateClaimNotificationOrganisation(Claim claim)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                AddCreateClaimNotificationOrganisation(claim, context);
            }
        }
        public static void AddCreateClaimNotificationOrganisation(Claim claim, TheHermesEntities.TheHermesEntities context)
        {
            var organisation = context.OrganisationInfo.First(u => u.OrganisationGuid == claim.OrganisationGuid);

            var n = new Notification();
            n.UserGuid = organisation.OrganisationGuid;
            n.ClaimId = claim.Id;
            n.Date = DateTime.Now;
            n.NotificationType = (int) NotificationType.NotificationRequestClaim;
            n.IsConfirm = false;
            context.Notification.Add(n);
            context.SaveChanges();
        }

        public static int GetNotificationCount(User user)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var notificationCount = context.Notification.Count(n => n.UserGuid == user.Guid && !n.IsConfirm);
                return notificationCount;
            }
        }

        public static List<Notification> GetNotification(User user)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var notification = context.Notification.Where(n => n.UserGuid == user.Guid && !n.IsConfirm).ToList();
                foreach (var e in notification)
                {
                    //context.Notification.Remove(e);
                }
                context.SaveChanges();
                return notification;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheHermesEntities;
using TheHermesEntities.Common;

namespace TheHermes.Models
{
    public class FormForCreateClaimModel
    {
        public List<CommonType> ListClaimType { get; set; }
    }
    public class CreateClaimModel
    {
        public int SelectedClaimType { get; set; }
        public string AccompanyingMessage { get; set; }
    }

    public class CollaborateClaimModel
    {
        public int ClaimId { get; set; }
        public string AccompanyingMessage { get; set; }
    }

    public class AdministrationClaimModel
    {
        public List<ClaimInfo> ClaimInfo { get; set; }
    }

    public class ClaimForWorkModel
    {
        public ClaimInfo ClaimInfo { get; set; }
    }

    public class CollaborateClaimInfoModel
    {
        public ClaimInfo ClaimInfo { get; set; }

    }

    public class MarkedClaimsUserModel
    {
        public List<ClaimInfo> ClaimInfo { get; set; }
    }
    public class MarkedClaimsOrganisationModel
    {
        public List<ClaimInfo> ClaimInfo { get; set; }
    }
    public class RatingClaimModel
    {
        public int ClaimId { get; set; }
        public int Rating { get; set; }
        public string Message { get; set; }

    }
    public class RatingClaimFormModel
    {
        public ClaimInfo ClaimInfo { get; set; }
        public List<CommonType> Rating { get; set; }

    }

    public class StatisticModel
    {
        public List<StatisticRating> Statistic { get; set; }
    }
}
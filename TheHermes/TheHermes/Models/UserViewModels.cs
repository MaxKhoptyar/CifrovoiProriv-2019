using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheHermesEntities;

namespace TheHermes.Models
{
    public class UserInfoModel
    {
        public int ChildrenCount { get; set; }
        public int Age { get; set; }
        public List<OrganisationInfo> ListOrganisation { get; set; }
        public Guid SelectedOrganisation { get; set; }
    }
}
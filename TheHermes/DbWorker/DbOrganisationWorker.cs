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
    public class DbOrganisationWorker
    {
        public static List<OrganisationInfo> GetAllOrganisation()
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var list = context.OrganisationInfo.ToList();
                return list;
            }
        }

        public static CreateOrganisationResult CreateOrganisation(OrganisationInfo organisation)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var dbOrganisation = context.OrganisationInfo.FirstOrDefault(o => o.Name == organisation.Name);
                if (dbOrganisation == null)
                {
                    var newDbOrganisation = new OrganisationInfo();
                    newDbOrganisation.OrganisationGuid = Guid.NewGuid();
                    newDbOrganisation.Name = organisation.Name;
                    newDbOrganisation.Inn = organisation.Inn;
                    newDbOrganisation.InformationResourses = organisation.InformationResourses;
                    newDbOrganisation.LawerStatistic = organisation.LawerStatistic;
                    newDbOrganisation.ManagementArea = organisation.ManagementArea;
                    newDbOrganisation.Profitability = organisation.Profitability;
                    newDbOrganisation.Staff = organisation.Staff;
                    newDbOrganisation.Tariffs = organisation.Tariffs;

                    context.OrganisationInfo.Add(newDbOrganisation);

                    DbAccountWorker.CreateAccount(organisation.Name, organisation.Name, (int)RoleType.Organisation);
                    DbClaimWorker.CreateStatisticRating(newDbOrganisation,context);
                    context.SaveChanges();
                    return CreateOrganisationResult.Success;
                }
                return CreateOrganisationResult.ErrorDublicate;
            }
        }

        public static void AddStartData()
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                if (context.OrganisationInfo.Count() < 3)
                {
                    CreateOrganisation(new OrganisationInfo() { Name = "Test1", Inn = 1, Tariffs = 7, Staff = 4, Profitability = 7, InformationResourses = 2, LawerStatistic = 5, ManagementArea = 4 });
                    CreateOrganisation(new OrganisationInfo() { Name = "ТестоваяКомпания1", Inn = 5, Tariffs = 4, Staff = 1, Profitability = 5, InformationResourses = 2, LawerStatistic = 5, ManagementArea = 4 });
                    CreateOrganisation(new OrganisationInfo() { Name = "Не тестовая компания", Inn = 1, Tariffs = 8, Staff = 2, Profitability = 7, InformationResourses = 2, LawerStatistic = 5, ManagementArea = 4 });
                    CreateOrganisation(new OrganisationInfo() { Name = "Тестовая компания2", Inn = 2, Tariffs = 3, Staff = 4, Profitability = 4, InformationResourses = 3, LawerStatistic = 2, ManagementArea = 1 });
                }
            }
        }
    }
}
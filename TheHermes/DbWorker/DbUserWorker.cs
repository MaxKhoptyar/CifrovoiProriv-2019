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
    public class DbUserWorker
    {
        public static UserInfo GetUserInfo(Guid userGuid)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var info = context.UserInfo.FirstOrDefault(u => u.UserGuid == userGuid);
                if (info != null)
                {
                    return info;
                }
                return null;
            }
        }
        public static CreateUserInfoResult CreateUserInfo(UserInfo userInfo)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var info = context.UserInfo.FirstOrDefault(u => u.UserGuid == userInfo.UserGuid);
                if (info == null)
                {
                    var dbInfo = new UserInfo();
                    dbInfo.Age = userInfo.Age;
                    dbInfo.ChildrenCount = userInfo.ChildrenCount;
                    dbInfo.OrganisationGuid = userInfo.OrganisationGuid;
                    dbInfo.UserGuid = userInfo.UserGuid;
                    context.UserInfo.Add(dbInfo);
                    context.SaveChanges();
                    return CreateUserInfoResult.Success;
                }
                return CreateUserInfoResult.Success;
            }
        }
        public static UpdateUserInfoResult UpdateUserInfo(UserInfo userInfo)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var info = context.UserInfo.FirstOrDefault(u => u.UserGuid == userInfo.UserGuid);
                if (info == null)
                {
                    CreateUserInfo(userInfo);

                }
                else
                {
                    info.Age = userInfo.Age;
                    info.ChildrenCount = userInfo.ChildrenCount;
                    info.OrganisationGuid = userInfo.OrganisationGuid;
                }
                context.SaveChanges();
                return UpdateUserInfoResult.Success;
            }
        }
    }
}
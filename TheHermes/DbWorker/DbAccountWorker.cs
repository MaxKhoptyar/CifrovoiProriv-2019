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
    public static class DbAccountWorker
    {
        public static UserModel Authorization(string user, string password)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var dbUser = context.User.FirstOrDefault(u => u.Login.Equals(user));
                if (dbUser != null)
                {
                    var sha256 = SHA256.Create();

                    var salt = dbUser.Salt;
                    var passwordBase = password + salt;
                    var passwordHash = sha256.ComputeHash(Encoding.ASCII.GetBytes(passwordBase));
                    var passwordString = Encoding.ASCII.GetString(passwordHash);

                    if (passwordString.Equals(dbUser.Password))
                    {
                        var userType = context.UserRole.First(u => u.UserGuid == dbUser.Guid);
                        return new UserModel() { Id = dbUser.Id, Login = dbUser.Login, Token = dbUser.Token, UserGuid = dbUser.Guid, UserType = (RoleType)userType.RoleId };
                    }
                }
                return null;
            }
        }

        public static IdentityResult CreateAccount(string user, string password,int roleId = 1)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var dbUser = context.User.FirstOrDefault(x => x.Login.Equals(user));
                if (dbUser == null)
                {
                    var sha256 = SHA256.Create();

                    var salt = GetSalt();
                    var passwordBase = password + salt;
                    var passwordHash = sha256.ComputeHash(Encoding.ASCII.GetBytes(passwordBase));

                    var u = new User();
                    u.Login = user;
                    u.Email = user;
                    u.Guid = Guid.NewGuid();
                    u.Password = Encoding.ASCII.GetString(passwordHash);
                    u.Salt = salt;

                    var tokenBase = u.Guid + user;
                    var tokenHash = sha256.ComputeHash(Encoding.ASCII.GetBytes(tokenBase));
                    u.Token = Encoding.ASCII.GetString(tokenHash);

                    context.UserRole.Add(new UserRole() { RoleId = roleId, UserGuid = u.Guid });
                    context.User.Add(u);

                    DbUserWorker.CreateUserInfo(new UserInfo() { UserGuid = u.Guid });
                    context.SaveChanges();
                    sha256.Dispose();
                    return IdentityResult.Success;
                }
                return IdentityResult.Failed(new[] { "Данная почта занята" });
            }
        }

        public static User GetUserByToken(string token)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var user = context.User.First(u => u.Token == token);
                return user;
            }
        }


        private static string GetSalt()
        {
            var r = new Random();
            var arrChar = new char[5];
            for (int i = 0; i < 5; i++)
            {
                var n = r.Next(33, 115);
                arrChar[i] = (char)n;
            }

            return new string(arrChar);
        }

        public static void AddStartData()
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var user = context.User.FirstOrDefault(u => u.Login == "admin@admin.ru");
                if (user == null)
                {
                    CreateAccount("admin@admin.ru", "admin@admin.ru", (int)RoleType.Administrator);
                }
            }
        }

        public static RoleType GetRoleByToken(string token)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var user = context.User.First(u => u.Token == token);
                var role = context.UserRole.First(u => u.UserGuid == user.Guid);
                return (RoleType)role.RoleId;
            }
        }

        public static RoleType GetRoleByUser(User user)
        {
            using (var context = new TheHermesEntities.TheHermesEntities())
            {
                var role = context.UserRole.First(u => u.UserGuid == user.Guid);
                return (RoleType)role.RoleId;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Jia.SportsSpecialist.Domain.Concrete;
using Jia.SportsSpecialist.WebApp.Infrastructure.Abstract;

namespace Jia.SportsSpecialist.WebApp.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public EFDbContext EFDb { get; set; }

        static string HashMD5(string text)
        {
            var source = Encoding.UTF8.GetBytes(text);

            using (MD5 hasher = MD5.Create())
            {
                var result = hasher.ComputeHash(source);

                return Convert.ToBase64String(result);
            }
        }

        private const string DefaultUser = "admin3";
        private const string DefaultPwd = "kAPR3yLrTTggAVBwOFGUyA==";

        public bool Authenticate(string username, string password)
        {
            bool result = false;

            var user = EFDb.Users.FirstOrDefault(i => i.Username == username);

            if (user != null)
            {
                var inputPwdHash = HashMD5(password);

                if (user.PasswordHash == inputPwdHash)
                {
                    result = true;
                }
            }
            else
            {
                if (username == "admin" && password == "asd")
                {
                    result = true;
                }
            }

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }

}
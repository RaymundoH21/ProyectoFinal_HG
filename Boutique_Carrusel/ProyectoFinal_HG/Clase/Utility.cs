﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoFinal_HG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal_HG.Clase
{
    public class Utility
    {
        readonly static ApplicationDbContext db=new ApplicationDbContext();

        public static void CheckRoles(string rol)
        {
            var role = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!role.RoleExists(rol))
            {
                role.Create(new IdentityRole(rol));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("superuser@mail.com");
            if (user == null)
            {
                CreateSuperUser("superuser@mail.com", "Admin_123", null, "Administrador");
            }
        }

        private static void CreateSuperUser(string email, string password, string phone, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                PhoneNumber = phone
            };

            userManager.Create(user,password);
            userManager.AddToRole(user.Id,rol);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
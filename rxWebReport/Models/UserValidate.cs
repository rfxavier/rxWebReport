using Microsoft.AspNet.Identity.EntityFramework;
using rxWebReport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace rxWebReport.Models
{
    public class UserValidate
    {
        //private ApplicationUserManager userManager;

        //This method is used to check the user credentials
        public static ApplicationUser Login(string username, string password)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = Task.Run(() => userManager.FindAsync(username, password)).Result;

            using (var ctx = new ApplicationDbContext())
            {
                user.GetLockCofres = ctx.Database.SqlQuery<GetLockCofre>(
                    @"SELECT ISNULL(c.id, 0) AS id, ISNULL(c.id_cofre, uc.id_cofre) AS id_cofre, ISNULL(c.nome, uc.id_cofre) AS nome, c.serie, c.tipo, c.marca, c.modelo, c.tamanho_malote, c.trackLastWriteTime, c.trackCreationTime, c.cod_loja FROM AspNetUserCofres uc LEFT OUTER JOIN cofre c ON uc.id_cofre = c.id_cofre WHERE uc.UserId = @p0", user.Id).ToList();
            }

            //var userWithCofres = userManager.Users.Include(u => u.GetLockCofres).FirstOrDefault(ul => ul.UserName == username);
            var userWithCofres = user;

            return userWithCofres;
        }
    }
}
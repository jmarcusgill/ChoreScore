﻿using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;

namespace ChoreScore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phonenumber { get; set; }
        public float CurrentPoints { get; set; }
        public bool isActive { get; set; }

        public virtual List<Chore> Chore { get; set; }
        public virtual List<Reward> Reward { get; set; }

        


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ChoreScore", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Chore> Chore { get; set; }
        public virtual DbSet<Reward> Reward { get; set; }


        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
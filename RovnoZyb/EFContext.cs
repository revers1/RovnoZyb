﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RovnoZyb.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RovnoZyb
{
    public class EFContext : IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        public DbSet<UserMoreInfo> userMoreInfos { get; set; }
        public DbSet<Anketa> anketa { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)//Zamena Foreign key 
        {
            builder.Entity<User>()
                .HasOne(u => u.UserMoreInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserMoreInfo>(ui => ui.id);
            base.OnModelCreating(builder);

               
        }
    }
}

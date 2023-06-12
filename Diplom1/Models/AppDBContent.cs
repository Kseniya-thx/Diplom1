using Diplom1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DbContext = System.Data.Entity.DbContext;

namespace Diplom1
{
    public class AppDBContent : DbContext
    {

        public AppDBContent() { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }


        public Microsoft.EntityFrameworkCore.DbSet<HeadsDepart> HeadsDeparts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Depart> Departs { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Person> Person { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Base> Base { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<PersonReg> Persons { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<PersonReg> Reg { get; set; }




    }
}

   
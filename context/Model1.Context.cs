﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Expense_Tracker.context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_Expense_TrackerEntities : DbContext
    {
        public DB_Expense_TrackerEntities()
            : base("name=DB_Expense_TrackerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<category> categories { get; set; }
        public DbSet<expense> expenses { get; set; }
       // public DbSet<totalexpense> totalexpenses { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<totallimit> totallimits { get; set; }
    }
}
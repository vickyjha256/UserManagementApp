﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EMPTYDBEntities : DbContext
    {
        public EMPTYDBEntities()
            : base("name=EMPTYDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<Cricketer> Cricketers { get; set; }
        public virtual DbSet<LINQTEST> LINQTESTs { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<state> states { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<personalInfo> personalInfoes { get; set; }
    
        public virtual int sp_GetUserDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetUserDetails");
        }
    
        public virtual ObjectResult<GetViewDetails_Result> GetViewDetails(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetViewDetails_Result>("GetViewDetails", userIdParameter);
        }
    }
}

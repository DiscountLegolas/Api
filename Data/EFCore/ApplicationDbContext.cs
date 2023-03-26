using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.EFCore.Classes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> ApplicationUsers  {get;set;}
        public DbSet<ApplicationRole> ApplicationRoles  {get;set;}
        public DbSet<Board> Boards  {get;set;}
        public DbSet<Card> Cards  {get;set;}
        public DbSet<CardList> CardLists  {get;set;}
        public DbSet<Comment> Comments  {get;set;}
        public DbSet<Detail> Details  {get;set;}
        public DbSet<Workplace> Workplaces  {get;set;}
        public DbSet<WorkplaceMember> WorkplaceMembers  {get;set;}
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<CardAssingment> CardAssingments { get; set; }

    }
}
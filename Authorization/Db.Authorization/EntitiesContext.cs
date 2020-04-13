using Db.Authorization.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



namespace Db.Authorization
{
    public class EntitiesContext : DbContext
    {

        /// <summary>
        /// Контекст доступа к БД модуля авторизации / Authorization Database module access context 
        /// </summary>
        /// <param name="options"></param>
        public EntitiesContext(DbContextOptions<EntitiesContext> options)
            : base(options: options)
        {
        }
        //public EntitiesContext() { }


        public DbSet<UserExtended> UsersExtended { get; set; }
        public DbSet<UserExtendedGroup> UserExtendedGroup { get; set; }
        public DbSet<RoleRight> RoleRights { get; set; }
        public DbSet<GroupRight> GroupRights { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var userGuid = Guid.NewGuid();
            //var roleGuid = Guid.NewGuid();
            var defaultRoleGuid = Guid.NewGuid();
            //var user1Guid = Guid.NewGuid();
            //var group1Guid = Guid.NewGuid();
            //var group2Guid = Guid.NewGuid();
            var defaultGroupGuid = Guid.NewGuid();

            var defaultRightGuid = Guid.NewGuid();
            var defaultGroupRightGuid = Guid.NewGuid();
            var defaultRoleRightGuid = Guid.NewGuid();
            //var right1RoleGuid = Guid.NewGuid();
            //var right2RoleGuid = Guid.NewGuid();
            //var right3RoleGuid = Guid.NewGuid();

            //var right1Group1Guid = Guid.NewGuid();
            //var right2Group1Guid = Guid.NewGuid();
            //var right3Group1Guid = Guid.NewGuid();
            var defaultRight = new Right
            {
                RightId = defaultRightGuid,
                Module = RightModule.None,
                Object = RightObject.None,
                Operator = RightOperator.None
            };

            var defaultRights = new List<Right>();
            defaultRights.Add(defaultRight);
            var groupRights = new List<GroupRight>
            {
                new GroupRight
                {
                    GroupRightId = defaultGroupGuid,
                    GroupId = defaultGroupGuid,
                    RightId = defaultRightGuid
                }
            };
            var roleRights = new List<RoleRight>
            {
                new RoleRight
                {
                    RoleRightId = defaultRoleRightGuid,
                    RoleId = defaultRoleGuid,
                    RightId = defaultRightGuid
                }
            };
            //           var groupКights = new List<GroupRight>
            //           {
            //                  new GroupRight
            //                   {
            //                       GroupId=group1Guid,
            //                       GroupRightId = right1Group1Guid,
            //                       Module = RightModule.Crm,
            //                       Object = RightObject.Payment,
            //                       Operator = RightOperator.Create
            //                   },
            //                   new GroupRight
            //                   {
            //                       GroupId=group1Guid,
            //                       GroupRightId = right2Group1Guid,
            //                       Module = RightModule.Mintos,
            //                       Object = RightObject.Loan,
            //                       Operator = RightOperator.Get
            //                   },
            //                   new GroupRight
            //                   {
            //                       GroupId=group1Guid,
            //                       GroupRightId = right3Group1Guid,
            //                       Module = RightModule.Crm,
            //                       Object = RightObject.Payment,
            //                       Operator = RightOperator.Get
            //                   }
            //           };

            //           var roleКights = new List<RoleRight>
            //           {
            //               new RoleRight
            //                   {
            //                       RoleId = roleGuid,
            //                       RoleRightId = right1RoleGuid,
            //                       Module = RightModule.Crm,
            //                       Object = RightObject.Payment,
            //                       Operator = RightOperator.Create
            //                   },
            //                   new RoleRight
            //                   {
            //                       RoleId = roleGuid,
            //                       RoleRightId = right2RoleGuid,
            //                       Module = RightModule.Mintos,
            //                       Object = RightObject.Loan,
            //                       Operator = RightOperator.Get
            //                   },
            //                   new RoleRight
            //                   {
            //                       RoleId = roleGuid,
            //                       RoleRightId = right3RoleGuid,
            //                       Module = RightModule.Crm,
            //                       Object = RightObject.Payment,
            //                       Operator = RightOperator.Get
            //                   }
            //           };
            var defaultRole = new Role
            {
                RoleId = defaultRoleGuid,
                RoleName = "DefaultRole"
            };
 //           var role = new Role
 //           {
 //               RoleId = roleGuid,
 //               RoleName = "NewRole",
 //               RoleRights = roleКights,
 //           };
 //           var user = new UserExtended
 //           {
 //               UserExtendedId = userGuid,
 //               FirstName = "Mickhail",
 //               LastName = "Koriaka",
 //               Login = "Miha",
 //               Password = "1234",
 //               Token = "",
 //               Role = role
 //           };
 //           var group = new Group
 //           {
 //               GroupId = group1Guid,
 //               GroupName = "NewGroup"
 ////             GroupRights = groupright
 //           };
            var defaultGroup = new Group
            {
                GroupId = defaultGroupGuid,
                GroupName = "DefaultGroup",
            };

 //           var UserExtendedGroup = new UserExtendedGroup
 //           {
 //               UserExtendedId =  userGuid,             
 //               GroupId = group1Guid,
 //           };

            modelBuilder
                .Entity<UserExtendedGroup>()
                .HasKey(x => new { x.UserExtendedId, x.GroupId });
            modelBuilder
                .Entity<UserExtendedGroup>()
                .HasOne(ug => ug.User)
                .WithMany(g => g.UserExtendedGroups)
                .HasForeignKey(ug => ug.UserExtendedId);
            modelBuilder
                .Entity<UserExtendedGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserExtendedGroups)
                .HasForeignKey(ug => ug.GroupId);
            modelBuilder
                .Entity<RoleRight>()
                .HasOne(r => r.Role)
                .WithMany(rr => rr.RoleRights)
                .HasForeignKey(r=>r.RoleId);
            modelBuilder
                .Entity<GroupRight>()
                .HasOne(g => g.Group)
                .WithMany(r => r.GroupRights)
                .HasForeignKey(r=>r.GroupId);

            modelBuilder.Entity<UserExtended>()
                .HasOne(rl => rl.Role)
                .WithMany(ue => ue.User);


            modelBuilder
                .Entity<Right>()
                .Property(m=>m.Module)
                .HasConversion<int>();
            modelBuilder
                .Entity<Right>()
                .Property(o => o.Object)
                .HasConversion<int>();
            modelBuilder
                .Entity<Right>()
                .Property(o => o.Operator)
                .HasConversion<int>();
            
            //modelBuilder
            //    .Entity<UserExtended>()
            //    .HasData(user);
           
            //modelBuilder
            //    .Entity<Group>()
            //    .HasData(group);
            modelBuilder
                .Entity<Group>()
                .HasData(defaultGroup);
            modelBuilder
                .Entity<Right>()
                .HasData(defaultRights);
            modelBuilder
                .Entity<GroupRight>()
                .HasData(groupRights);
            modelBuilder
                .Entity<RoleRight>()
                .HasData(roleRights);
            modelBuilder
                .Entity<Role>()
                .HasData(defaultRole);
            //modelBuilder
            //    .Entity<UserExtendedGroup>()
            //    .HasData(UserExtendedGroup);
            
//            modelBuilder.Entity<RoleRight>()
//                .HasData(roleКights);
            //modelBuilder
            //    .Entity<GroupRight>()
            //    .HasData(groupКights);
            
            base.OnModelCreating(modelBuilder);

        }

    }
}

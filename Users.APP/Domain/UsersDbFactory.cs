using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Globalization;

namespace Users.APP.Domain{

    public class UsersDbFactory : IDesignTimeDbContextFactory<UsersDb>{

        const string CONNECTIONSTRING = "data source=UsersDB.db";

        public UsersDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersDb>();
            optionsBuilder.UseSqlite(CONNECTIONSTRING);
            
            return new UsersDb(optionsBuilder.Options);
        }

        public void SeedDb(){
            var db = CreateDbContext(null);

            var userRoles = db.UserRoles.ToList();
            db.UserRoles.RemoveRange(userRoles);

            var roles = db.Roles.ToList();
            db.Roles.RemoveRange(roles);

            var users = db.Users.ToList();
            db.Users.RemoveRange(users);

            var statuses = db.Statuses.ToList();
            db.Statutes.RemoveRange(statuses);

            db.Database.ExecuteSqlRaw("UPDATE SQLITE_SEQUENCE " + "SET SEQ=0 WHERE NAME='UserRoles'");
            db.Database.ExecuteSqlRaw("UPDATE SQLITE_SEQUENCE " + "SET SEQ=0 WHERE NAME='Roles'");
            db.Database.ExecuteSqlRaw("UPDATE SQLITE_SEQUENCE " + "SET SEQ=0 WHERE NAME='Users'");
            db.Database.ExecuteSqlRaw("UPDATE SQLITE_SEQUENCE " + "SET SEQ=0 WHERE NAME='Statuses'");


            var role = new Role() { name  = "Admin"};
            db.Roles.Add(role);
            role = new Role { name = "User"};
            db.Roles.Add(role);

            db.SaveChanges();
            db.Statuses.Add(new Status{
                Title = "Active",
                Users = new List<User>{
                    new User{
                        UserName = "admin",
                        Password = "admin",
                        RegistrationDate = new DateTime(2026, 7, 16, 20, 57, 45),
                        UserRoles = new List<UserRole>{
                            new UserRole{ RoleId = db.Roles.Single(r=> r.Name=="Admin").Id}
                        }
                    },
                    new User
                    {
                        UserName = "user",
                        Password = "user",
                        RegistrationDate = DateTime.Parse(
                        "07/16/2026 20:58:13", new CultureInfo("en-US")),
                        UserRoles = new List<UserRole>
                        {
                            new UserRole { RoleId = db.Roles.Single(r => r.Name == "User").Id }
                        }
                    }
                }
            });
            db.Statuses.Add(new Status { Title = "Inactive"});
            db.SaveChanges();
        }
    }
}
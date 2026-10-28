using CORE.Domain;

namespace Users.APP.Domain
{
    public class UserRole : Record{

        public int UserId{get;set;}

        public User User {get;set;}

        public int RoleId{get;set;}

        public Role Role {get;set;}


        
    }




}
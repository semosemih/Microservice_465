using CORE.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.APP.Domain
{
    public class Role : Record{

        [Required, StringLength(25)]
        public string Name {get; set;}

        public List<UserRole> UserRoles {get; set;} = new();
    }





}
using CORE.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.APP.Domain{

    public class User : Record{

        [Required, StringLength(30)]
        public string UserName{get ; set;}
        [Required, StringLength(15)]
        public string Password{get; set;}
        
    }
}
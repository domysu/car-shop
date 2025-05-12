using System.ComponentModel.DataAnnotations;

namespace AutomobiliuPardavimoPrograma.Models
{
    public class UserEditModel
    {
        public string? Name {get;set;}
        [Required]
        public string Password {get;set;}
        public string CurrentPassword {get;set;}
        public string? Email {get;set;}

    }
}
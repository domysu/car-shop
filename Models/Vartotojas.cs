using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomobiliuPardavimoPrograma.Models
{
    public class Vartotojas
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Vardas { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string ElPastas { get; set; }

        public string SlaptazodisHash { get; set; }
        
        public string Salt { get; set; }
        
        [NotMapped]
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string RawPassword { get; set; }
        
        public bool YraAdmin { get; set; }
        
        public ICollection<UserPostLikes> UserPostLikes { get; set; }
    }
}
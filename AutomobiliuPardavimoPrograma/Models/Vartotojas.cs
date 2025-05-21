using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomobiliuPardavimoPrograma.Models
{
public class Vartotojas
{

    public int Id { get; set; }
    [Required]
    public string Vardas { get; set; }
    [Required]
    public string ElPastas { get; set; }

    public string SlaptazodisHash { get; set; }
    
    [NotMapped][Required]
    public string RawPassword{get; set;}
    public bool YraAdmin { get; set; }
    public ICollection<UserPostLikes> UserPostLikes { get; set; }
        
    }
}
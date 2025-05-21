using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AutomobiliuPardavimoPrograma.Models
{
public class RegisterModel
{
    [Required]
    public string Vardas{ get; set; }
    [Required]
    public string ElPastas { get; set; }
    
    [Required]
    public string RawPassword { get; set; }
}
}
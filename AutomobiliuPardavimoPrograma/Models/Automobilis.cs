using System.ComponentModel.DataAnnotations;
namespace AutomobiliuPardavimoPrograma.Models
{
public class Automobilis
{

    public int Id {get;set;}

  [Required(ErrorMessage = "Markė privaloma")]
  public string? Marke { get; set; }

  [Required(ErrorMessage = "Modelis privalomas")]
  public string? Modelis { get; set; }

  [Required(ErrorMessage = "Metai privalomi")]
  public int? Metai { get; set; }

  [Required(ErrorMessage = "Rida privaloma")]
  public int? Rida { get; set; }

  [Required(ErrorMessage = "Kaina privaloma")]
  public decimal Kaina { get; set; }

  [Required(ErrorMessage = "Pavarų dėžė privaloma")]
  public string PavaruDeze { get; set; }

  [Required(ErrorMessage = "Kuro tipas privalomas")]
  public string KuroTipas { get; set; }
    [Required(ErrorMessage = "Mašinos nuotrauka yra privaloma")]
  public List<string> Nuotraukos { get; set; } = new();
  [Required]
  public int CreatedById {get; set; }

  public string? Aprasymas {get;set;}
  public ICollection<UserPostLikes> UserPostLikes { get; set; }

}


}

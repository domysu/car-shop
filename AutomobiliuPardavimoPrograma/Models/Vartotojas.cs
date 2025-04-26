using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomobiliuPardavimoPrograma.Models
{
public class Vartotojas
{

    public int Id { get; set; }
 
    public string Vardas { get; set; }
    public string ElPastas { get; set; }

    public string SlaptazodisHash { get; set; }
    
    [NotMapped]

    public string RawPassword{get; set;}
    public bool YraAdmin { get; set; }


}
}
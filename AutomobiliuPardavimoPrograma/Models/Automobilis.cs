namespace AutomobiliuPardavimoPrograma.Models
{
 public class Automobilis
{
    public int Id { get; set; }
    public string Marke { get; set; }          // BMW, Audi...
    public string Modelis { get; set; }        // A6, X5...
    public int Metai { get; set; }             // 2015
    public int Rida { get; set; }              // km
    public decimal Kaina { get; set; }         // €
    public string PavaruDeze { get; set; }     // Automat / Mechanine
    public string KuroTipas { get; set; }      // Benzinas, Dyzelis...
    public string Nuotrauka { get; set; }      // URL į paveikslėlį
    public string Aprasymas {get;set;}
}

}

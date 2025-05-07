using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomobiliuPardavimoPrograma.Models
{
public class UserPostLikes
{

    public int Id { get; set; }
    public int UserId{get;set;}
    [ForeignKey(nameof(UserId))]
    public virtual Automobilis Automobilis {get;set;}
    public int PostId{get;set;}
    [ForeignKey(nameof(PostId))]
    public virtual Vartotojas Vartotojas {get;set;}
  


}
}
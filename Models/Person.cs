using System.ComponentModel.DataAnnotations;
namespace helloazure.Models
{
    public class Person {
        [Key]
        [Required]
        [Display(Name="id")]
        public string Id {get; set;}
    
        [Required]
        [Display(Name = "name")]
        public string Name {get; set;}
    
        [Display(Name = "address")]
        public string Address{get; set;}
    }
}
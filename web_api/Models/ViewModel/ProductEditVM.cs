using System.ComponentModel.DataAnnotations;

namespace web_api.Models;

public class ProductEditVM {
     [Required(ErrorMessage = "Name cannot be blank!")]
    [StringLength(50, ErrorMessage = "Name from 6 to 50 characters!",MinimumLength = 6)]
    public string Name { get; set;}
    [Required(ErrorMessage = "Price cannot be blank!")]
    public double Price { get; set;}
}
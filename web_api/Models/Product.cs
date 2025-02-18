namespace web_api.Models;

public class Product{
    public Guid Id { get; set;}
    public string Name { get; set;}
    public double Price {get;set;}
    public Product(){
        Id = Guid.NewGuid();
    }

}
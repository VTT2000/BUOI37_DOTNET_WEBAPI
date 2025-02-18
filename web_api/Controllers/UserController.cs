//api-controller-async
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;
//using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController :ControllerBase
    {
        public static List<Product> prodList = new List<Product>(){
            new Product(){Name = "Iphone 15", Price=1000},
            new Product(){Name = "Iphone 16", Price=2000},
            new Product(){Name = "Iphone 17", Price=3000},
        };
        public UserController()
        {
        }
        [HttpGet("GetAllUser")]
        public async Task<List<string>> GetAllUser()
        {
            return new List<string>(){"Khải","Nga","Khôi","Chương"};
        }
        [HttpGet("GetAllProduct")]
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return prodList;
        }

        [HttpPost("/AddProduct")]
        public async Task<IActionResult> AddProduct(Product model)
        {
            prodList.Add(model);
            return Ok("Successfully");
        }

        [HttpPut("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct([FromRoute]Guid id ,ProductEditVM model)
        {
            // Request.RouteValues["id"]
            Product? prodEdit = prodList.Find(pro => pro.Id == id);
            if(prodEdit == null){
                return NotFound("Không tìm thấy");
            }
            prodEdit.Name = model.Name;
            prodEdit.Price = model.Price;
            return Ok("Edit Ok");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]Guid id ){
            // Request.Form.Files["filename"]
            Product? prodDelete = prodList.Find(prod => prod.Id == id);
            if(prodDelete == null){
                return NotFound("Id không tồn tại!");
            }
            prodList.Remove(prodDelete);
            return Ok("Xoá ok!");

        }
        

        
        
        
       
    }
}
//MVC : Model, View, Controller
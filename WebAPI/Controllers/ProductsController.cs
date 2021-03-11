using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()                   // kendi ressponse DEĞERİMİ set etmek için
        {
            var result = _productService.GetAll();      // data'yı al ve result adlı değişkene aktar
            if (result.Success)                         // işlem sonucu true ise
            {
                return Ok(result);                      // Ok statü kodu (200) ve ek olarak result'ın tüm parametrelerini dön
            }
            return BadRequest(result);                  // result.Success == true değilse 400 BadRequest statü kodu ve result için tüm parametreleri döndür.
        }                                               // NOT: BadResquest satırında direkt return ile başlamayıp else açınca da çalıştı.

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


    }
}

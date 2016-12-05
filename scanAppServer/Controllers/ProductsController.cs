using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScanAppServer.Interfaces;
using ScanAppServer.Model;

namespace ScanAppServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController:Controller {
        private readonly IProductRepository Repository;

        public ProductsController(IProductRepository repository){
            if(repository == null){
                throw new ArgumentNullException("repository");
            }
            this.Repository = repository;
        }

        [HttpGet]
        public List<Product> Get() {
            return Repository.List();
        }

        
        [HttpGet("{productCode}")]
        public Product GetByProductCode(string productCode){
            return Repository.SearchByProductCode(productCode);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Product product){
            Repository.Add(product);
            return StatusCode(200);
        }

        [HttpPut]
        public ActionResult Put(Product product) {
            Repository.Update(product);
            return StatusCode(200);
        }

        [HttpDelete]
        public ActionResult Delete(Product product) {
            Repository.Delete(product);
            return StatusCode(200);
        }
    }
}
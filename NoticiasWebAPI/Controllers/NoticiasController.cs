﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoticiasWebAPI.Models;
using NoticiasWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoticiasWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NoticiasController : Controller
    {
        private readonly NoticiaServices noticiaServices;

        public NoticiasController(NoticiaServices noticiaSrv)
        {
            noticiaServices = noticiaSrv;
        }

        // GET: api/values
        [HttpGet]
        [Route("VerNoticias")]
        public IActionResult GetNoticias()
        {
            List<Models.Noticia> result = noticiaServices.VerListadoNoticias();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("Agregar")]
        [HttpPost]
        public IActionResult AddNoticia([FromBody] Noticia newNoticia)
        {
            if (noticiaServices.Agregar(newNoticia))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
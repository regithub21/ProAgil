﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ProAgilContext _context;

        public ValuesController(ProAgilContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results =  await _context.Eventos.ToListAsync();

                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }                  

            

            //Utilizado antes de implementar o construtor ValuesController e a conexão com BD.
            // return new Evento[] { 
            //     new Evento() {
            //         EventoId = 1,
            //         Tema = "Angular e .NET Core",
            //         Local = "Belo Horizonte",
            //         Lote = "1º Lote",
            //         QtdPessoas = 250,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")                
            //     },
            //     new Evento() {
            //         EventoId = 1,
            //         Tema = "Angular e Suas Novidades",
            //         Local = "São Paulo",
            //         Lote = "1º Lote",
            //         QtdPessoas = 350,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")                
            //     }};
                
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

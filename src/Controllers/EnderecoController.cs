using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiClientRest.Service;

namespace WebApiClientRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        Repo repo = new Repo();
        
        [HttpGet("{cep}")]
        public async Task<Endereco> GetCEP(string cep)
        {
            var result = await repo.ProcessRepositories(cep);
            return result;
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace AtividadeH1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        // Ação para calcular o IMC
        [HttpPost("calcular-imc")]
        public IActionResult CalcularImc([FromBody] PessoaDto pessoa)
        {
            if (pessoa == null || pessoa.Peso <= 0 || pessoa.Altura <= 0)
            {
                return BadRequest("Dados inválidos.");
            }

            var imc = pessoa.Peso / (pessoa.Altura * pessoa.Altura);
            return Ok(new { IMC = imc });
        }

        // Ação para consultar a tabela IMC
        [HttpGet("consulta-tabela-imc")]
        public IActionResult ConsultaTabelaImc([FromQuery] double imc)
        {
            var descricao = GetDescricaoImc(imc);
            return Ok(new { IMC = imc, Descricao = descricao });
        }

        private string GetDescricaoImc(double imc)
        {
            if (imc < 18.5)
                return "Abaixo do peso";
            else if (imc >= 18.5 && imc < 24.9)
                return "Peso normal";
            else if (imc >= 25 && imc < 29.9)
                return "Sobrepeso";
            else
                return "Obesidade";
        }
    }

    public class PessoaDto
    {
        public string Nome { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}

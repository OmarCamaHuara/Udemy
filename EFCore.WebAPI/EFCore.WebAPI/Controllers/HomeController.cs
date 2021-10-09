using Microsoft.AspNetCore.Mvc;
using EFCore.Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repo;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly HeroiContext _context;
        public HomeController(HeroiContext context)
        {
            _context = context;
        }

        // get => mostrando o Heroi
        [HttpGet]
        public ActionResult Get()
        {
            var listHeroi = _context.Herois.ToList();

            //var listHeroi = (from heroi in _context.Herois
            //               select heroi).ToList();

            return Ok(listHeroi);
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {

            var listHeroi = _context.Herois
                .Where(h => h.Nome.Contains(nome))
                .ToList();

            //var listHeroi = (from heroi in _context.Herois
            //                 where heroi.Nome.Contains(nome)
            //                select heroi).ToList();

            return Ok(listHeroi);
        }

        // Get api/value/5
        [HttpGet("{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            var heroi = new Heroi { Nome = nameHero };
            _context.Herois.Add(heroi);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América"},
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
            );
            _context.SaveChanges();

            return Ok();
        }

        //DELETE api/values/5

        [HttpDelete]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                                .Where(x => x.Id == id)
                                .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}

using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        private static List<Categorias> listaCategorias = new List<Categorias> {
            new Categorias {
                CategoriasId = 1,
                Nombre = "Hervidor",
                Descripcion = "Electrodomesticos"
            }
        };

        [HttpGet]
        [Route("GetAllCategorias")]
        public ActionResult<List<Categorias>> GetAllCategorias()
        {
            return Ok(_context.tblCategorias.ToList());
        }

        [HttpGet]
        [Route("GetCategoriasById")]
        public ActionResult GetCategoriasById(int CategoriaId)
        {
            var Cate = _context.tblCategorias.FirstOrDefault(c => c.CategoriasId == CategoriaId);
            //var Dpto2 = _context.Departamentos.Where(d => d.Id == Id).FirstOrDefault();

            if (Cate == null) return BadRequest();
            return Ok(Cate);
        }



        [HttpPost]
        [Route("AddCategoria")]
        public ActionResult AddCategoria(CategoriasDTO C)
        {
            Categorias Cate = new Categorias()
            {
                CategoriasId = C.CategoriasId,
                Nombre = C.Nombre,
                Descripcion = C.Descripcion
            };
            _context.Add(Cate);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("UptCategorias")]
        public ActionResult UptDepartment(CategoriasDTO C)
        {
            var Cate = _context.tblCategorias.FirstOrDefault(cate => cate.CategoriasId == C.CategoriasId);
            if (Cate == null) BadRequest();
            else
            {
                Cate.CategoriasId = C.CategoriasId;
                Cate.Nombre = C.Nombre;
                Cate.Descripcion = C.Descripcion;
            }
            _context.Update(Cate);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        [Route("DelCategorias")]
        public ActionResult DelCategorias(CategoriasDTO C)
        {
            var Cate = _context
                .tblCategorias.FirstOrDefault(cate => cate.CategoriasId == C.CategoriasId);
            if (Cate == null) return BadRequest();
            else
            {
                _context.Remove(Cate);
                _context.SaveChanges();
                return Ok();
            }
        }










    }

}

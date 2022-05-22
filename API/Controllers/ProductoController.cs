using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Free")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllProductos")]
        [AllowAnonymous]
        public ActionResult<List<Productos>> GetAllProductos()
        {
            var Productos = _context.tblProductos.ToList();
            return Ok(Productos);
        }

        [HttpPost]
        [Route("AddProductos")]
        public ActionResult AddEmpleado(ProductosDTO P)
        {
            Productos Prod = new Productos()
            {
                ProductosId = P.ProductosId,
                Nombre = P.Nombre,
                Descripcion = P.Descripcion,
                Precio = P.Precio,
                Stock = P.Stock,
                Imagen = P.Imagen,
                CategoriasId = P.CategoriasId
            };
            _context.tblProductos.Add(Prod);    
            _context.SaveChanges();
            return Ok();
        }



        [HttpPut]
        [Route("UptProducto")]
        public ActionResult UptProducto(ProductosDTO ProdDTO)
        {
            var Prod = _context.tblProductos.FirstOrDefault(p => p.ProductosId == ProdDTO.ProductosId);
            if (Prod == null) return BadRequest();

            Prod.ProductosId = ProdDTO.ProductosId;
            Prod.Nombre = ProdDTO.Nombre;
            Prod.Descripcion = ProdDTO.Descripcion;
            Prod.Precio = ProdDTO.Precio;
            Prod.Stock = ProdDTO.Stock;

            _context.tblProductos.Update(Prod);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("DelProducto")]
        public ActionResult DelProducto(int ProductosId)
        {
            var Prod = _context.tblProductos.FirstOrDefault(p => p.ProductosId == ProductosId);
            if (Prod == null) return BadRequest();
            _context.Remove(Prod);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet]
        [Route("GetProductosByCat")]
        public async Task<ActionResult> GetProductosByCat(int ProductosId)
        {

            var productos = await _context.tblProductos.Where(p => p.CategoriasId == ProductosId).ToListAsync();
            return Ok(productos);

        }

       // [HttpGet]
       // [Route("GetEmpleadosByDeptName")]
        //public async Task<ActionResult> GetEmpleadosByDept(string Departamento)
        //{
          //  var empleados2 = await _context.Empleados.Where(e => e.Departamento.Descripcion == Departamento).ToListAsync();
            //var empleados = await _context.Empleados.Where(e => e.DepartamentoId == id).ToListAsync();
            //return Ok(empleados2);

    }
}

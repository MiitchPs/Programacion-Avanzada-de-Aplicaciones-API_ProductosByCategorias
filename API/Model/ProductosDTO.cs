﻿namespace API.Model
{
    public class ProductosDTO
    {
        public int ProductosId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public int CategoriasId { get; set; }
    }
}

using System;

namespace WebAPI.Model
{
    public class Ciudad: Entity<int>
    {
        public string ciudadCodigo { get; set; }
        public string ciudadNombre { get; set; }
    }
}

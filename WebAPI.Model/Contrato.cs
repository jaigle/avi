using System;

namespace WebAPI.Model
{
    public class Contrato: Entity<int>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

    }
}

using System;

namespace WebAPI.Model
{
    public class Comuna: Entity<int>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}

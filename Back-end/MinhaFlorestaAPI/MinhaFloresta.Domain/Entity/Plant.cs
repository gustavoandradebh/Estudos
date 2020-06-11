using System;

namespace MinhaFloresta.Domain.Entity
{
    public class Plant: BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int WaterDaysInterval { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public string Description { get; set; }
    }
}

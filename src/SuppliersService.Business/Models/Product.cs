using System;

namespace SuppliersService.Business.Models
{
    public class Product : Entity
    {
        public Guid SupplierId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }

        /* EF Relations */
        public Supplier Supplier { get; set; }
    }
}
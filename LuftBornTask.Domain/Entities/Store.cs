using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; } 
        public string Location { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

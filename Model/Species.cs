using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Species
    {
        string Name { get; set; }
        string Id { get; set; }
        string Description { get; set; }

        public Species(string name, string description)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
            Description = description;
        }
    }
}

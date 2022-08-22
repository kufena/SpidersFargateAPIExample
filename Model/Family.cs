using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Family
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public List<Genus> Genus { get; set; }

        public Family(string name)
        {
            Name = name;
            Genus = new List<Genus>();
            Id = Guid.NewGuid().ToString();
        }
    }
}

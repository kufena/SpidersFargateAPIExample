using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadSpiders.ModelTaxonomy
{
    internal class Genus
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public List<Species> Species { get; set; }

        public Genus(string name)
        {
            Name = name;
            Species = new List<Species>();
            Id = Guid.NewGuid().ToString();
        }
    }
}

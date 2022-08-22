using System;
using System.Collections.Generic;

namespace UploadSpiders.TaxonomyModel
{
    public partial class Species
    {
        public string Id { get; set; } = null!;
        public string? SpeciesName { get; set; }
        public string GenusId { get; set; } = null!;
    }
}

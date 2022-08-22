using System;
using System.Collections.Generic;

namespace UploadSpiders.TaxonomyModel
{
    public partial class Genu
    {
        public string Id { get; set; } = null!;
        public string? GenusName { get; set; }
        public string FamilyId { get; set; } = null!;
    }
}

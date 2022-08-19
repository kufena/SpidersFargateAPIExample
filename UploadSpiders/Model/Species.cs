using System;
using System.Collections.Generic;

namespace UploadSpiders.Model
{
    public partial class Species
    {
        public string? GenusName { get; set; }
        public string? SpeciesName { get; set; }
        public string? Family { get; set; }
        public string Id { get; set; } = null!;

        public string ToJson()
        {
            return $"{{\"Id\":\"{Id}\",\"GenusName\":\"{GenusName},\"SpeciesName\":\"{SpeciesName}\",\"Family\":\"{Family}\"}}";
        }
    }
}

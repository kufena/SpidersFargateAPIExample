using System;
using System.Collections.Generic;

namespace UploadSpiders.Model
{
    public partial class Family
    {
        public string? Name { get; set; }
        public string Id { get; set; }

        public string ToJson()
        {
            return $"{{\"Id\"=\"{Id}\",\"Name\"=\"{Name}\"}}";
        }
    }
}

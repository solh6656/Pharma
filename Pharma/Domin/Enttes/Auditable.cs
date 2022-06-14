using System;

namespace Pharma.Domin.Enttes
{
    public class Auditable
    {
        public long Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}

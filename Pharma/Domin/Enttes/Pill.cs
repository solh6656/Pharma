namespace Pharma.Domin.Enttes
{
    public class Pill : Auditable
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }
    }
}

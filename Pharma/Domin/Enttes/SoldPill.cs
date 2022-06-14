namespace Pharma.Domin.Enttes
{
    public class SoldPill : Auditable
    {
        public string Name { get; set; }
        public long SellerId { get; set; }
        public int Count { get; set; }
    }
}

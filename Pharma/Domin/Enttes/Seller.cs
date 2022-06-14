using Pharma.Service.DTOs;
using Pharma.Service.Extansions;
using Pharma.Service.Interfaces;
using Pharma.Service.Services;

namespace Pharma.Domin.Enttes
{
    public class Seller : Auditable
    {
        public string FullName { get; set; }
        public long Selery { get; set; }
        public bool SellPills(string pill, int count)
        {
            bool chack = pill.Check();

            IPillService service = new PillService();
            if (chack)
            {
                PillView pillView = service.Get(pill);

                if (pillView.Count >= count)
                {
                    ISoldPillService sold = new SoldPillService();

                    pillView.Count -= count;
                    service.Update(pillView.Name, pillView);

                    sold.Create(pillView, Id);

                    return true;
                }
            }

            return false;
        }

    }
}

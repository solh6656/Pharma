using Pharma.Service.Extansions;
using Pharma.Service.Interfaces;

namespace Pharma.Domin.Enttes
{
    public class Admin : Auditable
    {
        public string FullName { get; set; }
        public string SpacePassword { get; set; }

        public bool AddSeller(string fullName, long selery)
        {

            ISellerService service = new SellerService();

            service.Create(new Seller()
            {
                FullName = fullName,
                Selery = selery
            }.Mapper());

            return true;
        }


    }
}

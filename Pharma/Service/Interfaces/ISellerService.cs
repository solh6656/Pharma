using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using System.Collections.Generic;

namespace Pharma.Service.Interfaces
{
    public interface ISellerService
    {
        Seller Create(SellerView seller);

        SellerView Get(string fiullname);

        IEnumerable<SellerView> GetAll();

        Seller Update(string fullName, SellerView seller);

        bool Delete(string fullName);
    }
}

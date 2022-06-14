using Pharma.Data.IRepositories;
using Pharma.Data.Repositories;
using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using Pharma.Service.Extansions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharma.Service.Interfaces
{
    internal class SellerService : ISellerService
    {
        private readonly ISellerRepository sellerRepository;
        public SellerService()
        {
            sellerRepository = new SellerRepository();
        }

        public Seller Create(SellerView sellerDto)
            => sellerRepository.Create(sellerDto.Mapper());


        public SellerView Get(string fullname)
            => GetAll().FirstOrDefault(p => p.FullName == fullname);

        public SellerView Get(long selery)
           => GetAll().FirstOrDefault(p => p.Selery == selery);


        public IEnumerable<SellerView> GetAll()
            => sellerRepository.GetAll().Select(p => p.Mapper());


        public Seller Update(string fullname, SellerView sellerview)
        {
            var seller = sellerRepository.GetAll().FirstOrDefault(p => p.FullName == fullname);

            Seller pudatedSeller = sellerview.Mapper();
            pudatedSeller.Id = seller.Id;
            pudatedSeller.CreatedTime = seller.CreatedTime;
            pudatedSeller.UpdatedTime = DateTime.Now;

            sellerRepository.Update(seller.Id, pudatedSeller);

            return seller;
        }


        public bool Delete(string name)
        {
            var seller = sellerRepository.GetAll().FirstOrDefault(p => p.FullName == name);

            return sellerRepository.Delete(seller.Id);
        }
    }
}

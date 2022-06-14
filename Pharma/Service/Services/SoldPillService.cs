using Pharma.Data.IRepositories;
using Pharma.Data.Repositories;
using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using Pharma.Service.Extansions;
using Pharma.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharma.Service.Services
{
    public class SoldPillService : ISoldPillService
    {

        private readonly ISoldPillRepository  soldPillRepository;
        public SoldPillService()
        {
            soldPillRepository = new SoldPillRepository();
        }

        public SoldPill Create(PillView soldpill, long id)
        {
            SoldPillView pill = new SoldPillView()
            {
                Name = soldpill.Name,
                Count = soldpill.Count,
                SellerId = id
            };

            return soldPillRepository.Create(pill.Mapper());

        }

        public SoldPillView Get(string name)
         => GetAll().FirstOrDefault(p => p.Name == name);
        public SoldPillView Get(long sId)
         => GetAll().FirstOrDefault(p => p.SellerId == sId);

        public IEnumerable<SoldPillView> GetAll()
           => soldPillRepository.GetAll().Select(p => p.Mapper());
    }
}

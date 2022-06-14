using Pharma.Data.IRepositories;
using Pharma.Data.Repositories;
using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using Pharma.Service.Extansions;
using Pharma.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharma.Service.Services
{
    public class PillService : IPillService
    {
        private readonly IPillRepository pillRepository;
        public PillService()
        {
            pillRepository = new PillRepository();
        }

        public Pill Create(PillView pillDto)
        {
            var pills = GetAll();
            bool check = pills.Check(pillDto.Name);

            if (!check)
            {
                var havePill = Get(pillDto.Name);

                havePill.Count += pillDto.Count;

                return Update(pillDto.Name, havePill);
            }

            return pillRepository.Create(pillDto.Mapper());

        }


        public PillView Get(string name)
            => GetAll().FirstOrDefault(p => p.Name == name);
        public PillView Get(long price)
            => GetAll().FirstOrDefault(p => p.Price == price);

        public PillView Get(int count)
            => GetAll().FirstOrDefault(p => p.Count == count);


        public IEnumerable<PillView> GetAll()
            => pillRepository.GetAll().Select(p => p.Mapper());


        public Pill Update(string name, PillView pillView)
        {
            var pill = pillRepository.GetAll().FirstOrDefault(p => p.Name == name);

            Pill pudatedPill = pillView.Mapper();
            pudatedPill.Id = pill.Id;
            pudatedPill.CreatedTime = pill.CreatedTime;
            pudatedPill.UpdatedTime = DateTime.Now;

            pillRepository.Update(pill.Id, pudatedPill);

            return pill;
        }


        public bool Delete(string name)
        {
            var pill = pillRepository.GetAll().FirstOrDefault(p => p.Name == name);

            return pillRepository.Delete(pill.Id);
        }
    }
}

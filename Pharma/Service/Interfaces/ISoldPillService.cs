using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using System.Collections.Generic;

namespace Pharma.Service.Interfaces
{
    public interface ISoldPillService
    {
        SoldPill Create(PillView soldpill, long id);

        SoldPillView Get(string name);

        IEnumerable<SoldPillView> GetAll();

    }
}

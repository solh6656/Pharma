using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using System.Collections.Generic;

namespace Pharma.Service.Interfaces
{
    public interface IPillService
    {
        Pill Create(PillView pill);

        PillView Get(string name);

        IEnumerable<PillView> GetAll();

        Pill Update(string name, PillView pill);

        bool Delete(string name);
    }
}

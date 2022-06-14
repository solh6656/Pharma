using Pharma.Service.DTOs;
using Pharma.Service.Interfaces;
using Pharma.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace Pharma.Service.Extansions
{
    public static class CheckerExtension
    {
        public static bool Check(this IEnumerable<PillView> source, string name)
          => source.FirstOrDefault(p => p.Name == name) is null;
        public static bool Check(this string pillName)
        {
            IPillService pillservice = new PillService();
            IEnumerable<PillView> pills = pillservice.GetAll();

            return pills.Any(p => p.Name == pillName);

        }


        public static bool Check(this IEnumerable<SellerView> source, string fullname)
          => source.FirstOrDefault(p => p.FullName == fullname) is null;
        public static bool Check(this IEnumerable<UserView> source, string usernam, string password)
          => source.FirstOrDefault(p => p.Username == usernam && p.Password == password.GetHashCode().ToString()) is null;



    }
}

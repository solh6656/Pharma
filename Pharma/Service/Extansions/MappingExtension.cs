using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;

namespace Pharma.Service.Extansions
{
    public static class MappingExtension
    {
        public static PillView Mapper(this Pill pill)
        {
            return new PillView()
            {
                Name = pill.Name,
                Count = pill.Count,
                Price = pill.Price
            };
        }
        public static Pill Mapper(this PillView pillView)
        {
            return new Pill()
            {
                Name = pillView.Name,
                Count = pillView.Count,
                Price = pillView.Price
            };
        }
        public static Seller Mapper(this SellerView sellerView)
        {
            return new Seller()
            {
                FullName = sellerView.FullName,
                Selery = sellerView.Selery
            };
        }
        public static SellerView Mapper(this Seller seller)
        {
            return new SellerView()
            {
                FullName = seller.FullName,
                Selery = seller.Selery
            };
        }
        public static SoldPillView Mapper(this SoldPill soldPill)
        {
            return new SoldPillView()
            {
                Name = soldPill.Name,
                Count = soldPill.Count,
                SellerId = soldPill.SellerId
            };
        }
        public static SoldPill Mapper(this SoldPillView soldPill)
        {
            return new SoldPill()
            {
                Name = soldPill.Name,
                Count = soldPill.Count,
                SellerId = soldPill.SellerId
            };
        }
        public static UserView Mapper(this User user)
        {
            return new UserView()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Phone = user.Phone
            };
        }

        public static User Mapper(this UserView user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Phone = user.Phone
            };
        }

    }
}

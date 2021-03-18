using GFT.OrderApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFT.OrderApp.Domain.DishAggregate
{
    public class DishType : ValueObject
    {
        public static List<DishType> Types = new List<DishType>
        {
            new DishType(1, nameof(Entree).ToLowerInvariant()),
            new DishType(2, nameof(Side).ToLowerInvariant()),
            new DishType(3, nameof(Drink).ToLowerInvariant()),
            new DishType(4, nameof(Dessert).ToLowerInvariant()),
            new DishType(5, nameof(Invalid).ToLowerInvariant())
        };

        public static DishType Entree = Types[0];
        public static DishType Side = Types[1];
        public static DishType Drink = Types[2];
        public static DishType Dessert = Types[3];
        public static DishType Invalid = Types[4];

        public short Code { get; private set; }
        public string Name { get; private set; }

        public static implicit operator DishType(short code) => Types[code - 1];
        public static implicit operator short(DishType timeOfDayVO) => Types.Single(x => x.Code == timeOfDayVO.Code);

        private DishType(short code, string name)
        {
            Code = GetCode(code);
            Name = name;
        }

        private short GetCode(short code)
        {
            if (code >= 5 || code < 0)
                return 5;
            else
                return code;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
}

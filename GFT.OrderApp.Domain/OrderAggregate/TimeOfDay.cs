using GFT.OrderApp.Domain.Base;
using System.Collections.Generic;

namespace GFT.OrderApp.Domain.OrderAggregate
{
    public class TimeOfDay : ValueObject
    {
        public static TimeOfDay Morning = new TimeOfDay(nameof(Morning).ToLowerInvariant());
        public static TimeOfDay Night = new TimeOfDay(nameof(Night).ToLowerInvariant());

        public string Name { get; private set; }

        public static implicit operator TimeOfDay(string name) => new TimeOfDay(name.ToLowerInvariant());
        public static implicit operator string(TimeOfDay timeOfDayVO) => timeOfDayVO.Name;

        private TimeOfDay() { }

        public TimeOfDay(string name)
        {
            TimeOfDayValidator.ThatMembers()
                .Compute(!string.IsNullOrEmpty(name), name, "You must enter time of day as “morning” or “night”", nameof(Name))
                .Guard();

            name = name.ToLowerInvariant();

            TimeOfDayValidator.ThatMembers()
                .ValidateName(name)
                .Guard();

            Name = name.ToLowerInvariant();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
}

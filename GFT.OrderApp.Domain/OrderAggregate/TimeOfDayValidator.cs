using GFT.OrderApp.Infrastructure.Validations;

namespace GFT.OrderApp.Domain.OrderAggregate
{
    public class TimeOfDayValidator : Validates
    {
        public static TimeOfDayValidator ThatMembers() => new TimeOfDayValidator();

        public Validates ValidateName(string name)
        {
            var success = nameof(TimeOfDay.Morning).ToLowerInvariant() == name || nameof(TimeOfDay.Night).ToLowerInvariant() == name;
            return Compute(success, name, "You must select a valid time of day", nameof(Order.Dishes));
        }
    }
}

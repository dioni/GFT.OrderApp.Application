using GFT.OrderApp.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GFT.OrderApp.Infrastructure.Validations
{
    public class Validates
    {
        protected readonly IList<ValidationResult> Validations;
        protected readonly IDictionary<string, object> Values;
        protected bool Error => Validations.Count > 0;
        protected bool Success => !Error;

        protected Validates()
        {
            Validations = new List<ValidationResult>();
            Values = new Dictionary<string, object>();
        }
        public Validates Compute(bool success, object value, string message, params string[] memberNames)
        {
            if (!success)
            {
                AddValidation(message, memberNames);
            }

            AddOrReplaceValue(value, memberNames);

            return this;
        }

        private void AddValidation(string message, params string[] memberNames)
        {
            Validations.Add(new ValidationResult(message, memberNames));
        }

        private void AddOrReplaceValue(object value, params string[] memberNames)
        {
            foreach (var memberName in memberNames)
            {
                Values.Remove(memberName);
                Values.Add(memberName, value);
            }
        }


        public static implicit operator bool(Validates validates)
        {
            return validates.Success;
        }

        public Validates Guard()
        {
            if (Error)
            {
                throw new GFTValidationException(Validations);
            }

            return this;
        }
    }
}

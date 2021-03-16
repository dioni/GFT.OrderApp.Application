using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GFT.OrderApp.Infrastructure.Exceptions
{
    public class GFTValidationException : Exception
    {
        public IList<ValidationResult> ValidationErrors
        {
            get;
        }

        public GFTValidationException(IList<ValidationResult> validationErrors)
        {
            ValidationErrors = validationErrors ?? throw new ArgumentNullException(nameof(validationErrors));
        }
    }
}

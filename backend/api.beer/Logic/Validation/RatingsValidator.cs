using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using FluentValidation;

namespace Logic.Validator
{
    public class RatingsValidator : AbstractValidator<Ratings>
    {
        public RatingsValidator()
        {
            //Rating is required
            RuleFor(r => r.Rating).NotEmpty().WithMessage("Please provide a rating value between 1 - 5");

            //Ensure rating is only betwen 1 - 5
            RuleFor(r => r.Rating).GreaterThanOrEqualTo(1);
            RuleFor(r => r.Rating).LessThanOrEqualTo(5);

        }
    }
}

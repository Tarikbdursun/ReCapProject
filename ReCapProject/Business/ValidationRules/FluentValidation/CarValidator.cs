using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.ModelId).NotEmpty();
            RuleFor(x => x.ModelYear).NotEmpty();
            RuleFor(x => x.ModelYear).GreaterThan(1960);
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.DailyPrice).GreaterThanOrEqualTo(200).When(x => x.ModelYear > 2010);
                //.WithMessage(ErrorMessage);
            RuleFor(x => x.Description).MaximumLength(31); //=>.Must(DescriptionMaxLenght);
        }

        private bool StartWithCarModelYear(string arg)
        {
            return arg.Length<=30;
        }
    }
}

using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.VehicleTypeId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

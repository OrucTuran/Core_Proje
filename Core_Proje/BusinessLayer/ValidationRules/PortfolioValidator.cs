using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Project name cannot be empty.");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Image field cannot be empty.");
            RuleFor(x => x.BigImageURL).NotEmpty().WithMessage("BigImage field cannot be empty.");
            RuleFor(x => x.ProjectURL).NotEmpty().WithMessage("ProjectImage field cannot be empty.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price field cannot be empty.");
            RuleFor(x => x.Completion).NotEmpty().WithMessage("Completion field cannot be empty.");
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform image field cannot be empty.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("The project name field must be at least 5 characters.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("The project name field must be a maximum of 100 characters.");
        }
    }
}

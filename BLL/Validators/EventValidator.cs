using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class EventValidator : AbstractValidator<EventModel>
    {
        public EventValidator()
        {
            RuleFor(p => p.Theme)
                .NotEmpty().Length(3, 20).WithMessage("{PropertyName} length error")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Incorrect theme");

            RuleFor(p => p.Description)
                .NotEmpty().Length(5, 200).WithMessage("{PropertyName} length error");

            RuleFor(p => p.Organizer)
                .NotEmpty().Length(3, 20).WithMessage("{PropertyName} length error")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Incorrect organizer");

            RuleFor(p => p.Place)
                .NotEmpty().Length(3, 30).WithMessage("{PropertyName} length error")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Incorrect palce");

            RuleFor(p => p.Start)
                .NotEmpty().GreaterThan(DateTime.Now).WithMessage("Incorreect time");
        }
    }
}

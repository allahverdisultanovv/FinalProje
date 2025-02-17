using ASUniversity.Application.DTOs.Subject;
using FluentValidation;

namespace ASUniversity.Application.Validators
{
    public class SubjectCreateDtoValidator : AbstractValidator<SubjectCreateDto>
    {
        public SubjectCreateDtoValidator()
        {

            RuleFor(s => s.Credits).NotEmpty().WithMessage("AnarMuallimWasHere");
            RuleFor(s => s.FacultyId).NotNull().WithMessage("Salaaaaaam");
            RuleFor(s => s.Name)
                   .MaximumLength(200).WithMessage("Maksimun uzunluq 200 simvol")
                   .NotEmpty().WithMessage("Fill in the gaps")
                   .Matches(@"^[A-Za-z\s]*$").WithMessage("Only can use this elements A-Z a-z and whitespace");

        }
    }
}

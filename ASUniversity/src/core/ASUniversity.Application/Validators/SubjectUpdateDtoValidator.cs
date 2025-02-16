using ASUniversity.Application.DTOs.Subject;
using FluentValidation;

namespace ASUniversity.Application.Validators
{
    public class SubjectUpdateDtoValidator : AbstractValidator<SubjectUpdateDto>
    {
        public SubjectUpdateDtoValidator()
        {
            RuleFor(s => s.Name)
                   .MaximumLength(200).WithMessage("Maksimun uzunluq 200 simvol")
                   .NotEmpty().WithMessage("Fill the gaps")
                   .Matches(@"^[A-Za-z\s]*$").WithMessage("Only can use this elements A-Z a-z and whitespace");
        }
    }
}

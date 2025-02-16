using ASUniversity.Application.DTOs.Faculty;
using FluentValidation;

namespace ASUniversity.Application.Validators
{
    public class FacultyUpdateDtoValidator : AbstractValidator<FacultyUpdateDto>
    {
        public FacultyUpdateDtoValidator()
        {
            RuleFor(f => f.Name)
                   .MaximumLength(200).WithMessage("Maksimun uzunluq 200 simvol")
                   .NotEmpty().WithMessage("Fill in the gaps")
                   .Matches(@"^[A-Za-z]*$").WithMessage("Only can use this elements A-Z a-z and whitespace");
        }
    }
}

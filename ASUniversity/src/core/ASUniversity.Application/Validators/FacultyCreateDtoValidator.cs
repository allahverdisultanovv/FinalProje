using ASUniversity.Application.DTOs.Faculty;
using FluentValidation;

namespace ASUniversity.Application.Validators
{
    public class FacultyCreateDtoValidator : AbstractValidator<FacultyCreateDto>
    {
        public FacultyCreateDtoValidator()
        {
            RuleFor(f => f.Name)
                   .MaximumLength(200).WithMessage("Maksimun uzunluq 200 simvol")
                   .NotEmpty().WithMessage("Fill the gaps")
                   .Matches(@"^[A-Za-z\s]*$").WithMessage("Only can use this elements A-Z a-z and whitespace");


        }
    }
}

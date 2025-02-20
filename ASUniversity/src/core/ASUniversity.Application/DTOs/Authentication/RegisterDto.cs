using ASUniversity.Application.DTOs.Faculty;
using ASUniversity.Application.DTOs.Group;
using ASUniversity.Application.DTOs.Specialization;
using ASUniversity.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASUniversity.Application.DTOs.Authentication
{
    public class RegisterDto
    {

        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(25)]
        public string SurName { get; set; }
        [Required]
        [MaxLength(7)]
        public string FIN { get; set; }

        public int FacultyId { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int? SpecializationId { get; set; }
        [Required]
        public int? AdmissionYear { get; set; }
        [Required]
        public Degree? Degree { get; set; }
        [Required]
        public Position? Position { get; set; }

        public IEnumerable<SelectListItem>? Positions { get; set; }
        public IEnumerable<SelectListItem>? Degrees { get; set; }
        public IEnumerable<GroupItemDto>? Groups { get; set; }
        public IEnumerable<FacultyItemDto>? Faculties { get; set; }
        public IEnumerable<SpecializationItemDto>? Specializations { get; set; }





    }
}

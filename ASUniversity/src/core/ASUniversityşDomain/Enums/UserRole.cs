using System.ComponentModel;

namespace ASUniversity.Domain.Enums
{
    public enum UserRole
    {
        [Description("Admin")]
        Admin,
        SuperAdmin,
        Teacher,
        Student
    }
}

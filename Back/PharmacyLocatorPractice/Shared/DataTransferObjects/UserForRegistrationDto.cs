using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        public string? Name { get; init; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string? PhoneNumber { get; init; }
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; init; }
        public string? PhotoUrl { get; init; }
        [Required(ErrorMessage = "Roles is required")]
        public ICollection<string>? Roles { get; init; }
    }
}

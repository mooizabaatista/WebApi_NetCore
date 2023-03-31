using System;
using System.ComponentModel.DataAnnotations;
using Manager.Core.Shared;
using Manager.Core.UserConstants;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = SharedConstants.FieldRequired)]
        [MinLength(UserConstants.NameMinLength, ErrorMessage = SharedConstants.FieldMinLength)]
        [MaxLength(UserConstants.NameMaxLength, ErrorMessage = SharedConstants.FieldMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = SharedConstants.FieldRequired)]
        [MinLength(UserConstants.EmailMinLength, ErrorMessage = SharedConstants.FieldMinLength)]
        [MaxLength(UserConstants.EmailMaxLength, ErrorMessage = SharedConstants.FieldMaxLength)]
        [RegularExpression(SharedConstants.RegexValidateEmail, ErrorMessage = SharedConstants.FieldNotValid)]
        public string Email { get; set; }

        [Required(ErrorMessage = SharedConstants.FieldRequired)]
        [MinLength(UserConstants.PasswordMinLength, ErrorMessage = SharedConstants.FieldMinLength)]
        [MaxLength(UserConstants.PasswordMaxLength, ErrorMessage = SharedConstants.FieldMaxLength)]
        public string Password { get; set; }
    }
}
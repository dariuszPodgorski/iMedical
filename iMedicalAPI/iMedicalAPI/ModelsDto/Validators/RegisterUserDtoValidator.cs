using FluentValidation;
using iMedicalAPI.Models.RegisterUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(iMedical_angContext dbContext)
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(6);
            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(x => x.Login)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.UserAccounts.Any(u => u.Login == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Loing", "Taki login już istnieje");
                    }
                });

            RuleFor(x => x.Pesel)
                .Custom((value, context) =>
                {
                    var PeselInUse = dbContext.UserAccounts.Any(u => u.Pesel == value);
                    if (PeselInUse)
                    {
                        context.AddFailure("Pesel", "Taki pesel jest już w bazie");
                    }
                });


        }
    }
}

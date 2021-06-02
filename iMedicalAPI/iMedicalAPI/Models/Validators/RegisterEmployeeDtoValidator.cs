using FluentValidation;
using iMedicalAPI.Models.RegisterUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI.Models.Validators
{
    public class RegisterEmployeeDtoValidator : AbstractValidator<RegisterEmployeeDto>
    {
        public RegisterEmployeeDtoValidator(iMedical_angContext dbContext)
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(6);
           
            RuleFor(x => x.Login)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Employees.Any(u => u.Login == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Loing", "Taki login już istnieje");
                    }
                });

            RuleFor(x => x.Pesel)
                .Custom((value, context) =>
                {
                    var PeselInUse = dbContext.Patients.Any(u => u.Pesel == value);
                    if (PeselInUse)
                    {
                        context.AddFailure("Pesel", "Taki pesel jest już w bazie");
                    }
                });


        }
    

    }
}

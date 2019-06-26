using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.Models;
using FluentValidation;


namespace Git_Watcher.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.GitUserName).NotEmpty().WithMessage("Enter valid user name");
        }
    }
   
}

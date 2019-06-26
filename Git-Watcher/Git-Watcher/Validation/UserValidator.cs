using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.DataAccess.Repositories;
using Git_Watcher.Models;
using FluentValidation;


namespace Git_Watcher.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly UserRepo _userRepo;

        public UserValidator(UserRepo userRepo)
        {
            _userRepo = userRepo;

            RuleFor(u => u.GitUserName).NotEmpty().WithMessage("Enter valid user name");
            RuleFor(u => u.GitUserName).Length(0, 40).WithMessage("Username too long");

            RuleFor(u => u.GitUserName)
                .Must(id => _userRepo.Get(id) != null)
                .WithMessage(u => $"User: {u.GitUserName} already exists!");
        }
    }
   
}

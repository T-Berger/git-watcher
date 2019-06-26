using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.Models;
using Git_Watcher.DataAccess.Repositories;
using FluentValidation;


namespace Git_Watcher.Validation
{
    public class SubscriptionValidator : AbstractValidator<Subscription>
    {
        private readonly IUserRepo _userRepo;
        private readonly IGitRepo _gitRepo;

        public SubscriptionValidator(IUserRepo userRepo, IGitRepo gitRepo)
        {
            _userRepo = userRepo;
            _gitRepo = gitRepo;

            RuleFor(s => s.RepoId).NotEmpty().WithMessage("Enter valid RepoID Name");
            RuleFor(s => s.UserId).NotEmpty().WithMessage("Enter valid UserID Link");

            RuleFor(s => s.RepoId)
                .Must(id => _gitRepo.Get(id) != null)
                .WithMessage(s => $"RepoID: {s.RepoId} not found")
                .WithErrorCode("test");

            RuleFor(s => s.UserId)
                .Must(id => _userRepo.Get(id) != null)
                .WithMessage(s => $"UserID: {s.UserId} not found")
                .WithErrorCode("test");
        }
    }
}

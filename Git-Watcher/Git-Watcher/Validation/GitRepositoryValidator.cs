using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.Models;
using FluentValidation;

namespace Git_Watcher.Validation
{
    public class GitRepositoryValidator : AbstractValidator<GitRepository>
    {
        public GitRepositoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Enter valid GitRepository Name");
            RuleFor(c => c.Link).NotEmpty().WithMessage("Enter valid GitRepository Link");
        }
    }
}

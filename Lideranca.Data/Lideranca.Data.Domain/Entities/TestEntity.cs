using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Domain.Entities
{
    public class TestEntity : BaseEntity
    {
        public string Text { get; set; }
        public string Observacao { get; set; }
        public DateTime DateLastUpdate { get; set; }
        public DateTime DateRegister { get; set; }
    }

    public class TestValidator : AbstractValidator<TestEntity>
    {
        public TestValidator()
        {
            RuleFor(c => c.Text)
                .NotEmpty().WithMessage("Please enter the Text.")
                .NotNull().WithMessage("Please enter the Text.");

            RuleFor(c => c.DateRegister)
                .NotEmpty().WithMessage("Please enter the DateRegister.")
                .NotNull().WithMessage("Please enter the DateRegister.");

            RuleFor(c => c.DateLastUpdate)
                .NotEmpty().WithMessage("Please enter the DateRegister.")
                .NotNull().WithMessage("Please enter the DateRegister.");
        }
    }
}

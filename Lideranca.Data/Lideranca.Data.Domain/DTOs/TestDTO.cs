using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Domain.DTOs
{
    public class TestDTO
    {
        public string TextComplex { get; set; }
        public DateTime DateLastUpdate { get; set; }
        public DateTime DateRegister { get; set; }
    }

    public class TestDTOValidator : AbstractValidator<TestDTO>
    {
        public TestDTOValidator()
        {
            RuleFor(x => x.TextComplex)
                .NotEmpty()
                .WithMessage("TextComplex not empty!");

            RuleFor(x => x.DateLastUpdate)
                .NotEmpty()
                .WithMessage("DateLastUpdate not empty!");

            RuleFor(x => x.DateRegister)
                .NotEmpty()
                .WithMessage("DateRegister not empty!");
        }
    }
}

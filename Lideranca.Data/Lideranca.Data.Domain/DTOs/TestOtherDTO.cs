using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Domain.DTOs
{
    public class TestOtherDTO
    {
        public string TextOtherComplex { get; set; }
        public DateTime DateLastUpdate { get; set; }
        public DateTime? DateRegister { get; set; }
    }

    public class TestOtherDTOValidator : AbstractValidator<TestOtherDTO>
    {
        public TestOtherDTOValidator()
        {
            RuleFor(x => x.TextOtherComplex)
                .NotEmpty()
                .WithMessage("TextOtherComplex not empty!");

            RuleFor(x => x.DateRegister)
                .NotEmpty()
                .WithMessage("DateRegister not empty!");
        }
    }
}

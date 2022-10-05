using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Domain.DTOs
{
    public class TestUpdateDTO : TestDTO
    {
        public long Id { get; set; }
    }

    public class TestUpdateDTOValidator : AbstractValidator<TestUpdateDTO>
    {
        public TestUpdateDTOValidator()
        {

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .NotEmpty()
                .WithMessage("Id not empty!");
        }
    }
}

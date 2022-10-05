using AutoMapper;
using Lideranca.Data.Domain.DTOs;
using Lideranca.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Service.AutoMapper
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<TestDTO, TestEntity>()
                .AfterMap((s, d) =>
                {
                    d.Text = s.TextComplex;
                })
                .ReverseMap()
                .ForPath(s => s.TextComplex, opt => opt.MapFrom(src => src.Text));
        }
    }
}

using AutoMapper;
using Lideranca.Data.Domain.DTOs;
using Lideranca.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Service.AutoMapper
{
    public class TestOtherProfile : Profile
    {
        public TestOtherProfile()
        {
            CreateMap<TestOtherDTO, TestEntity>()
                .AfterMap((s, d) =>
                {
                    d.Text = s.DateRegister.ToString();
                })
                .ReverseMap();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yeryok.Shared.Entities;
using Yeryok.Shared.Model.RequestModels;
using Yeryok.Shared.Model.ResponseModels;

namespace Yeryok.API.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<LoginResponseModel,User>();
            CreateMap<User,LoginResponseModel>();

            CreateMap<RegisterRequestModel, User>();
            CreateMap<User, RegisterRequestModel>();
        }
    }
}

using ApiTest.Core.Dtos.Common.Response;
using AutoMapper;

namespace InstantRemote.Core.Mapping.Common
{
    public class CommonAutoMapping : Profile
    {
        public CommonAutoMapping()
        {
            CreateMap<GetUsersResponseDto, GetUsersResponseDto>().ReverseMap();
        }
    }
}

using AutoMapper;

namespace MQApi.Web.Profiles
{
	public class RegionsProfile : Profile
	{
		public RegionsProfile()
		{
			//here we are converting from Domain to DTO
			//How  they know they have created a map

			//Here by mistake I have wrote Domain instead of DTO so giving error 500
			CreateMap<Model.Domain.Region, Model.DTO.Region>().ReverseMap();
		}
	}
}

//using AutoMapper;

//namespace NZWalks.API.Profiles
//{
//    public class RegionsProfile : Profile
//    {
//        public RegionsProfile()
//        {
//            CreateMap<Models.Domain.Region, Models.DTO.Region>()
//                .ReverseMap();
//        }
//    }
//}
using AutoMapper;

namespace MQApi.Web.Profiles
{
	public class RegionsProfile : Profile
	{
		public RegionsProfile()
		{
			//here we are converting from Domain to DTO
			//How  they know they have created a map
			CreateMap<Model.Domain.Region, Model.Domain.Region>().ReverseMap();
		}
	}
}

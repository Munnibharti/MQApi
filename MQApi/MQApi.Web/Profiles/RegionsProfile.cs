using AutoMapper;

namespace MQApi.Web.Profiles
{
	public class RegionsProfile : Profile
	{
		public RegionsProfile()
		{
			
			CreateMap<Model.Domain.Region, Model.DTO.Region>().ReverseMap();
		}
	}
}


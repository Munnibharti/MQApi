using AutoMapper;

namespace MQApi.Web.Profiles
{
    public class WalksProfile:Profile
    {
        public WalksProfile()
        {
            //here we are converting from Domain to DTO
            //How  they know they have created a map

            //Here by mistake I have wrote Domain instead of DTO so giving error 500
            CreateMap<Model.Domain.Walk, Model.DTO.Walk>().ReverseMap();

            CreateMap<Model.Domain.WalkDifficulty, Model.DTO.WalkDifficulty>().ReverseMap();
        }

       
    }
}

using AutoMapper;
namespace MQApi.Web.Profiles
{
    public class WalkDifficultyProfile: Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Model.Domain.WalkDifficulty, Model.DTO.WalkDifficulty>().ReverseMap();
        }
    }
}

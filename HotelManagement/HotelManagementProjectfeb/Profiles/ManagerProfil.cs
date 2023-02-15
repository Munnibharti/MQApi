using AutoMapper;

namespace HotelManagementProjectfeb.Profiles
{
    public class ManagerProfil : Profile
    {
        public ManagerProfil()
        {
            CreateMap<Model.Domain.Manager, Model.DTO.Manager>().ReverseMap();
        }
    }
}

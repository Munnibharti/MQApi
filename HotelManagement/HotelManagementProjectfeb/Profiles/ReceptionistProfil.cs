using AutoMapper;

namespace HotelManagementProjectfeb.Profiles
{
    public class ReceptionistProfil : Profile
    {
        public ReceptionistProfil()
        {
            CreateMap<Model.Domain.Receptionist,Model.DTO.Receptionist>().ReverseMap();
        }
    }
}

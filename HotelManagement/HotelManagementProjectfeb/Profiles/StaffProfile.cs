using AutoMapper;

namespace HotelManagementProjectfeb.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Model.Domain.Staff, Model.DTO.Staff>().ReverseMap();
        }
    }
    
    
}

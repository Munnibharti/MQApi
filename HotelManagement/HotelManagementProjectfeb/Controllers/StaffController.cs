using AutoMapper;
using HotelManagementProjectfeb.Data;
 
using HotelManagementProjectfeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
    [ApiController]
    [Route("Staff")]
    public class StaffController : Controller
    {

           //Profiles is basically a way to tell the application that
            //we have a code that is mapping the models  us
            //DTO=DAta transfer object this for converting
            // [Authorize]
            //The authorize attribute means the client must have valid token to access this
            private HotelManagementDataContext _db;
           
            private readonly IUserRepository _staffRepository;

            private readonly IMapper Mapper;


            public StaffController(IUserRepository staffRepository, IMapper mapper)
            {
                this._staffRepository = staffRepository;

                this.Mapper = mapper;

                
            }


            [HttpGet]
            //[Authorize]
            // [Authorize(Roles = "receptionist")]


            public async Task<IActionResult> GetAllRoomAsync()
            {
                var staff = await _staffRepository.GetAllAsync();

                //BY using Auto MApper

                var staffDTO = Mapper.Map<List<Model.DTO.Staff>>(staff);

                return Ok(staffDTO);
            }

            [HttpGet]
            [Route("{id:guid}")]
            [ActionName("GetStaffAsync")]
            //[Authorize]
            // [Authorize(Roles = "manager,owner")]
            public async Task<IActionResult> GetStaffAsync(Guid id)
            {
                var staff = await _staffRepository.GetAsync(id);

                if (staff == null)
                {
                    return NotFound();
                }

                var staffDTO = Mapper.Map<Model.DTO.Staff>(staff);

                return Ok(staffDTO);
            }

            [HttpPost]
            //[Authorize]
            //[Authorize(Roles = "writer")]
            // [Authorize(Roles = "manager,owner")]
            public async Task<IActionResult> AddStaffAsync(Model.DTO.AddStaffRequest addStaffRequest)
            {

                // first convert Request(DTO) to domain model
                var staff = new Model.Domain.Staff()
                {
                    FirstName = addStaffRequest.FirstName,
                    LastName = addStaffRequest.LastName,
                    Password = addStaffRequest.Password,
                    UserName = addStaffRequest.UserName

                  };

                //Pass details to Repository
                staff = await _staffRepository.AddAsync(staff);

                //Convert back to DTO

                var staffDTO = new Model.DTO.Staff
                {
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Password = staff.Password,
                    UserName = staff.UserName

                };

                return CreatedAtAction(nameof(GetStaffAsync), new { id = staffDTO.Id }, staffDTO);

            }

            [HttpDelete]
            [Route("{id:guid}")]
            //   [Authorize]
            //  [Authorize(Roles = "manager,owner")]
            public async Task<IActionResult> DeleteRoomAsync(Guid id)
            {
                //Get region from database 

                var staff = await _staffRepository.DeleteAsync(id);


                //if null not found
                if (staff == null)
                {
                    return NotFound();
                }
                //convert response back to DTO
                var staffDTO = new Model.DTO.Staff
                {
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Password = staff.Password,
                    UserName = staff.UserName

                };


                //return Ok response
                return Ok(staffDTO);

            }

            [HttpPut]
            [Route("{id:guid}")]
            // [Authorize]
            // [Authorize(Roles = "manager,owner")]
            public async Task<IActionResult> UpdateStaffAsync([FromRoute] Guid id, [FromBody] Model.DTO.UpdateStaffRequest updatestaffRequest)
            {

                var staff = new Model.Domain.Staff()
                {

                    FirstName = updatestaffRequest.FirstName,
                    LastName = updatestaffRequest.LastName,
                    Password = updatestaffRequest.Password,
                    UserName = updatestaffRequest.UserName

                   

                };


                //update region using repository
                staff = await _staffRepository.UpdateAsync(id, staff);

                //if null not found
                if (staff == null)
                {
                    return NotFound();
                }

                //Convert Domain back to DTO
                var staffDTO = new Model.DTO.Staff
                {
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Password = staff.Password,
                    UserName = staff.UserName

                };

                //Return OK Response

                return Ok(staffDTO);
            }
           
        }
}

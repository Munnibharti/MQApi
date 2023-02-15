using AutoMapper;
using HotelManagementProjectfeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
    [ApiController]
    [Route("Manager")]
    public class ManagerController : Controller
    {
        //Profiles is basically a way to tell the application that
        //we have a code that is mapping the models  us
        //DTO=DAta transfer object this for converting
        // [Authorize]
        //The authorize attribute means the client must have valid token to access this

        private readonly IManagerRepository _managerRepository;

        private readonly IMapper Mapper;


        public ManagerController(IManagerRepository managerRepository, IMapper mapper)
        {
            this._managerRepository = managerRepository;

            this.Mapper = mapper;
        }


        [HttpGet]
        //[Authorize]
        // [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetAllManagerAsync()
        {
            var manager = await _managerRepository.GetAllAsync();

            //BY using Auto MApper

            var managerDTO = Mapper.Map<List<Model.DTO.Manager>>(manager);

            return Ok(managerDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetManagerAsync")]
        //[Authorize]
        //[Authorize(Roles = "reader")]
        public async Task<IActionResult> GetManagerAsync(Guid id)
        {
            var managerm = await _managerRepository.GetAsync(id);

            if (managerm == null)
            {
                return NotFound();
            }

            var managermDTO = Mapper.Map<Model.DTO.Manager>(managerm);

            return Ok(managermDTO);
        }

        [HttpPost]
        //[Authorize]
        //[Authorize(Roles = "writer")]
        public async Task<IActionResult> AddInventoryAsync(Model.DTO.AddManagerRequest addmanagerRequest)
        {

            // first convert Request(DTO) to domain model
            var manager = new Model.Domain.Manager()
            {
               manager_name=addmanagerRequest.manager_name,

               address = addmanagerRequest.address,

               salary = addmanagerRequest.salary

            };

            //Pass details to Repository
            manager = await _managerRepository.AddAsync(manager);

            //Convert back to DTO

            var managerDTO = new Model.DTO.Manager()
            {

                manager_name = manager.manager_name,
                address = manager.address,
                salary = manager.salary

            };

            return CreatedAtAction(nameof(GetManagerAsync), new { id = managerDTO.manager_id }, managerDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        //   [Authorize]
        //  [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteManagerAsync(Guid id)
        {
            //Get region from database 

            var manager = await _managerRepository.DeleteAsync(id);

            //if null not found
            if (manager == null)
            {
                return NotFound();
            }
            //convert response back to DTO
            var managerDTO = new Model.DTO.Manager()
            {
                manager_name = manager.manager_name,

                address = manager.address,

                salary = manager.salary
                
            };

            //return Ok response
            return Ok(managerDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        // [Authorize]
        //  [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateManagerAsync([FromRoute] Guid id, [FromBody] Model.DTO.UpdateManagerRequest updateManagerRequest)
        {

            var manager = new Model.Domain.Manager()
            {
                manager_name  =updateManagerRequest.manager_name,
              
                address = updateManagerRequest.address,
                salary = updateManagerRequest.salary

            };


            //update region using repository
            manager = await _managerRepository.UpdateAsync(id, manager);

            //if null not found
            if (manager == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO
            var managerDTO = new Model.DTO.Manager
            {
                manager_name = manager.manager_name,
                address = manager.address,
                salary  =manager.salary
              
            };

            //Return OK Response

            return Ok(managerDTO);
        }

    }

}
}

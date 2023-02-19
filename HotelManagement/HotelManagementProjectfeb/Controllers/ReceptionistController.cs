using AutoMapper;
using HotelManagementProjectfeb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
  

[ApiController]
[Route("Receptionist")]


public class ReceptionistController : Controller
{

    //Profiles is basically a way to tell the application that
    //we have a code that is mapping the models  us
    //DTO=DAta transfer object this for converting
    // [Authorize]
    //The authorize attribute means the client must have valid token to access this

    private readonly IReceptionistRepositories _receptionistRepository;

    private readonly IMapper Mapper;


    public ReceptionistController(IReceptionistRepositories receptionistRepository, IMapper mapper)
    {
        this._receptionistRepository = receptionistRepository;

        this.Mapper = mapper;
    }


    [HttpGet]
    //[Authorize]
    [Authorize(Roles = "manager,owner")]

    public async Task<IActionResult> GetAllReceptionistAsync()
    {
        var receptionist = await _receptionistRepository.GetAllAsync();

        //BY using Auto MApper

        var receptionistDTO = Mapper.Map<List<Model.DTO.Receptionist>>(receptionist);

        return Ok(receptionistDTO);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("GetReceptionistAsync")]
    //[Authorize]
    [Authorize(Roles = "manager,owner")]
    public async Task<IActionResult> GetReceptionistAsync(Guid id)
    {
        var receptionist = await _receptionistRepository.GetAsync(id);

        if (receptionist == null)
        {
            return NotFound();
        }

        var receptionistDTO = Mapper.Map<Model.DTO.Receptionist>(receptionist);

        return Ok(receptionistDTO);
    }

    [HttpPost]
    //[Authorize]
    [Authorize(Roles = "manager,owner")]
    public async Task<IActionResult> AddReceptionistAsync(Model.DTO.AddReceptionistRequest addReceptionistRequest)
    {

        // first convert Request(DTO) to domain model
        var receptionist = new Model.Domain.Receptionist()
        {

            Receptionist_Name = addReceptionistRequest.Receptionist_Name,

            address = addReceptionistRequest.address,

            salary = addReceptionistRequest.salary

        };

        //Pass details to Repository
        receptionist = await _receptionistRepository.AddAsync(receptionist);

        //Convert back to DTO

        var receptionistDTO = new Model.DTO.Receptionist
        {
            Receptionist_Id = receptionist.Receptionist_Id,

            Receptionist_Name = receptionist.Receptionist_Name,

            address = receptionist.address,

            salary = receptionist.salary

        };

        return CreatedAtAction(nameof(GetReceptionistAsync), new { id = receptionistDTO.Receptionist_Id }, receptionistDTO);

    }

    [HttpDelete]
    [Route("{id:guid}")]
    //   [Authorize]
      [Authorize(Roles = "manager,owner")]
    public async Task<IActionResult> DeleteReceptionistAsync(Guid id)
    {
        //Get region from database 

        var receptionist = await _receptionistRepository.DeleteAsync(id);

        //if null not found
        if (receptionist == null)
        {
            return NotFound();
        }
        //convert response back to DTO
        var receptionistDTO = new Model.DTO.Receptionist
        {
            Receptionist_Name = receptionist.Receptionist_Name,

            address = receptionist.address,

            salary = receptionist.salary

        };

        //return Ok response
        return Ok(receptionistDTO);

    }

    [HttpPut]
    [Route("{id:guid}")]
    // [Authorize]
     [Authorize(Roles = "receptionist,manager,owner")]
    public async Task<IActionResult> UpdateReceptionistAsync([FromRoute] Guid id, [FromBody] Model.DTO.UpdateReceptionistRequest updatereceptionsitRequest)
    {

        var receptionist = new Model.Domain.Receptionist()
        {
            Receptionist_Name = updatereceptionsitRequest.Receptionist_Name,

            address = updatereceptionsitRequest.address,

            salary = updatereceptionsitRequest.salary

        };


        //update region using repository
        receptionist = await _receptionistRepository.UpdateAsync(id, receptionist);

        //if null not found
        if (receptionist == null)
        {
            return NotFound();
        }

        //Convert Domain back to DTO
        var receptionistDTO = new Model.DTO.Receptionist
        {
            Receptionist_Name = receptionist.Receptionist_Name,

            address = receptionist.address,

            salary = receptionist.salary


        };

        //Return OK Response

        return Ok(receptionistDTO);
    }

}

    }





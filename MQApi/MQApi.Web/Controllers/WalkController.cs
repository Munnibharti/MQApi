using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MQApi.Web.Repositories;
using System.Data;
using System.Xml.Linq;

namespace MQApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WalkController : Controller
    {

        private readonly IWalkRepositroy _walkRepository;
        private readonly IMapper Mapper;

        public WalkController(IWalkRepositroy walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetAllWalksAsync()
        {
            //This is fetching from database
            

            //because we have change synchronous to asynchronous
            var walk = await _walkRepository.GetAllAsync();


            //BY using Auto MApper

            var walksDTO = Mapper.Map<List<Model.DTO.Walk>>(walk);

            return Ok(walksDTO);
        }
        //after doing this goes to profile for creating profile otherwise give 500 error

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            // getting walkm data from database
            var walkm = await _walkRepository.GetAsync(id);

            if (walkm == null)
            {
                return NotFound();
            }

            //Convert domain object to DTO

            var walkDTO = Mapper.Map<Model.DTO.Walk>(walkm);

            return Ok(walkDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]


        //Here I was getting Loading Api Failed because i have written AddRegionAsync instead of AddWalkasync
        public async Task<IActionResult> AddWalkAsync([FromBody]Model.DTO.AddWalkRequest addWalkRequest)
        {
            // first convert Request(DTO) to domain model
            var walkDomain = new Model.Domain.Walk()
            {
                Name = addWalkRequest.Name,
                Length = addWalkRequest.Length,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId

            };

            //Pass details to Repository to persist this
            walkDomain = await _walkRepository.AddAsync(walkDomain);

            //Convert back to DTO

            var walkDTO = new Model.DTO.Walk
            {
                Name = walkDomain.Name,
                Length = walkDomain.Length,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId

            };




            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);



        }
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Model.DTO.UpdateWalkRequest updateWalkRequest)
        {
            //first convert DTO Request to Domain
            // first convert Request(DTO) to domain model
            var walkDomain = new Model.Domain.Walk()
            {
                Name = updateWalkRequest.Name,
                Length = updateWalkRequest.Length,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };


            //update region using repository
            walkDomain = await _walkRepository.UpdateWalkAsync(id, walkDomain);


            //if null not found
            if (walkDomain == null)
            {
                return NotFound();
            }


            //Convert Domain back to DTO
            var walkDTO = new Model.DTO.Walk
            {
                Name = walkDomain.Name,
                Length = walkDomain.Length,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId

            };



            //Return OK Response

            return Ok(walkDTO);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            //Get region from database 

            var walk = await _walkRepository.DeleteAsync(id);

            //if null not found
            if (walk == null)
            {
                return NotFound();
            }
            //convert response back to DTO
            var walkDTO = new Model.DTO.Walk
            {
                Name = walk.Name,
                Length = walk.Length,
                RegionId = walk.RegionId,
                WalkDifficultyId = walk.WalkDifficultyId

            };



            //return Ok response
            return Ok(walkDTO);



        }
    }
}

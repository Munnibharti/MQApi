using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MQApi.Web.Model.DTO;
using MQApi.Web.Repositories;
using System.Data;

namespace MQApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WalkDifficultyController : Controller
    {
        private readonly _IWalkDifficultyRepository walkdifficultyRepository;
        private readonly IMapper Mapper;

        public WalkDifficultyController(_IWalkDifficultyRepository walkdiffRepository, IMapper mapper)
        {
            walkdifficultyRepository = walkdiffRepository;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetAllWalkDiffsAsync()
        {
            //This is fetching from database
            

            //because we have change synchronous to asynchronous
            var walkd = await walkdifficultyRepository.GetAllAsync();


            //BY using Auto Mapper

            var regionsDTO = Mapper.Map<List<Model.DTO.WalkDifficulty>>(walkd);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDiffAsync")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetWalkDiffAsync(Guid id)
        {
            // getting walkm data from database
            var walkdiffdom = await walkdifficultyRepository.GetAsync(id);
        

            if (walkdiffdom == null)
            {
                return NotFound();
            }

            //Convert domain object to DTO

            var walkdiffDTO = Mapper.Map<Model.DTO.WalkDifficulty>(walkdiffdom);

            return Ok(walkdiffDTO);
        }
        [HttpPost]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> AddWalkAsync([FromBody] Model.DTO.AddDifficultyWalkRequest addWalkRequest)
        {
            // first convert Request(DTO) to domain model
            var walkdiffDomain = new Model.Domain.WalkDifficulty()
            {
               Code  = addWalkRequest.Code

            };

            //Pass details to Repository to persist this
            walkdiffDomain = await walkdifficultyRepository.AddAsync(walkdiffDomain);

            //Convert back to DTO

            var walkDiffDTO = new Model.DTO.WalkDifficulty
            {
                Code = walkdiffDomain.Code
               

            };




            return CreatedAtAction(nameof(GetWalkDiffAsync), new { id = walkDiffDTO.Id }, walkDiffDTO);



        }
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //Get region from database 

            var walkdiff = await walkdifficultyRepository.DeleteAsync(id);

            //if null not found
            if (walkdiff == null)
            {
                return NotFound();
            }
            //convert response back to DTO
            var walkDTO = new Model.DTO.WalkDifficulty
            {
                Code = walkdiff.Code


            };



            //return Ok response
            return Ok(walkDTO);



        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Model.DTO.updateWalkDifficultyRequest updatewalkdiffRequest)
        {
            //first convert DTO Request to Domain
            // first convert Request(DTO) to domain model
            var walkdiff = new Model.Domain.WalkDifficulty()
            {
                Code = updatewalkdiffRequest.Code
            };


            //update region using repository
            walkdiff  = await walkdifficultyRepository.UpdateWalkdiffAsync(id, walkdiff);


            //if null not found
            if (walkdiff == null)
            {
                return NotFound();
            }


            //Convert Domain back to DTO
            var walkdiffDTO = new Model.DTO.WalkDifficulty
            {
               Code  = walkdiff.Code

            };



            //Return OK Response

            return Ok(walkdiffDTO);
        }
    }
}

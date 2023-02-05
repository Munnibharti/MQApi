using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MQApi.Web.Model.Domain;
using MQApi.Web.Model.DTO;
using MQApi.Web.Repositories;

namespace MQApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Authorize]
    //The authorize attribute means the client must have valid token to access this
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper Mapper;


        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._regionRepository = regionRepository;

            this.Mapper = mapper;
        }


        [HttpGet]
        //[Authorize]
        [Authorize(Roles ="reader")]

        public async Task<IActionResult> GetAllRegionsAsync()
        {
            //This is fetching from database
            //var region =  _regionRepository.GetAll();

            //because we have change synchronous to asynchronous
            var region = await _regionRepository.GetAllAsync();


            //BY using Auto MApper

            var regionsDTO = Mapper.Map<List<Model.DTO.Region>>(region);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        [Authorize]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var regionm = await _regionRepository.GetAsync(id);

            if (regionm == null)
            {
                return NotFound();
            }

            var regionDTO = Mapper.Map<Model.DTO.Region>(regionm);

            return Ok(regionDTO);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(Model.DTO.AddRegionRequest addRegionRequest)
        {
           // //Validate the Request
           //if(!ValidateAddRegionAsync(addRegionRequest))
           // {
           //     return BadRequest(ModelState);
           // }


            // first convert Request(DTO) to domain model
            var region = new Model.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population
            };

            //Pass details to Repository
            region = await _regionRepository.AddAsync(region);

            //Convert back to DTO

            var regionDTO = new Model.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };




            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);



        }

        [HttpDelete]
        [Route("{id:guid}")]
     //   [Authorize]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //Get region from database 

            var region = await  _regionRepository.DeleteAsync(id);

            //if null not found
            if (region == null)
            {
                return NotFound();
            }
            //convert response back to DTO
            var regionDTO = new Model.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };

           

            //return Ok response
            return Ok(regionDTO);

            

        }

        [HttpPut]
        [Route("{id:guid}")]
        // [Authorize]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id,[FromBody]Model.DTO.UpdateRegionRequest updateRegionRequest)
        {
            ////validate Request
            ////Validate the Request
            //if (!ValidateUpdateAsync(updateRegionRequest))
            //{
            //    return BadRequest(ModelState);
            //}

            //first convert DTO Request to Domain
            // first convert Request(DTO) to domain model
            var region = new Model.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population= updateRegionRequest.Population
            };


            //update region using repository
            region = await _regionRepository.UpdateRegionAsync(id, region);


            //if null not found
            if(region == null)
            {
                return NotFound();
            }


            //Convert Domain back to DTO
            var regionDTO = new Model.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };



            //Return OK Response

            return Ok(regionDTO);
        }

        #region Private method

        private bool ValidateAddRegionAsync(Model.DTO.AddRegionRequest addRegionRequest)
        {
            if(addRegionRequest == null)
            {
                ModelState.AddModelError(nameof(addRegionRequest),
                    $"Add region Data is required.");

                return false;

            }

            if(string.IsNullOrWhiteSpace(addRegionRequest.Code))
            {
                ModelState.AddModelError(nameof(addRegionRequest.Code),

                   $"{nameof(addRegionRequest.Code)} cannot be null or empty or white space " +
                   $"it must be filled.");
            }

            if (string.IsNullOrWhiteSpace(addRegionRequest.Name))
            {
                ModelState.AddModelError(nameof(addRegionRequest.Name),

                   $"{nameof(addRegionRequest.Name)} cannot be null or empty or white space " +
                   $"it must be filled.");
            }

            if (addRegionRequest.Area <= 0)
            {
                ModelState.AddModelError(nameof(addRegionRequest.Area),

                   $"{nameof(addRegionRequest.Area)} Area must be greater than 0");
            }
        

          if(ModelState.ErrorCount>0)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region Private method
        private bool ValidateUpdateAsync(Model.DTO.UpdateRegionRequest updateRegionRequest)
        {
            if (updateRegionRequest == null)
            {
                ModelState.AddModelError(nameof(updateRegionRequest),
                    $"Add region Data is required.");

                return false;

            }

            if (string.IsNullOrWhiteSpace(updateRegionRequest.Code))
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Code),

                   $"{nameof(updateRegionRequest.Code)} cannot be null or empty or white space " +
                   $"it must be filled.");
            }

            if (string.IsNullOrWhiteSpace(updateRegionRequest.Name))
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Name),

                   $"{nameof(updateRegionRequest.Name)} cannot be null or empty or white space " +
                   $"it must be filled.");
            }

            if (updateRegionRequest.Area <= 0)
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Area),

                   $"{nameof(updateRegionRequest.Area)} Area must be greater than 0");
            }
           

            if (updateRegionRequest.Population <= 0)
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Population),

                   $"{nameof(updateRegionRequest.Population)} Logitude must be greater than 0 or positive");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }
         #endregion
    }





}


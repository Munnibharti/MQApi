using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MQApi.Web.Model.Domain;
using MQApi.Web.Model.DTO;
using MQApi.Web.Repositories;

namespace MQApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        public async Task<IActionResult> AddRegionAsync(Model.DTO.AddRegionRequest addRegionRequest)
        {
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
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id,[FromBody]Model.DTO.UpdateRegionRequest updateRegionRequest)
        {
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

	}
}

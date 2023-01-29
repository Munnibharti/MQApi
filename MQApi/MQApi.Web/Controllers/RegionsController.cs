using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MQApi.Web.Model.Domain;
using MQApi.Web.Repositories;

namespace MQApi.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegionsController : Controller
	{
       private readonly IRegionRepository _regionRepository;
        private readonly IMapper Mapper;

        //public RegionsController(IRegionRepository regionRepository)
        //{
        //	this._regionRepository = regionRepository;
        //}

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this._regionRepository=regionRepository;
            
            this.Mapper = mapper;
        }


		[HttpGet]
		public async  Task<IActionResult>GetAllRegions()
		{
            //This is fetching from database
			//var region =  _regionRepository.GetAll();

            //because we have change synchronous to asynchronous
            var region = await _regionRepository.GetAllAsync();

            //return DtO regions here we with the help of DTO 

            //var regionsDTO = new List<Model.DTO.Region>();
            //region.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Model.DTO.Region()
            //    {
            //        Id =region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,


            //    };
            //    regionsDTO.Add(regionDTO);

            //});

            //return Ok(regionsDTO);


            //this is for we are inserting value manually


            //var regions = new List<Region>()
            //{
            //	new Region
            //	{
            //		Id=Guid.NewGuid(),
            //		Name="Wellington",
            //		Code="WLG",
            //		Area=227755,
            //		Lat = -1.8822,
            //		Long = 299.88,
            //		Population= 50000
            //	},
            //             new Region
            //             {
            //                 Id=Guid.NewGuid(),
            //                 Name="Auckland",
            //                 Code="Auck",
            //                 Area=227753,
            //                 Lat = -1.8842,
            //                 Long = 299.98,
            //                 Population= 50000
            //             },




            //         };


            var regionsDTO = Mapper.Map<List<Model.DTO.Region>>(region);

            return Ok(regionsDTO);




            //BY using Auto MApper

        }
	}
}

using MQApi.Web.Model.Domain;

namespace MQApi.Web.Model.DTO
{
	public class Region
	{
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double Area { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public long Population { get; set; }

        //This is navigation 
        //here one region can have multiple walks
        public IEnumerable<Walk> Walks { get; set; }
    }
}

using MQApi.Web.Model.Domain;

namespace MQApi.Web.Model.DTO
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }

        //Navigation property

        //here one walk can have one region
        public Region Region { get; set; }

        //here one walk can have one walkdifficulty
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
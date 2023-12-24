using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Desk : IEntity
    {
        public int Id { get; set; }

        [EnumDataType(typeof(DeskStatus))]
        public DeskStatus DeskStatus { get; set; }

        public int DeskCapacity { get; set; }
        public int UniversityId { get; set; }

        public University? University { get; set; }

        public int LibraryId { get; set; }
        public Library? Library { get; set; }

        public int FloorId { get; set; }

        public Floor? Floor { get; set; }

        public int BlockId { get; set; }

        public Block? Block { get; set; }

    }
}
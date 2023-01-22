

namespace ISCards.Data.Entities
{
    public class BaseCard : BaseEntity
    {
        public string CardType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime CreationDate { get; set; }
        public string RespName { get; set; }
        public DateTime Deadline { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}

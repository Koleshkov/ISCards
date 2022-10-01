using System.ComponentModel.DataAnnotations;

namespace ISCards.Data.Entities
{
    public class BaseCard : Base
    {
        public string CardType { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreationDate { get; set; }
        public string RespName { get; set; }
        public DateTime Deadline { get; set; }
    }
}

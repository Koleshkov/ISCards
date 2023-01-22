using CommunityToolkit.Mvvm.ComponentModel;

namespace ISCards.Models
{
    public partial class BaseCardDTO : BaseEntityDTO
    {
        [ObservableProperty]
        private string cardTitle = "";

        [ObservableProperty]
        private string cardName = "";
        public string CardType { get; set; }
        public virtual string FirstName { get; set; } = "";
        public virtual string LastName { get; set; } = "";
        public virtual string MiddleName { get; set; } = "";
        public virtual DateTime CreationDate { get; set; } = DateTime.Now;

        [ObservableProperty]
        private string respName = "";

        [ObservableProperty]
        private DateTime deadline = DateTime.Now;

        [ObservableProperty]
        private bool isSent;

        public string FilePath { get; set; } = "";
        public string FileName { get; set; } = "";

        public BaseCardDTO(string cardType)
        {
            CardType=cardType;
        }
    }
}

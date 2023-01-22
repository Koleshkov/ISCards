

namespace ISCards.Services.Repositories.CardRepositories
{
    public interface ICardRepository<TCard, TCardDTO>
    {
        Task<TCardDTO> GetCardByIdAsync(int Id);
        Task<List<TCardDTO>> GetAllCardsAsync();
        Task CreateCardAsync(TCardDTO card);
        Task UpdateCardAsync(TCardDTO card);
        Task DeleteCardAsync(int id);
    }
}

using AutoMapper;
using ISCards.Data;
using ISCards.Data.Entities;
using ISCards.Models;
using Microsoft.EntityFrameworkCore;


namespace ISCards.Services.Repositories.CardRepositories
{
    public class CardRepository<TCard, TCardDTO> : ICardRepository<TCard, TCardDTO>
        where TCardDTO : BaseCardDTO
        where TCard : BaseCard
    {
        private readonly IDbContextFactory<ApplicationContext> dbFactory;
        private readonly IMapper mapper;

        public CardRepository(IDbContextFactory<ApplicationContext> dbFactory, IMapper mapper)
        {
            this.dbFactory=dbFactory;
            this.mapper=mapper;
        }

        public async Task CreateCardAsync(TCardDTO card)
        {
            using var context = await dbFactory.CreateDbContextAsync();

            await context.Set<TCard>()
                    .AddAsync(mapper.Map<TCard>(card));

            await context.SaveChangesAsync();
        }

        public async Task<List<TCardDTO>> GetAllCardsAsync()
        {
            using var context = await dbFactory.CreateDbContextAsync();

            return await context.Set<TCard>()
                                .Select(c => mapper.Map<TCardDTO>(c))
                                .ToListAsync();
        }


        public async Task<TCardDTO> GetCardByIdAsync(int id)
        {
            using var context = await dbFactory.CreateDbContextAsync();

            var card = await context.Set<TCard>()
                                    .FirstOrDefaultAsync(c => c.Id==id);

            return mapper.Map<TCardDTO>(card);
        }

        public async Task UpdateCardAsync(TCardDTO card)
        {
            using var context = await dbFactory.CreateDbContextAsync();

            context.Set<TCard>().Update(mapper.Map<TCard>(card));

            await context.SaveChangesAsync();
        }

        public async Task DeleteCardAsync(int id)
        {
            using var context = await dbFactory.CreateDbContextAsync();

            var card = await context.Set<TCard>()
                                    .FirstOrDefaultAsync(e => e.Id==id);

            context.Set<TCard>().Remove(card);

            await context.SaveChangesAsync();
        }
    }
}

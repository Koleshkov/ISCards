using ISCards.Models;

namespace ISCards.Services.SafetyCardServices
{
    public interface ISafetyCardService
    {
        Task<bool> SendSafetyCardAsync(SafetyCardDTO safetyCard);
    }
}

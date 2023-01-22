using ISCards.Models;

namespace ISCards.Services.PassengerCardServices
{
    public interface IPassengerCardService
    {
        Task<bool> SendPassagnerCardAsync(PassengerCardDTO passengerCard);
    }
}

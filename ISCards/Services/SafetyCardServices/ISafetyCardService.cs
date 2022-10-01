using ISCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCards.Services.SafetyCardServices
{
    public interface ISafetyCardService
    {
        Task<bool> SendSafetyCardAsync(SafetyCardDTO safetyCard);
    }
}

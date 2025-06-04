using Transporteo.DTOs.PaymentMethod;

namespace Transporteo.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodDto>> GetAllAsync();
        Task<PaymentMethodDto> CreateAsync(PaymentMethodCreateDto dto);
    }

}

using Microsoft.EntityFrameworkCore;
using Transporteo.Data;
using Transporteo.DTOs.PaymentMethod;
using Transporteo.Models.Entities;
using Transporteo.Services.Interfaces;

namespace Transporteo.Services.Implementations
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly ApplicationDbContext _context;

        public PaymentMethodService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<PaymentMethodDto>> GetAllAsync()
        {
            return await _context.PaymentMethods
                .Select(p => new PaymentMethodDto { Name = p.Name, Description = p.Description })
                .ToListAsync();
        }

        public async Task<PaymentMethodDto> CreateAsync(PaymentMethodCreateDto dto)
        {
            var method = new PaymentMethod { Name = dto.Name, Description = dto.Description };
            _context.PaymentMethods.Add(method);
            await _context.SaveChangesAsync();

            return new PaymentMethodDto { Name = method.Name, Description = method.Description };
        }
    }

}

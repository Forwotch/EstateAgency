using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EstateAgency.BLL.RentAnnouncements;

namespace EstateAgency.BLL.Apartments.Services
{
    public interface IApartmentService
    {
        Task<IEnumerable<ApartmentDto>> GetAllAsync();
        Task<ApartmentDto> GetAsync(int id);
        Task<int> AddAsync(ApartmentCreateDto apartmentCreateDto);
        Task<int> UpdateAsync(ApartmentUpdateDto apartmentUpdateDto);
        Task<int> DeleteAsync(int id);
    }
}
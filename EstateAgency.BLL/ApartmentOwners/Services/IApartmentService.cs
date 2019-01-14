using System.Collections.Generic;
using System.Threading.Tasks;
using EstateAgency.BLL.Apartments;

namespace EstateAgency.BLL.ApartmentOwners.Services
{
    public interface IApartmentOwnerService
    {
        Task<IEnumerable<ApartmentOwnerDto>> GetAllAsync();
        Task<ApartmentOwnerDto> GetAsync(int id);
        Task<int> AddAsync(ApartmentOwnerCreateDto apartmentOwnerCreateDto);
        Task<int> UpdateAsync(ApartmentOwnerUpdateDto apartmentOwnerUpdateDto);
        Task<int> DeleteAsync(int id);
    }
}
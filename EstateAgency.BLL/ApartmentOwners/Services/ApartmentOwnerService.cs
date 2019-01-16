using AutoMapper;
using EstateAgency.DAL.Entities;
using EstateAgency.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.ApartmentOwners.Services
{
    public class ApartmentOwnerService : IApartmentOwnerService
    {
        private readonly IUnitOfWork _estateAgencyDataStorage;
        private readonly IMapper _mapper;

        public ApartmentOwnerService(IUnitOfWork estateAgencyDataStorage, IMapper mapper)
        {
            _estateAgencyDataStorage = estateAgencyDataStorage;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApartmentOwnerDto>> GetAllAsync()
        {
            var apartmentOwners = await _estateAgencyDataStorage.ApartmentOwners.GetAll().ToListAsync();
            var apartmentOwnerDtos = _mapper.Map<IEnumerable<ApartmentOwnerDto>>(apartmentOwners);
            return apartmentOwnerDtos;
        }

        public async Task<ApartmentOwnerDto> GetAsync(int id)
        {
            var apartmentOwner = await _estateAgencyDataStorage.ApartmentOwners.GetAsync(id);
            var apartmentOwnerDto = _mapper.Map<ApartmentOwnerDto>(apartmentOwner);
            return apartmentOwnerDto;
        }
        
        public async Task<int> AddAsync(ApartmentOwnerCreateDto apartmentOwnerCreateDto)
        {
            if (string.IsNullOrEmpty(apartmentOwnerCreateDto.FirstName))
            {
                return -1;
            }
            if (string.IsNullOrEmpty(apartmentOwnerCreateDto.LastName))
            {
                return -2;
            }
            if (string.IsNullOrEmpty(apartmentOwnerCreateDto.Email))
            {
                return -3;
            }
            if (string.IsNullOrEmpty(apartmentOwnerCreateDto.PhoneNumber))
            {
                return -4;
            }

            var apartmentOwner = _mapper.Map<ApartmentOwner>(apartmentOwnerCreateDto);

            await _estateAgencyDataStorage.ApartmentOwners.AddAsync(apartmentOwner);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return apartmentOwner.Id;
        }

        public async Task<int> UpdateAsync(ApartmentOwnerUpdateDto apartmentOwnerUpdateDto)
        {
            if (string.IsNullOrEmpty(apartmentOwnerUpdateDto.FirstName))
            {
                return -1;
            }
            if (string.IsNullOrEmpty(apartmentOwnerUpdateDto.LastName))
            {
                return -2;
            }
            if (string.IsNullOrEmpty(apartmentOwnerUpdateDto.Email))
            {
                return -3;
            }
            if (string.IsNullOrEmpty(apartmentOwnerUpdateDto.PhoneNumber))
            {
                return -4;
            }

            var apartmentOwner = await _estateAgencyDataStorage.ApartmentOwners.GetAsync(apartmentOwnerUpdateDto.Id);
            apartmentOwner.FirstName = apartmentOwnerUpdateDto.FirstName;
            apartmentOwner.LastName = apartmentOwnerUpdateDto.LastName;
            apartmentOwner.Email = apartmentOwnerUpdateDto.Email;
            apartmentOwner.PhoneNumber = apartmentOwnerUpdateDto.PhoneNumber;

            _estateAgencyDataStorage.ApartmentOwners.Update(apartmentOwner);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return apartmentOwner.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (!await _estateAgencyDataStorage.ApartmentOwners.ContainsEntityWithId(id))
            {
                return -5;
            }

            _estateAgencyDataStorage.ApartmentOwners.Delete(id);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return 1;
        }
    }
}
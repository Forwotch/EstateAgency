using AutoMapper;
using EstateAgency.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.Apartments.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _estateAgencyDataStorage;
        private readonly IMapper _mapper;
        private readonly IApartmentCreator _apartmentCreator;

        public ApartmentService(IUnitOfWork estateAgencyDataStorage, IMapper mapper, IApartmentCreator apartmentCreator)
        {
            _estateAgencyDataStorage = estateAgencyDataStorage;
            _mapper = mapper;
            _apartmentCreator = apartmentCreator;
        }

        public async Task<IEnumerable<ApartmentDto>> GetAllAsync()
        {
            var apartments = await _estateAgencyDataStorage.Apartments.GetAll().ToListAsync();
            var apartmentDtos = _mapper.Map<IEnumerable<ApartmentDto>>(apartments);
            return apartmentDtos;
        }

        public async Task<ApartmentDto> GetAsync(int id)
        {
            var apartment = await _estateAgencyDataStorage.Apartments.GetAsync(id);
            var apartmentDto = _mapper.Map<ApartmentDto>(apartment);
            return apartmentDto;
        }
        
        public async Task<int> AddAsync(ApartmentCreateDto apartmentCreateDto)
        {
            if (!await _estateAgencyDataStorage.ApartmentOwners.ContainsEntityWithId(apartmentCreateDto.OwnerId))
            {
                return -1;
            }
            if (apartmentCreateDto.NumberOfRooms <= 0 || apartmentCreateDto.NumberOfRooms >= 100)
            {
                return -2;
            }
            if (apartmentCreateDto.Area <= 0)
            {
                return -3;
            }
            if (apartmentCreateDto.Floor <= 0 || apartmentCreateDto.Floor >= 100)
            {
                return -4;
            }
            if (string.IsNullOrEmpty(apartmentCreateDto.Address))
            {
                return -5;
            }

            var apartmentOwner = await _estateAgencyDataStorage.ApartmentOwners.GetAsync(apartmentCreateDto.OwnerId);
            
            var apartment =
                _apartmentCreator.CreateApartmentForAddition(apartmentCreateDto, apartmentOwner);

            await _estateAgencyDataStorage.Apartments.AddAsync(apartment);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return apartment.Id;
        }

        public async Task<int> UpdateAsync(ApartmentUpdateDto apartmentUpdateDto)
        {
            if (!await _estateAgencyDataStorage.ApartmentOwners.ContainsEntityWithId(apartmentUpdateDto.OwnerId))
            {
                return -1;
            }
            if (apartmentUpdateDto.NumberOfRooms <= 0 || apartmentUpdateDto.NumberOfRooms >= 100)
            {
                return -2;
            }
            if (apartmentUpdateDto.Area <= 0)
            {
                return -3;
            }
            if (apartmentUpdateDto.Floor <= 0 || apartmentUpdateDto.Floor >= 100)
            {
                return -4;
            }
            if (string.IsNullOrEmpty(apartmentUpdateDto.Address))
            {
                return -5;
            }

            var apartment = await _estateAgencyDataStorage.Apartments.GetAsync(apartmentUpdateDto.Id);
            apartment.NumberOfRooms = (byte)apartmentUpdateDto.NumberOfRooms;
            apartment.Address = apartmentUpdateDto.Address;
            apartment.Floor = (byte)apartmentUpdateDto.Floor;
            apartment.Area = apartmentUpdateDto.Area;
            apartment.Description = apartmentUpdateDto.Description;

            _estateAgencyDataStorage.Apartments.Update(apartment);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return apartment.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (!await _estateAgencyDataStorage.Apartments.ContainsEntityWithId(id))
            {
                return -6;
            }

            _estateAgencyDataStorage.Apartments.Delete(id);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return 1;
        }
    }
}
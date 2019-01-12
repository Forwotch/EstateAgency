using System;
using AutoMapper;
using EstateAgency.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public class RentAnnouncementService : IRentAnnouncementService
    {
        private readonly IUnitOfWork _estateAgencyDataStorage;
        private readonly IMapper _mapper;
        private readonly IRentAnnouncementCreator _rentAnnouncementCreator;

        public RentAnnouncementService(IUnitOfWork estateAgencyDataStorage, IMapper mapper, IRentAnnouncementCreator rentAnnouncementCreator)
        {
            _estateAgencyDataStorage = estateAgencyDataStorage;
            _mapper = mapper;
            _rentAnnouncementCreator = rentAnnouncementCreator;
        }

        public async Task<IEnumerable<RentAnnouncementDto>> GetAllAsync()
        {
            var rentAnnouncements = await _estateAgencyDataStorage.RentAnnouncements.GetAll().ToListAsync();
            var rentAnnouncementDtos = _mapper.Map<IEnumerable<RentAnnouncementDto>>(rentAnnouncements);
            return rentAnnouncementDtos;
        }

        public async Task<RentAnnouncementDto> GetAsync(int id)
        {
            var rentAnnouncement = await _estateAgencyDataStorage.RentAnnouncements.GetAsync(id);
            var rentAnnouncementDto = _mapper.Map<RentAnnouncementDto>(rentAnnouncement);
            return rentAnnouncementDto;
        }

        public async Task<IEnumerable<RentAnnouncementDto>> FindAsync(Expression<Func<RentAnnouncementDto, bool>> expression)
        {
            var rentAnnouncementsQuery = _estateAgencyDataStorage.RentAnnouncements.GetAll();
            var rentAnnouncementDtosQuery = _mapper.ProjectTo<RentAnnouncementDto>(rentAnnouncementsQuery).Where(expression);
            var rentAnnouncementDtos = await rentAnnouncementDtosQuery.ToListAsync();
            return rentAnnouncementDtos;
        }

        public async Task<int> AddAsync(RentAnnouncementCreateDto rentAnnouncementCreateDto)
        {
            if (!await _estateAgencyDataStorage.ApartmentOwners.ContainsEntityWithId(rentAnnouncementCreateDto.OwnerId))
            {
                return -1;
            }
            if (!await _estateAgencyDataStorage.Apartments.ContainsEntityWithId(rentAnnouncementCreateDto.ApartmentId))
            {
                return -2;
            }
            if (rentAnnouncementCreateDto.Rent <= 0)
            {
                return -3;
            }
            if (rentAnnouncementCreateDto.TermInDays <= 0)
            {
                return -4;
            }

            var apartmentOwner = await _estateAgencyDataStorage.ApartmentOwners.GetAsync(rentAnnouncementCreateDto.OwnerId);
            var apartment =
                await _estateAgencyDataStorage.Apartments.GetAsync(rentAnnouncementCreateDto.ApartmentId);

            var rentAnnouncement =
                _rentAnnouncementCreator.CreateRentAnnouncementForAddition(rentAnnouncementCreateDto, apartmentOwner, apartment);

            rentAnnouncementCreateDto.CreationDate = rentAnnouncement.CreationDate;

            await _estateAgencyDataStorage.RentAnnouncements.AddAsync(rentAnnouncement);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return rentAnnouncement.Id;
        }

        public async Task<int> UpdateAsync(RentAnnouncementUpdateDto rentAnnouncementUpdateDto)
        {
            if (!await _estateAgencyDataStorage.ApartmentOwners.ContainsEntityWithId(rentAnnouncementUpdateDto.OwnerId))
            {
                return -1;
            }
            if (!await _estateAgencyDataStorage.Apartments.ContainsEntityWithId(rentAnnouncementUpdateDto.ApartmentId))
            {
                return -2;
            }
            if (rentAnnouncementUpdateDto.Rent <= 0)
            {
                return -3;
            }
            if (rentAnnouncementUpdateDto.TermInDays <= 0)
            {
                return -4;
            }

            var rentAnnouncement = await _estateAgencyDataStorage.RentAnnouncements.GetAsync(rentAnnouncementUpdateDto.Id);
            rentAnnouncement.Rent = rentAnnouncementUpdateDto.Rent;
            rentAnnouncement.TermInDays = rentAnnouncementUpdateDto.TermInDays;
            rentAnnouncement.Status = "On review";

            _estateAgencyDataStorage.RentAnnouncements.Update(rentAnnouncement);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return rentAnnouncement.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (!await _estateAgencyDataStorage.RentAnnouncements.ContainsEntityWithId(id))
            {
                return -5;
            }

            _estateAgencyDataStorage.RentAnnouncements.Delete(id);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return 1;
        }
    }
}
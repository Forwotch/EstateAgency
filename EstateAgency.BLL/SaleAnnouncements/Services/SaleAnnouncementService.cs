using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EstateAgency.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public class SaleAnnouncementService : ISaleAnnouncementService
    {
        private readonly IUnitOfWork _estateAgencyDataStorage;
        private readonly IMapper _mapper;
        private readonly ISaleAnnouncementCreator _saleAnnouncementCreator;

        public SaleAnnouncementService(IUnitOfWork estateAgencyDataStorage, IMapper mapper, ISaleAnnouncementCreator saleAnnouncementCreator)
        {
            _estateAgencyDataStorage = estateAgencyDataStorage;
            _mapper = mapper;
            _saleAnnouncementCreator = saleAnnouncementCreator;
        }

        public async Task<IEnumerable<SaleAnnouncementDto>> GetAllAsync()
        {
            var saleAnnouncements = await _estateAgencyDataStorage.SaleAnnouncements.GetAll().ToListAsync();
            var saleAnnouncementDtos = _mapper.Map<IEnumerable<SaleAnnouncementDto>>(saleAnnouncements);
            return saleAnnouncementDtos;
        }

        public async Task<SaleAnnouncementDto> GetAsync(int id)
        {
            var saleAnnouncement = await _estateAgencyDataStorage.SaleAnnouncements.GetAsync(id);
            var saleAnnouncementDto = _mapper.Map<SaleAnnouncementDto>(saleAnnouncement);
            return saleAnnouncementDto;
        }

        public async Task<IEnumerable<SaleAnnouncementDto>> FindAsync(Expression<Func<SaleAnnouncementDto, bool>> expression)
        {
            var saleAnnouncementsQuery = _estateAgencyDataStorage.SaleAnnouncements.GetAll();
            var saleAnnouncementDtosQuery = _mapper.ProjectTo<SaleAnnouncementDto>(saleAnnouncementsQuery).Where(expression);
            var saleAnnouncementDtos = await saleAnnouncementDtosQuery.ToListAsync();
            return saleAnnouncementDtos;
        }

        public async Task<int> AddAsync(SaleAnnouncementCreateDto saleAnnouncementCreateDto)
        {
            if (!await _estateAgencyDataStorage.ApartmentOwners.ContainsEntityWithId(saleAnnouncementCreateDto.OwnerId))
            {
                return -1;
            }
            if (!await _estateAgencyDataStorage.Apartments.ContainsEntityWithId(saleAnnouncementCreateDto.ApartmentId))
            {
                return -2;
            }
            if (saleAnnouncementCreateDto.Price <= 0)
            {
                return -3;
            }

            var apartmentOwner = await _estateAgencyDataStorage.ApartmentOwners.GetAsync(saleAnnouncementCreateDto.OwnerId);
            var apartment =
                await _estateAgencyDataStorage.Apartments.GetAsync(saleAnnouncementCreateDto.ApartmentId);

            var saleAnnouncement =
                _saleAnnouncementCreator.CreateSaleAnnouncementForAddition(saleAnnouncementCreateDto, apartmentOwner, apartment);

            saleAnnouncementCreateDto.CreationDate = saleAnnouncement.CreationDate;

            await _estateAgencyDataStorage.SaleAnnouncements.AddAsync(saleAnnouncement);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return saleAnnouncement.Id;
        }

        public async Task<int> UpdateAsync(SaleAnnouncementUpdateDto saleAnnouncementUpdateDto)
        {
            if (!await _estateAgencyDataStorage.ApartmentOwners.ContainsEntityWithId(saleAnnouncementUpdateDto.OwnerId))
            {
                return -1;
            }
            if (!await _estateAgencyDataStorage.Apartments.ContainsEntityWithId(saleAnnouncementUpdateDto.ApartmentId))
            {
                return -2;
            }
            if (saleAnnouncementUpdateDto.Price <= 0)
            {
                return -3;
            }

            var saleAnnouncement = await _estateAgencyDataStorage.SaleAnnouncements.GetAsync(saleAnnouncementUpdateDto.Id);
            saleAnnouncement.Price = saleAnnouncementUpdateDto.Price;
            saleAnnouncement.Status = "On review";

            _estateAgencyDataStorage.SaleAnnouncements.Update(saleAnnouncement);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return saleAnnouncement.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (!await _estateAgencyDataStorage.SaleAnnouncements.ContainsEntityWithId(id))
            {
                return -5;
            }

            _estateAgencyDataStorage.SaleAnnouncements.Delete(id);
            await _estateAgencyDataStorage.SaveChangesAsync();
            return 1;
        }
    }
}
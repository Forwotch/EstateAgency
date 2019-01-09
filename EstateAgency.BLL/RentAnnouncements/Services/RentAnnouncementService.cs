using AutoMapper;
using EstateAgency.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public class RentAnnouncementService : IRentAnnouncementService
    {
        private readonly IUnitOfWork _estateAgencyDataStorage;
        private readonly IMapper _mapper;

        public RentAnnouncementService(IUnitOfWork estateAgencyDataStorage, IMapper mapper)
        {
            _estateAgencyDataStorage = estateAgencyDataStorage;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RentAnnouncementDto>> GetAllAsync()
        {
            var rentAnnouncements = await _estateAgencyDataStorage.RentAnnouncements.GetAllAsync();
            var rentAnnouncementDtos = _mapper.Map<IEnumerable<RentAnnouncementDto>>(rentAnnouncements);
            return rentAnnouncementDtos;
        }

        public async Task<RentAnnouncementDto> GetAsync(int id)
        {
            var rentAnnouncement = await _estateAgencyDataStorage.RentAnnouncements.GetAsync(id);
            var rentAnnouncementDto = _mapper.Map<RentAnnouncementDto>(rentAnnouncement);
            return rentAnnouncementDto;
        }
    }
}
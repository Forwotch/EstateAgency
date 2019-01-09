using EstateAgency.API.Models;
using EstateAgency.BLL.RentAnnouncements.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EstateAgency.API.Services;

namespace EstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    public class RentAnnouncementsController : Controller
    {
        private readonly IRentAnnouncementService _rentAnnouncementService;
        private readonly IMapper _mapper;
        private readonly IRentAnnouncementResponseComposer _rentAnnouncementResponseComposer;

        public RentAnnouncementsController(IRentAnnouncementService rentAnnouncementService, IMapper mapper,
            IRentAnnouncementResponseComposer rentAnnouncementResponseComposer)
        {
            _rentAnnouncementService = rentAnnouncementService;
            _mapper = mapper;
            _rentAnnouncementResponseComposer = rentAnnouncementResponseComposer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var rentAnnouncementDtos = await _rentAnnouncementService.GetAllAsync();
            var response = _rentAnnouncementResponseComposer.Compose(rentAnnouncementDtos);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var rentAnnouncementDto = await _rentAnnouncementService.GetAsync(id);
            var response = _rentAnnouncementResponseComposer.Compose(rentAnnouncementDto);
            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApp.API.Data;
using TaskApp.API.Dtos;
using TaskApp.API.Models;

namespace TaskApp.API.Controllers
{


	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IHomeRepository _repo;
		private readonly IMapper _mapper;

		public HomeController(IHomeRepository repo, IMapper mapper)
		{
			_mapper = mapper;
			_repo = repo;
		}

		[HttpGet("{id}/data")]
		public async Task<ActionResult> Get(string id)
		{

			if (!_repo.isRoomExistInHome(id))
				return NotFound();
			// in real project we can use Unauthorized() 
			var rooms = await _repo.GetHomeRooms(id);
			var roomsToReturn = _mapper.Map<IEnumerable<RoomForReturnDto>>(rooms);
			return Ok(roomsToReturn);

		}

		// PUT is only to update the information in room when we have new information and we do it by room id if you want test by
		// Postman after un comment // CreateMap<Room, RoomForReturnDto>(); in Helpers-->AutoMapperProfiles
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, RoomForUpdateDto roomForUpdateDto)
		{
			if (!_repo.isRoomExist(id))
				return NotFound();
			var roomFromRepo = await _repo.GetRoomById(id);
			_mapper.Map(roomForUpdateDto, roomFromRepo);
			if (await _repo.SaveAll())
			{
				return NoContent();
			}
			throw new Exception($"We have problem when we update room info{id} ");
		}

	}
}

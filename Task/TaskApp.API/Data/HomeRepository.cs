using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApp.API.Models;

namespace TaskApp.API.Data
{
	public class HomeRepository : IHomeRepository
	{
		private readonly DataContext _context;
		public HomeRepository(DataContext context)
		{
			_context = context;
		}
		// get all the rooms in house by house id
		public async Task<List<Room>> GetHomeRooms(string id)
		{
			var rooms = await _context.Rooms.Where(x => x.HouseIdent == id).ToListAsync();
			return rooms;
		}


		// check if the house have any room or its wrong id 
		public bool isRoomExistInHome(string id)
		{
			if (_context.Rooms.Any(x => x.HouseIdent == id))
			{
				return true;
			}
			return false;
		}
		// Check if the roomis is exist  before updating the information
		public bool isRoomExist(int id)
		{
			if (_context.Rooms.Any(x => x.id == id))
			{
				return true;
			}
			return false;
		}
		// Save all change in database
		public async Task<bool> SaveAll()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		// get only the room with id
		public async Task<Room> GetRoomById(int id)
		{
			var rooms = await _context.Rooms.FirstOrDefaultAsync(x => x.id == id);
			return rooms;
		}
	}
}
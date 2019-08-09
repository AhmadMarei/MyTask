using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.API.Models;

namespace TaskApp.API.Data
{
	public interface IHomeRepository
	{
		bool isRoomExistInHome(string id);
		Task<List<Room>> GetHomeRooms(string id);
		Task<bool> SaveAll();
		bool isRoomExist(int id);
		Task<Room> GetRoomById(int id);

	}
}
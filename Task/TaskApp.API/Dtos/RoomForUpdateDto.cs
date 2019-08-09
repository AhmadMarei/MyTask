using System.ComponentModel.DataAnnotations;

namespace TaskApp.API.Dtos
{
	// DTO(Data Transfer Objects): i use it to change the shape of the data that api send to client
	public class RoomForUpdateDto
	{
		[Required]
		public float Temperature { get; set; }
		[Required]
		public float Humidity { get; set; }
	}
}
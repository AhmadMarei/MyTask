namespace TaskApp.API.Dtos
{
	// DTO(Data Transfer Objects): i use it to change the shape of the data that api send to client 
	public class RoomForReturnDto
	{
		public string Name { get; set; }
		public float Temperature { get; set; }
		public float Humidity { get; set; }
	}
}
namespace TaskApp.API.Models
{
	public class Room
	{
		public int id { get; set; }
		public string Name { get; set; }
		public float Temperature { get; set; }
		public float Humidity { get; set; }
		// I added HouseIdent to establish a relationship between the house and its rooms but in the real situation I need to create a table of houses
		// And table of rooms and make relationship if we use Relational database
		public string HouseIdent { get; set; }
	}
}
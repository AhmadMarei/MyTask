using System;

namespace TaskApp.API.Extensions
{
	public static class Extensions
	{
        // I add this method to create fake data
		public static float getRandomValue(this float value, bool isTemp)
		{
			float[] floatArrayForHumidity = { 0.0f, 0.022f, 0.3f, 0.4f, 0.55f, 0.06f };
			float[] floatArrayForTemp = { 3, 10, 20, 5, 15, 22 };
			Random random = new Random();
			if (isTemp)
			{
				return value + floatArrayForTemp[random.Next(floatArrayForTemp.Length)];
			}
			return value + floatArrayForHumidity[random.Next(floatArrayForHumidity.Length)];

		}
	}
}
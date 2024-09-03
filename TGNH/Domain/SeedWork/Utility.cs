using System.Text.Json;

namespace Domain.SeedWork
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static DateTime Now
		{
			get
			{
				return DateTime.Now;
			}
		}

		public static DateTime Today
		{
			get
			{
				return Now.Date;
			}
		}

        public static string ConvertObjectToJson(object obj, bool writeIndented)
        {
            string result = "";

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = writeIndented,
            };

            result = JsonSerializer.Serialize(obj, options);

            return result;
        }
    }
}

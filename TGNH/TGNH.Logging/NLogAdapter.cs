using Microsoft.AspNetCore.Http;

namespace TGNH.Logging
{
	public class NLogAdapter<T> : Logger<T> where T : class
	{
		public NLogAdapter(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
		{
		}

		protected override void LogByFavoriteLibrary(Log log, Exception exception)
		{
			string loggerMessage = log.ToString();

			NLog.Logger logger = NLog.LogManager.GetLogger(typeof(T).ToString());

			switch (log.Level)
			{
				case LogLevel.Trace:
				{
					logger.Trace(exception, loggerMessage);

					break;
				}

				case LogLevel.Debug:
				{
					logger.Debug(exception, loggerMessage);

					break;
				}

				case LogLevel.Information:
				{
					logger.Info(exception, loggerMessage);

					break;
				}

				case LogLevel.Warning:
				{
					logger.Warn(exception, loggerMessage);

					break;
				}

				case LogLevel.Error:
				{
					logger.Error(exception, loggerMessage);

					break;
				}

				case LogLevel.Critical:
				{
					logger.Fatal(exception, loggerMessage);

					break;
				}
			}
		}
	}
}

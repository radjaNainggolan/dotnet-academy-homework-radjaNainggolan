using Library.RadenRovcanin.Contracts.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Library.RadenRovcanin.Functions
{
    public class BookRentingReminder
    {
        private readonly ILibraryNotificationService _service;
        private readonly ILogger _logger;

        public BookRentingReminder(ILibraryNotificationService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _logger = loggerFactory.CreateLogger<BookRentingReminder>();
        }

        [FunctionName("BookRentingReminder")]
        public async Task Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                await _service.SendReturnBookNotification();
            }
            catch (Exception ex)
            {
                _logger.LogError($"C# Timer trigger function executed with error {ex.Message}");
            }
        }
    }
}

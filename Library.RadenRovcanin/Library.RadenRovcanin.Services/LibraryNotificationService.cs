using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;

namespace Library.RadenRovcanin.Services
{
    public class LibraryNotificationService : ILibraryNotificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IEmailService _emailService;

        public LibraryNotificationService(IUnitOfWork uow, IEmailService emailService)
        {
            _uow = uow;
            _emailService = emailService;
        }

        public async Task SendReturnBookNotification()
        {
            const int Days_Ago = 30;
            var dateInPast = DateTime.UtcNow.AddDays(-Days_Ago);

            var people = await _uow.People.GetPeopleWithBookRentedBeforeDate(dateInPast);

            foreach (var person in people)
            {
                await _emailService.Send(person.Email, "Library notice", $"Please return books rented {Days_Ago} days ago");
            }
        }
    }
}

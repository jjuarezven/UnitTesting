using System.Linq;

namespace TestNinja.Mocking
{
	public class BookingStorage : IBookingStorage
	{
		public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
		{
			var unitOfWork = new UnitOfWork();
			var bookings =
				unitOfWork.Query<Booking>()
					.Where(
						b => b.Status != "Cancelled");

			if (excludedBookingId.HasValue)
			{
				bookings = bookings.Where(b => b.Id != excludedBookingId.Value);
			}
			return bookings;
		}
	}
}

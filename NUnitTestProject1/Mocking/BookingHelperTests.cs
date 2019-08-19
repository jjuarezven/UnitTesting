using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class BookingHelperTests
	{
		private Booking existingBooking;
		private Mock<IBookingStorage> repository;

		[SetUp]
		public void Setup()
		{
			existingBooking = new Booking 
			{ 
				Id = 2, 
				ArrivalDate = GenerateDate(2017, 1, 15, true), 
				DepartureDate = GenerateDate(2017, 1, 20, false), 
				Reference = "a" 
			};
			repository = new Mock<IBookingStorage>();
			repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
			{
				existingBooking
			}.AsQueryable());
		}

		[Test]
		public void OverlappingBookingsExist_BookingStartAndFinishesBeforeAnExistingBookin_ReturnEmptyString()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking 
			{ 
				Id = 1, 
				ArrivalDate = Before(existingBooking.ArrivalDate, days: 2), 
				DepartureDate = GenerateDate(2017, 1, 14, false) 
			}, repository.Object);
			Assert.That(result, Is.Empty);
		}

		private DateTime GenerateDate(int year, int month, int day, bool arrival) 
		{
			var time = arrival? new TimeSpan(14, 0, 0) : new TimeSpan(10, 0, 0);
			return new DateTime(year, month, day) + time;
		}

		private DateTime Before(DateTime dateTime, int days = 1)
		{
			return dateTime.AddDays(-days);
		}

		private DateTime After(DateTime dateTime)
		{
			return dateTime.AddDays(1);
		}
	}
}

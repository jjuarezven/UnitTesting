﻿using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	class ErrorLoggerTests
	{

		[Test]
		public void Log_WhenCalled_SetTheLastErrorProperty()
		{
			var logger = new ErrorLogger();
			logger.LastError = "a";
			Assert.That(logger.LastError, Is.EqualTo("a"));
		}

		[Test]
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Log_InvalidError_ThrowArgumentNullException(string error)
		{
			var logger = new ErrorLogger();
			Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
		}

		// probando un evento
		[Test]
		public void Log_ValidError_RaiseErrorLogEvent()
		{
			var logger = new ErrorLogger();
			var id = Guid.Empty;
			logger.ErrorLogged += (sender, args) => { id = args; };
			logger.Log("a");
			Assert.That(id, Is.Not.EqualTo(Guid.Empty));
		}
	}
}
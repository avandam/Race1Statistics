using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RaceStatistics.Test.Utilities
{
    public sealed class ExpectedExceptionCheckMessage : ExpectedExceptionBaseAttribute
    {
        private readonly Type expectedExceptionType;
        private readonly string expectedExceptionMessage;

        public ExpectedExceptionCheckMessage(Type expectedExceptionType)
        {
            this.expectedExceptionType = expectedExceptionType;
            expectedExceptionMessage = string.Empty;
        }

        public ExpectedExceptionCheckMessage(Type expectedExceptionType, string expectedExceptionMessage)
        {
            this.expectedExceptionType = expectedExceptionType;
            this.expectedExceptionMessage = expectedExceptionMessage;
        }

        protected override void Verify(Exception exception)
        {
            Assert.IsNotNull(exception);

            Assert.IsInstanceOfType(exception, expectedExceptionType, "Wrong type of exception was thrown.");

            if (!expectedExceptionMessage.Length.Equals(0))
            {
                Assert.AreEqual(expectedExceptionMessage, exception.Message, "Wrong exception message was returned.");
            }
        }
    }
}

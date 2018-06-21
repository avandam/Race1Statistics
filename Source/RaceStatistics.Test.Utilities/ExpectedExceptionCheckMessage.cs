using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RaceStatistics.Test.Utilities
{
    public sealed class ExpectedExceptionCheckMessage : ExpectedExceptionBaseAttribute
    {
        private readonly Type expectedExceptionType;
        private readonly string expectedExceptionMessage = string.Empty;
        private readonly string errorMessageProblemWithType;
        private readonly string errorMessageProblemWithMessage;

        public ExpectedExceptionCheckMessage(Type expectedExceptionType, string errorMessageProblemWithType, string errorMessageProblemWithMessage)
        {
            this.expectedExceptionType = expectedExceptionType;
            this.errorMessageProblemWithType = errorMessageProblemWithType;
            this.errorMessageProblemWithMessage = errorMessageProblemWithMessage;
        }

        public ExpectedExceptionCheckMessage(Type expectedExceptionType, string expectedExceptionMessage, string errorMessageProblemWithType, string errorMessageProblemWithMessage) 
            : this(expectedExceptionType, errorMessageProblemWithType, errorMessageProblemWithMessage)
        {
            this.expectedExceptionMessage = expectedExceptionMessage;
        }

        protected override void Verify(Exception exception)
        {
            Assert.IsNotNull(exception);

            Assert.IsInstanceOfType(exception, expectedExceptionType, errorMessageProblemWithType);

            if (!expectedExceptionMessage.Length.Equals(0))
            {
                Assert.AreEqual(expectedExceptionMessage, exception.Message, errorMessageProblemWithMessage);
            }
        }
    }
}

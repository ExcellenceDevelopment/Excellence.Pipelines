using System;

using Excellence.Pipelines.Utils;

using Xunit;

namespace Excellence.Pipelines.Tests.Utils
{
    public class ExceptionUtilsTests
    {
        #region IsNull

        public static TheoryData<object?, bool> IsNullTestData => new TheoryData<object?, bool>()
        {
            { new object(), false },
            { null, true },
            { "", false },
            { (string?)null, true },
            { 5, false },
            { (int?)null, true }
        };

        [Theory]
        [MemberData(nameof(IsNullTestData))]
        public void IsNull_ReturnsCorrectResult(object? target, bool expectedResult)
        {
            var actualResult = ExceptionUtils.IsNull(target);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion IsNull

        #region Process

        public static TheoryData<object?, Func<object?, bool>?, Func<Exception>?> ProcessExceptionTestData => new TheoryData<object?, Func<object?, bool>?, Func<Exception>?>()
        {
            { new object(), null, null },
            { new object(), ExceptionUtils.IsNull, null }
        };

        [Theory]
        [MemberData(nameof(ProcessExceptionTestData))]
        public void Process_Argument_IsNull_ThrowsException(object? arg, Func<object?, bool>? predicate, Func<Exception>? exceptionFactory) =>
            Assert.Throws<ArgumentNullException>(() => ExceptionUtils.Process(arg, predicate!, exceptionFactory!));

        public static Func<Exception> ArgumentNullExceptionFactory => () => new ArgumentNullException();

        public static TheoryData<object?, Func<object?, bool>, Func<Exception>, bool> ProcessTestData => new TheoryData<object?, Func<object?, bool>, Func<Exception>, bool>()
        {
            { new object(), ExceptionUtils.IsNull, ArgumentNullExceptionFactory, false },
            { null, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, true },
            { "", ExceptionUtils.IsNull, ArgumentNullExceptionFactory, false },
            { (string?)null, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, true },
            { 5, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, false },
            { (int?)null, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, true }
        };

        [Theory]
        [MemberData(nameof(ProcessTestData))]
        public void Process_ExecutesCorrectly(object? arg, Func<object?, bool> predicate, Func<Exception> exceptionFactory, bool shouldThrow)
        {
            var processDelegate = () => ExceptionUtils.Process(arg, predicate, exceptionFactory);

            if (shouldThrow)
            {
                Assert.Throws<ArgumentNullException>(processDelegate);
            }
            else
            {
                processDelegate.Invoke();
            }
        }

        #endregion Process
    }
}

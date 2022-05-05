using System;
using System.Threading.Tasks;

using Excellence.Pipelines.Utils;

using Xunit;

namespace Excellence.Pipelines.Tests.Utils
{
    public class ErrorMessageUtilsTests
    {
        #region CreateNoTargetErrorMessage

        [Fact]
        public void CreateNoTargetErrorMessage_ArgumentIsNull_ThrowsException() =>
            Assert.Throws<ArgumentNullException>(() => ErrorMessageUtils.CreateNoTargetErrorMessage(null!));

        public static TheoryData<Type> CreateNoTargetErrorMessageTestData =>
            new TheoryData<Type>()
            {
                { typeof(object) },
                { typeof(Exception) },
                { typeof(string) }
            };

        [Theory]
        [MemberData(nameof(CreateNoTargetErrorMessageTestData))]
        public void CreateNoTargetErrorMessage_ReturnsCorrectErrorMessage(Type type)
        {
            var expectedResult = $"The {type} does not have a target.";

            var actualResult = ErrorMessageUtils.CreateNoTargetErrorMessage(type);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion CreateNoTargetErrorMessage

        #region CreateNoServiceProviderErrorMessage

        [Fact]
        public void CreateNoServiceProviderErrorMessage_ArgumentIsNull_ThrowsException() =>
            Assert.Throws<ArgumentNullException>(() => ErrorMessageUtils.CreateNoServiceProviderErrorMessage(null!));

        public static TheoryData<Type> CreateNoServiceProviderErrorMessageTestData =>
            new TheoryData<Type>()
            {
                { typeof(object) },
                { typeof(Exception) },
                { typeof(Task) }
            };

        [Theory]
        [MemberData(nameof(CreateNoServiceProviderErrorMessageTestData))]
        public void CreateNoServiceProviderErrorMessage_ReturnsCorrectResult(Type type)
        {
            var expectedResult = $"The service provider is not set for the {type}.";

            var actualResult = ErrorMessageUtils.CreateNoServiceProviderErrorMessage(type);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion CreateNoServiceProviderErrorMessage
    }
}

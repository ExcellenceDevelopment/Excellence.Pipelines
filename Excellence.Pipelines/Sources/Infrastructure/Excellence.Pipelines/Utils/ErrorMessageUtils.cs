using System;

namespace Excellence.Pipelines.Utils
{
    /// <summary>
    /// The error message utils.
    /// </summary>
    public static class ErrorMessageUtils
    {
        /// <summary>
        /// Creates the error message when the pipeline target is not set.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The error message.</returns>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        public static string CreateNoTargetErrorMessage(Type type)
        {
            ExceptionUtils.Process(type, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(type)));

            return $"The {type} does not have a target.";
        }

        /// <summary>
        /// Creates the error message when the service provider is not set.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The error message.</returns>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        public static string CreateNoServiceProviderErrorMessage(Type type)
        {
            ExceptionUtils.Process(type, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(type)));

            return $"The service provider is not set for the {type}.";
        }
    }
}

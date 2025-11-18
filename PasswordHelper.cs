// IMPORTANT: This class uses BCrypt.Net. Ensure the 'BCrypt.Net-Next' NuGet package is installed in your project.
// You can install it via Package Manager Console: Install-Package BCrypt.Net-Next

using BC = BCrypt.Net.BCrypt; // alias for easier usage

namespace HumanitarianProjectManagement.Utilities
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Hashes a plain-text password using BCrypt.
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new System.ArgumentNullException(nameof(password), "Password cannot be null or empty.");
            }
            return BC.HashPassword(password);
        }

        /// <summary>
        /// Verifies a plain-text password against a stored BCrypt hash.
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            {
                return false;
            }

            try
            {
                return BC.Verify(password, hashedPassword);
            }
            catch (BCrypt.Net.SaltParseException ex)
            {
                System.Console.WriteLine($"Error verifying password due to invalid hash format: {ex.Message}");
                return false;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Unexpected error during password verification: {ex.Message}");
                return false;
            }
        }
    }
}

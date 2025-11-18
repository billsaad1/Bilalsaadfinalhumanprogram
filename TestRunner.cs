using System.Threading.Tasks;
using System; // For Console
using System.Diagnostics; // Added for Debug.WriteLine
// Ensure correct using for test classes if they are in a different namespace
// using HumanitarianProjectManagement.Tests;

namespace HumanitarianProjectManagement // Or a suitable namespace like HumanitarianProjectManagement.DevUtils
{
    public class TestRunner
    {
        // Changed from async Task to void as called methods are now synchronous
        public static void MainTestEntry()
        {
            Console.WriteLine("Starting conceptual tests...");
            Console.WriteLine("====================================");

            // Run UI Logic Tests
            try
            {
                HumanitarianProjectManagement.Tests.ProjectCreateEditFormTests.RunAllConceptualTests();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during ProjectCreateEditFormTests: {ex.Message}");
                Debug.WriteLine($"ProjectCreateEditFormTests Exception: {ex}");
            }
            Console.WriteLine("====================================");

            // Run ProjectService Conceptual Tests
            try
            {
                // Calls are now to synchronous methods
                HumanitarianProjectManagement.Tests.ProjectServiceTests.RunAllConceptualTests();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during ProjectServiceTests: {ex.Message}");
                Debug.WriteLine($"ProjectServiceTests Exception: {ex}");
            }
            Console.WriteLine("====================================");

            // Run LogFrameService Conceptual Tests
            try
            {
                // Calls are now to synchronous methods
                HumanitarianProjectManagement.Tests.LogFrameServiceTests.RunAllConceptualTests();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during LogFrameServiceTests: {ex.Message}");
                Debug.WriteLine($"LogFrameServiceTests Exception: {ex}");
            }
            Console.WriteLine("====================================");

            Console.WriteLine("Conceptual tests finished. Check console and debug output for assertions.");
            Console.WriteLine("Note: Service tests are conceptual and do not perform actual DB operations in this version.");
        }
    }
}

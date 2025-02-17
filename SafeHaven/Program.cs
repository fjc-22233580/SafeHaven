using SafeHaven.Controller;

namespace SafeHaven
{
    /// <summary>
    /// The main class and entry point of the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        static void Main(string[] args)
        {
            // Create a new instance of the view controller, which in turns creates the model and view.
            ViewController viewController = new ViewController();
        }
    }
}

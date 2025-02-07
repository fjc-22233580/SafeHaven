using SafeHaven.Controller;
using SafeHaven.Model;

namespace SafeHaven
{
    /// <summary>
    /// A class that represents the SafeHaven application.
    /// </summary>
    public class Safehaven
    {
        private readonly SafeHavenModel model = new SafeHavenModel();
        private readonly ViewController viewController;

        /// <summary>
        /// Initializes a new instance of the <see cref="Safehaven"/> class.
        /// </summary>
        public Safehaven()
        {
            viewController = new ViewController(model);            
        }
    }
}
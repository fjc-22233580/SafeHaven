using SafeHaven.Controller;
using SafeHaven.Model;

namespace SafeHaven
{
    /// <summary>
    /// A class that represents the SafeHaven application.
    /// </summary>
    public class Safehaven
    {
        #region Fields
        
        /// <summary>
        /// The model for the SafeHaven application.
        /// </summary>
        private readonly SafeHavenModel model = new SafeHavenModel();

        /// <summary>
        /// The view controller for the SafeHaven application.
        /// </summary>
        private readonly ViewController viewController;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Safehaven"/> class.
        /// </summary>
        public Safehaven()
        {
            viewController = new ViewController(model);            
        }

        #endregion
    }
}
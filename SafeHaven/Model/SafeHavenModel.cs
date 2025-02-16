using System;
using System.Collections.Generic;
using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model
{
    /// <summary>
    /// The model for the SafeHaven application.
    /// </summary>
    public class SafeHavenModel
    {

        #region Fields

        /// <summary>
        /// The device manager.
        /// </summary>
        private DeviceManager _deviceManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeHavenModel"/> class.
        /// </summary>
        public SafeHavenModel()
        {
            _deviceManager = new DeviceManager();
            CreateTestDevices();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the devices in the model.
        /// </summary>
        public List<IDevice> Devices => _deviceManager.Devices;

        #endregion

        #region Methods

        /// <summary>
        /// Create dummy devices for testing.
        /// </summary>
        private void CreateTestDevices()
        {
            AddDevice("Motion Detector", DeviceType.MotionDetector);
            AddDevice("Fire Detector", DeviceType.FireDetector);
            AddDevice("Front Door Sensor", DeviceType.WindowDoorSensor);
        }

        /// <summary>
        /// Adds a device to the model.
        /// </summary>
        /// <param name="friendlyName"></param>
        /// <param name="deviceType"></param>
        public void AddDevice(string friendlyName, DeviceType deviceType)
        {
            IDevice device = DeviceFactory.CreateDevice(friendlyName, deviceType);
            _deviceManager.AddDevice(device);
        }

        #endregion
    }
}
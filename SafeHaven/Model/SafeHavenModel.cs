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
        #region Events

        /// <summary>
        ///  Occurs when the devices in the model have changed.
        /// </summary>
        public event EventHandler DevicesChanged;

        #endregion

        #region Fields

        /// <summary>
        /// The list of devices in the model.
        /// </summary>
        private List<IDevice> _devices = new List<IDevice>();

        private DeviceManager _deviceManager;  

        #endregion

        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeHavenModel"/> class.
        /// </summary>
        public SafeHavenModel()
        {
            CreateTestDevices();
            _deviceManager = new DeviceManager(_devices);
        }

        private void CreateTestDevices()
        {
            AddDevice("Motion Detector", DeviceType.MotionDetector);
            AddDevice("Fire Detector", DeviceType.FireDetector);
            AddDevice("Front Door Sensor", DeviceType.WindowDoorSensor);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets the devices in the model.
        /// </summary>
        public List<IDevice> Devices => _devices;

        #endregion

        #region Methods

        /// <summary>
        /// Adds a device to the model.
        /// </summary>
        /// <param name="friendlyName"></param>
        /// <param name="deviceType"></param>
        public void AddDevice(string friendlyName, DeviceType deviceType)
        {
            IDevice device = DeviceFactory.CreateDevice(friendlyName, deviceType);
            _devices.Add(device);
        }

        #endregion
    }
}
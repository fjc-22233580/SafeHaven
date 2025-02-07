using System;
using System.Collections.Generic;
using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model
{
    public class SafeHavenModel
    {
        public event EventHandler DevicesChanged;

        private List<IDevice> _devices = new List<IDevice>();  

        public SafeHavenModel()
        {
            // Add some default devices
            AddDevice("Kitchen Fire Detector", DeviceType.FireDetector, DeviceStatus.Connected);
            AddDevice("Upstairs Fire Detector", DeviceType.FireDetector, DeviceStatus.Connected);

        }

        public void AddDevice(string friendlyName, DeviceType deviceType, DeviceStatus deviceStatus)
        {
            IDevice device = DeviceFactory.CreateDevice(friendlyName, deviceType, deviceStatus);
            _devices.Add(device);
        }

        public List<IDevice> Devices => _devices;

    }
}
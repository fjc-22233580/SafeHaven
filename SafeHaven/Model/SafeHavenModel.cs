using System.Collections.Generic;
using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model
{
    public class SafeHavenModel
    {
        private List<IDevice> _devices = new List<IDevice>();  

        public SafeHavenModel()
        {

        }

        public void AddDevice(string friendlyName, DeviceType deviceType, DeviceStatus deviceStatus)
        {
            IDevice device = DeviceFactory.CreateDevice(friendlyName, deviceType, deviceStatus);
            device.DeviceTriggered += DeviceTriggered;
            _devices.Add(device);
        }


        /// <summary>
        /// Event handler for when a device is triggered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceTriggered(object sender, System.EventArgs e)
        {
            
        }

    }
}
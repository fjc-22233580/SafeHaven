using System;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model.Devices
{
    /// <summary>
    /// Factory class for creating devices.
    /// </summary>
    public static class DeviceFactory
    {
        /// <summary>
        /// Creates a device based on the specified device type.
        /// </summary>
        /// <param name="friendlyName">The friendly name of the device.</param>
        /// <param name="deviceType">The type of the device.</param>
        /// <returns>An instance of a device that implements the <see cref="IDevice"/> interface.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the device type is not recognized.</exception>
        public static IDevice CreateDevice(string friendlyName, DeviceType deviceType)
        {
            IDevice device = null;

            switch (deviceType)
            {
                case DeviceType.FireDetector:
                    device = new FireDetector(Guid.NewGuid(), friendlyName, deviceType);
                    break;
                case DeviceType.MotionDetector:
                    device = new MotionDetector(Guid.NewGuid(), friendlyName, deviceType);
                    break;
                case DeviceType.WindowDoorSensor:
                    device = new WindowDoorSensor(Guid.NewGuid(), friendlyName, deviceType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(deviceType), deviceType, null);
            }

            return device;
        }
    }
}
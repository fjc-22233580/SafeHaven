using System;
using SafeHaven.Model.Devices;

namespace SafeHaven.Model.Interfaces
{
    /// <summary>
    /// Represents the core properties of a device.
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// Gets the unique identifier of the device.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the friendly name of the device.
        /// </summary>
        string FriendlyName { get; }

        /// <summary>
        /// Gets the type of the device.
        /// </summary>
        DeviceType DeviceType { get; }
        /// <summary>
        /// Gets the status of the device.
        /// </summary>
        DeviceStatus DeviceStatus { get; }
    }
}
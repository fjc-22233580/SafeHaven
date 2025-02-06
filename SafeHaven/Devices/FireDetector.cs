using System;
using SafeHaven.Interfaces;

namespace SafeHaven.Devices
{
    /// <summary>
    /// Represents a fire detector device.
    /// </summary>
    /// <seealso cref="IDevice" />
    public sealed class FireDetector : IDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FireDetector"/> class.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="friendlyName"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceStatus"></param>
        public FireDetector(Guid guid, string friendlyName, DeviceType deviceType, DeviceStatus deviceStatus)
        {
            Id = guid;
            FriendlyName = friendlyName;
            DeviceType = deviceType;
            DeviceStatus = deviceStatus;
        }

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether smoke is detected.
        /// </summary>
        public bool IsSmokeDetected { get; set; }

        /// <summary>   
        /// Gets or sets the temperature.
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Gets a value indicating whether fire is detected.
        /// </summary>
        public bool IsFireDetected => IsSmokeDetected && Temperature > 50;

        #endregion

        #region IDevice Members

        /// <summary>
        /// Gets the unique identifier of the device.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the friendly name of the device.
        /// </summary>
        public string FriendlyName { get; }

        /// <summary>
        /// Gets the type of the device.
        /// </summary>
        public DeviceType DeviceType { get; }

        /// <summary>
        /// Gets the status of the device.
        /// </summary>
        public DeviceStatus DeviceStatus { get; }

        #endregion
    }
}
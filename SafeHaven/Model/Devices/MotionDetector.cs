using System;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model.Devices
{
    /// <summary>
    /// Represents a motion detector device.
    /// </summary>
    /// <seealso cref="IDevice" />
    public sealed class MotionDectector: IDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MotionDetector"/> class.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="friendlyName"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceStatus"></param>
        public MotionDectector(Guid guid, string friendlyName, DeviceType deviceType, DeviceStatus deviceStatus)
        {
            Id = guid;
            FriendlyName = friendlyName;
            DeviceType = deviceType;
            DeviceStatus = deviceStatus;
        }

         #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether motion is detected.
        /// </summary>
        public bool IsMotionDetected { get; set; }

        /// <summary>   
        /// Detects speed .
        /// </summary>
        public bool IsPersonPresent { get; set; }

        /// <summary>
        /// Gets a value indicating whether fire is detected.
        /// </summary>
        public bool IsMotionDetected => IsMotionDetected && IsPersonPresent > 50;

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

        /// <summary>
        /// Occurs when the device is triggered.
        /// </summary>
        public event EventHandler DeviceStateChanged;

        #endregion
    }
}
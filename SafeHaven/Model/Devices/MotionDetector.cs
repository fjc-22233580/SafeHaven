using System;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model.Devices
{
    /// <summary>
    /// Represents a motion detector device.
    /// </summary>
    /// <seealso cref="IDevice" />
    public sealed class MotionDetector : IDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MotionDetector"/> class.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="friendlyName"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceStatus"></param>
        public MotionDetector(Guid guid, string friendlyName, DeviceType deviceType)
        {
            Id = guid;
            FriendlyName = friendlyName;
            DeviceType = deviceType;
        }

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether motion is detected.
        /// </summary>
        public bool IsMotionDetected { get; set; }

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
        public DeviceStatus DeviceStatus
        {
            get
            {
                // If motion is detected, then the device is triggered
                if (IsMotionDetected)
                {
                    return DeviceStatus.Triggered;
                }
                else
                {
                    return DeviceStatus.Standby;
                }
            }
        }

        #endregion
    }
}
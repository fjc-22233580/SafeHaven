using System;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model.Devices;

/// <summary>
/// Represents a window or door sensor.
/// </summary>
public class WindowDoorSensor : IDevice
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowDoorSensor"/> class.
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="friendlyName"></param>
    /// <param name="deviceType"></param>
    /// <param name="deviceStatus"></param>
    public WindowDoorSensor(Guid guid, string friendlyName, DeviceType deviceType)
    {
        Id = guid;
        FriendlyName = friendlyName;
        DeviceType = deviceType;
    }


    #region Properties

    /// <summary>
    /// Gets or sets a value indicating whether the window or door is open.
    /// </summary>
    public bool IsOpen { get; set; }

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
            if (IsOpen)
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

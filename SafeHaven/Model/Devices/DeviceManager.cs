using System;
using System.Collections.Generic;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model.Devices;

public class DeviceManager
{
    #region Fields

    /// <summary>
    /// The list of devices.
    /// </summary>
    private readonly List<IDevice> devices = new List<IDevice>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets the devices.
    /// </summary>
    public List<IDevice> Devices => devices;

    /// <summary>
    /// Gets a value indicating whether home security is breached.
    /// </summary>
    public bool IsSecurityBreached { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the fire alarm can sound.
    /// </summary>
    public bool CanSoundFireAlarm { get; private set; }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the device.
    /// </summary>
    /// <param name="device"></param>
    public void AddDevice(IDevice device)
    {
        devices.Add(device);
    }

    /// <summary>
    /// Checks all devices and their current state and updates the security and fire alarm status.
    /// </summary>
    public void CheckDevices()
    {
        List<IDevice> securityDevices = devices.FindAll(d => d.DeviceType == DeviceType.MotionDetector || d.DeviceType == DeviceType.WindowDoorSensor);
        IsSecurityBreached = securityDevices.TrueForAll(d => d.DeviceStatus == DeviceStatus.Triggered);

        List<IDevice> fireDevices = devices.FindAll(d => d.DeviceType == DeviceType.FireDetector);
        CanSoundFireAlarm = fireDevices.TrueForAll(d => d.DeviceStatus == DeviceStatus.Triggered);
    }

    #endregion
}

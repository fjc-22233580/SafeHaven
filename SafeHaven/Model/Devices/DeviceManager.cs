using System;
using System.Collections.Generic;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model.Devices;

public class DeviceManager
{
    /// <summary>
    /// 
    /// </summary>
    private readonly List<IDevice> devices = new List<IDevice>();

    /// <summary>
    ///  Initializes a new instance of the <see cref="DeviceManager"/> class.
    /// </summary>
    /// <param name="devices"></param>
    public DeviceManager()
    {

    }

    /// <summary>
    /// Gets the devices.
    /// </summary>
    public List<IDevice> Devices => devices;

    /// <summary>
    /// Adds the device.
    /// </summary>
    /// <param name="device"></param>
    public void AddDevice(IDevice device)
    {
        devices.Add(device);
    }
}

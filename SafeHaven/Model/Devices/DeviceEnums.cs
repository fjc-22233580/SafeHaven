namespace SafeHaven.Model.Devices
{
    /// <summary>
    /// Enum for the type of device
    /// </summary>
    public enum DeviceType
    {
        Unkown,
        FireDetector,
        MotionDetector,
        WindowDoorSensor
    }

    /// <summary>
    ///  Enum for the status of the device
    /// </summary>
    public enum DeviceStatus
    {
        Unknown,
        Disconnected,
        Connected,
        Error,
        Standby,
        Triggered
    }
}
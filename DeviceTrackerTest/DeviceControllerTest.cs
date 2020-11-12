using DeviceTracker.Controllers;
using DeviceTracker.Interface;
using DeviceTracker.Model;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DeviceTrackerTest
{
    public class DeviceControllerTest
    {
        readonly DeviceController _deviceController;
        public DeviceControllerTest()
        {
            var mockDeviceService = new Mock<IDeviceRepository>();
            //mockDeviceService.Setup(x => x.GetDeviceData())
            _deviceController = new DeviceController(mockDeviceService.Object);
        }

        [Fact]
        public void GetAllDeviceData()
        {
            int 
        }

        private List<Device> GenerateDeviceData()
        {
            List<Device> deviceList = new List<Device>();

            Device device = new Device
            {
                Id = 1,
                DeviceId = 1,
                Data = 1
            };
            deviceList.Add(device);

            device = new Device
            {
                Id = 2,
                DeviceId = 1,
                Data = 2
            };
            deviceList.Add(device);

            device = new Device
            {
                Id = 3,
                DeviceId = 1,
                Data = 3
            };
            deviceList.Add(device);

            device = new Device
            {
                Id = 4,
                DeviceId = 1,
                Data = 4
            };
            deviceList.Add(device);

            device = new Device
            {
                Id = 5,
                DeviceId = 2,
                Data = 1
            };
            deviceList.Add(device);

            return deviceList;
        }
    }
}

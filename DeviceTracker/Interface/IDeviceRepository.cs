using DeviceTracker.Model;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceTracker.Interface
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetDeviceData(int? id);

        Task<List<Device>> GetDeviceFilter(int id, Operations operations, int value);

        void PostDeviceData(Device data);
    }
}

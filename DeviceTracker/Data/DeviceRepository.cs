using DeviceTracker.Interface;
using DeviceTracker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DeviceTracker.Data
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _dataContext;

        public DeviceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<List<Device>> GetDeviceData(int? id)
        {
            return _dataContext.Devices.Where(x => x.DeviceId == id).ToListAsync<Device>();
        }

        public Task<List<Device>> GetDeviceFilter(int id, Operations operations, int value)
        {
            if(operations.Equals(Operations.GreaterThan))
                return _dataContext.Devices.Where(x => x.DeviceId == id && x.Data > value).ToListAsync<Device>();
            else if (operations.Equals(Operations.LessThan))
                return _dataContext.Devices.Where(x => x.DeviceId == id && x.Data < value).ToListAsync<Device>();
            return _dataContext.Devices.Where(x => x.DeviceId == id && x.Data == value).ToListAsync<Device>();
        }

        public void PostDeviceData(Device data)
        {
            _dataContext.Devices.AddAsync(data);
            _dataContext.SaveChangesAsync();
        }
    }
}

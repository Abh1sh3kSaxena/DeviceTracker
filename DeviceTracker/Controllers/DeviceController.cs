using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceTracker.Interface;
using DeviceTracker.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeviceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        // GET: api/<DeviceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeviceController>/5
        [Route("{id}/data")]
        public async Task<IEnumerable<Device>> Get(int id)
        {
           return await _deviceRepository.GetDeviceData(id);  
        }

        [Route("{id}/filter")]
        public async Task<IEnumerable<Device>> GetFilter(int id,[FromQuery] string data)
        {
            string s = String.Empty;
            if(data != null)
            {
                int value = int.Parse(data);
                return await _deviceRepository.GetDeviceFilter(id, Operations.Equal, value);
            }
            if (Request.QueryString.HasValue)
            {
                s = Request.QueryString.Value;
                if (s.Contains("%3E"))
                {
                    int value = int.Parse(s.Split("%3E")[1]);
                    return await _deviceRepository.GetDeviceFilter(id, Operations.GreaterThan,value );
                }
                else if (s.Contains("%3C"))
                {
                    int value = int.Parse(s.Split("%3C")[1]);
                    return await _deviceRepository.GetDeviceFilter(id, Operations.LessThan, value);
                }
            }
            return await _deviceRepository.GetDeviceData(id);
        }
        // POST api/<DeviceController>
        [Route("{id}/data")]
        [HttpPost]
        public  void Post([FromBody] Device device)
        {
             _deviceRepository.PostDeviceData(device);
        }

       
    }
}

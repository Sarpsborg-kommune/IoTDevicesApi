using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IoTDevicesApi.Models;

namespace IoTDevicesApi.Controllers
{
    [ApiController]
    public class dbController : ControllerBase
    {
        private readonly IoTDevicesContext _context;

        public dbController(IoTDevicesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("db")]
        public async Task<ActionResult<IEnumerable<IoTDevice>>> GetIoTDevices()
        {
            return await _context.IoTDevices.ToListAsync();
        }

        [HttpGet("{id}")]
        [Route("db")]
        public async Task<ActionResult<IoTDevice>> GetIoTDevices(string id)
        {
            var ioTDevicesItem = await _context.IoTDevices.FindAsync(id);

            if (ioTDevicesItem == null)
            {
                return NotFound();
            }

            return ioTDevicesItem;
        }

        [HttpPut("{id}")]
        [Route("db")]
        public async Task<IActionResult> PutIoTDevices(string id, IoTDevice ioTDevice)
        {
            if (id != ioTDevice.id)
            {
                return BadRequest();
            }

            _context.Entry(ioTDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IoTDeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [Route("db")]
        public async Task<ActionResult<IoTDevice>> PostIoTDevices(IoTDevice ioTDevice)
        {
            _context.IoTDevices.Add(ioTDevice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IoTDeviceExists(ioTDevice.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIoTDevices", new { id = ioTDevice.id }, ioTDevice);
        }

        [HttpDelete("{id}")]
        [Route("db")]
        public async Task<IActionResult> DeleteIoTDevice(string id)
        {
            var ioTDevice = await _context.IoTDevices.FindAsync(id);
            if (ioTDevice == null)
            {
                return NotFound();
            }

            _context.IoTDevices.Remove(ioTDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("db/count")]
        public async Task<string> GetIoTDevicesCount()
        {
            int count = await _context.IoTDevices.CountAsync();
            return "{\"count\": " + count + "}";
        }

        private bool IoTDeviceExists(string id)
        {
            return _context.IoTDevices.Any(e => e.id == id);
        }
    }
}

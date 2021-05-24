using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderTrackingService.Data;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderTrackingService.Entities;

namespace OrderTrackingService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderInfoController : Controller
    {
        public DataContext _context { get; }
        public OrderInfoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderInfo>> GetAll()
        {
            try
            {
                return Ok(_context.Orders);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrive entities: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderInfo>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(GetById)} id must not be empty");
            }
            try
            {
                return Ok(await _context.FindAsync<OrderInfo>(id));
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrive entity: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrderInfo>> UpdateAsync(OrderInfo order)
        {
            if (order == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }
            try
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return Ok(order);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(UpdateAsync)} could not be update:{ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<OrderInfo>> DeleteAsync(OrderInfo order)
        {
            if( order == null )
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }
            try
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
                return Ok(order);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(DeleteAsync)} could not be deleted:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderInfo>> CreateAsync(OrderInfo order)
        {
            if (order == null)
            {
                throw new ArgumentNullException($"{nameof(CreateAsync)} entity must not be null");
            }
            try
            {
                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(CreateAsync)} could not be saved:{ex.Message}");
            }
        }
    }
}

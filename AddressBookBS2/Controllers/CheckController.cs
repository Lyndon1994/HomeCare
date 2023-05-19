﻿using HomeCare.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly HomeCareContext _context;

        public CheckController(HomeCareContext context)
        {
            _context = context;
        }

        // GET: api/<CheckController>
        [HttpGet]
        public async Task<string> GetAsync()
        {
            // check if the status of entity is 1
            if (_context.Fall == null)
            {
                return "系统错误";
            }
            var fall = await _context.Fall
                .FirstOrDefaultAsync(m => m.Status == 1).ConfigureAwait(false);
            if (fall == null)
            {
                return "";
            }

            var user = await _context.Zhanghu.FindAsync(fall.Id).ConfigureAwait(false);
            if (user == null)
            {
                return $"没有找到这个编号: {fall.Id}";
            }
            else
            {
                return $"{user.Username} 摔倒\n联系电话：{user.Phone}\n子女电话：{user.Phone_zinv}\n子女名称：{user.Zinv_name}\n老人地址：{user.Address}\n年龄：{user.Age}\n编号：{user.Id}";
            }
        }

        [HttpPut("{id}")]
        public async Task<string> PutAsync(int id)
        {
            var fall = await _context.Fall.FindAsync(id).ConfigureAwait(false);
            if (fall == null)
            {
                return "未找到这个编号";
            }
            fall.Status = 0;
            _context.Entry(fall).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FallExists(id))
                {
                    return "未找到这个编号";
                }
                else
                {
                    throw;
                }
            }
            return "success";
        }

        private bool FallExists(int id)
        {
            return (_context.Fall?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

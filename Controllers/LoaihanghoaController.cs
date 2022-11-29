using API_hienchanel.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_hienchanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaihanghoaController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaihanghoaController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAlls()
        {
            var dsLoai = _context.loais.ToList();
            return Ok(
                new { 
                    message= "lay danh sach thanh cong", 
                    data = dsLoai,
                });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var dsLoai = _context.loais.SingleOrDefault(lo => lo.MaLoai.ToString() == id);
            if (dsLoai == null) return NotFound();
            return Ok(dsLoai);
        }
        [HttpPost("{id}")]
        public IActionResult CreateNew()
        {
            return null;
        }
    }
}

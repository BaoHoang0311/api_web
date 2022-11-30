using API_hienchanel.Data;
using API_hienchanel.Model;
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

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new LoaiHangHoa()
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {
            var loai = _context.loais.SingleOrDefault(lo=> lo.MaLoai==id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}

/*
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHangHoassssController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiHangHoassssController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/LoaiHangHoassss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiHangHoa>>> Getloais()
        {
            return await _context.loais.ToListAsync();
        }

        // GET: api/LoaiHangHoassss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiHangHoa>> GetLoaiHangHoa(int id)
        {
            var loaiHangHoa = await _context.loais.FindAsync(id);

            if (loaiHangHoa == null)
            {
                return NotFound();
            }

            return loaiHangHoa;
        }

        // PUT: api/LoaiHangHoassss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiHangHoa(int id, LoaiHangHoa loaiHangHoa)
        {
            if (id != loaiHangHoa.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loaiHangHoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiHangHoaExists(id))
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

        // POST: api/LoaiHangHoassss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiHangHoa>> PostLoaiHangHoa(LoaiHangHoa loaiHangHoa)
        {
            _context.loais.Add(loaiHangHoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiHangHoa", new { id = loaiHangHoa.MaLoai }, loaiHangHoa);
        }

        // DELETE: api/LoaiHangHoassss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiHangHoa(int id)
        {
            var loaiHangHoa = await _context.loais.FindAsync(id);
            if (loaiHangHoa == null)
            {
                return NotFound();
            }

            _context.loais.Remove(loaiHangHoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiHangHoaExists(int id)
        {
            return _context.loais.Any(e => e.MaLoai == id);
        }
    }
*/
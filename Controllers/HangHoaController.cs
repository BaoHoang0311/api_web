using API_hienchanel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_hienchanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> listHanghHoa = new List<HangHoa>()
        {
            new HangHoa{MaHangHoa = Guid.NewGuid(), TenHangHoa ="ao mua", Dongia ="100" },
            new HangHoa{MaHangHoa = Guid.NewGuid(), TenHangHoa ="ao mua1", Dongia ="1001"},
            new HangHoa{MaHangHoa = Guid.NewGuid(), TenHangHoa ="ao mua2", Dongia ="1002" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<HangHoa>> GetAlls()
        {
            //return Ok(listHanghHoa);
            return listHanghHoa;
        }
        [HttpPost]
        public IActionResult Create(HanghoaVM hanghoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoaVM.TenHangHoa,
                Dongia = hanghoaVM.Dongia,
            };
            listHanghHoa.Add(hanghoa);

            return Ok(new
            {
                Success = true,
                HAHA = "hihi",
                DATA = listHanghHoa,
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hanghoaid = listHanghHoa.FindAll(x => x.MaHangHoa == Guid.Parse(id));
                if (hanghoaid == null || hanghoaid.Count()==0) return NotFound();
                return Ok(hanghoaid);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("ten")]
        public IActionResult GetByTen(string ten)
        {
            try
            {
                var hangHoaTen = listHanghHoa.FindAll(x => x.TenHangHoa == ten);
                if (hangHoaTen == null || hangHoaTen.Count() == 0) return NotFound();
                return Ok(hangHoaTen);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateId(string id, HanghoaVM hhVM)
        {
            try
            {
                var hangHoaTen = listHanghHoa.FirstOrDefault(x => x.MaHangHoa.ToString() == id); // null
                if (hangHoaTen == null) return NotFound();
                
                if (Guid.TryParse(id, out Guid results)==false)
                {
                    return NotFound();
                }

                hangHoaTen.TenHangHoa = hhVM.TenHangHoa;
                hangHoaTen.Dongia = hhVM.Dongia;
                return Ok(listHanghHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove (string id)
        {
            try
            {
                var hangHoaTen = listHanghHoa.FirstOrDefault(x => x.MaHangHoa.ToString() == id); // null
                if (hangHoaTen == null) return NotFound();
                listHanghHoa.Remove(hangHoaTen);
                return Ok(
                    new
                    {
                        Message= "xóa thành công",
                        data =listHanghHoa,
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("Deletetheoten/{ten}")]
        public IActionResult RemovebyName(string ten)
        {
            try
            {
                var hanghoaTen = listHanghHoa.FirstOrDefault(x => x.TenHangHoa.ToString() == ten);
                if (hanghoaTen == null) return NotFound();

                listHanghHoa.Remove(hanghoaTen);
                if(listHanghHoa.Count()== 0)
                {
                    return Ok(
                        new
                        {
                            Message= "danh sach rong",
                        });
                }
                return Ok(
                    new
                    {
                        Message = "xóa theo tên thành công",
                        data = listHanghHoa,
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

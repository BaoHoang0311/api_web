using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_hienchanel.Data
{
    [Table("Loai")]
    public class LoaiHangHoa
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        public string TenLoai { get; set; }
        
        public virtual ICollection<HangHoa> hanghoa { get; set; }
    }
}

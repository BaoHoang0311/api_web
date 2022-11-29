using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_hienchanel.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Mahh { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenHH { get; set; }
        public string Moto { get; set; }
        [Range(0,double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamgGia { get; set; }

        // Foreign key
        public int MaLoai { get; set; } // không cho null
        [ForeignKey("MaLoai")]
        public LoaiHangHoa Loai { get; set; }

    }
}

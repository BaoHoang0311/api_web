using System;

namespace API_hienchanel.Model
{
    public class HanghoaVM
    {
        public string TenHangHoa { get; set; }
        public string Dongia { get; set; }
    }
    public class HangHoa : HanghoaVM
    {
        public Guid MaHangHoa { get; set; }
    }
}

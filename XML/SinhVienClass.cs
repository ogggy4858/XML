using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    public class SinhVienClass
    {
        private string maSinhVien;
        private string hoTen;
        private DateTime ngaySinh;
        private string lop;

        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Lop { get => lop; set => lop = value; }

        public SinhVienClass(string maSinhVien, string hoTen, DateTime ngaySinh, string lop)
        {
            MaSinhVien = maSinhVien;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            Lop = lop;
        }

        public SinhVienClass() { }

        public SinhVienClass(DataRow row)
        {
            MaSinhVien = row["MaSinhVien"].ToString();
            HoTen = row["HoTen"].ToString();
            NgaySinh = Convert.ToDateTime(row["NgaySinh"]);
            Lop = row["Lop"].ToString();
        }
    }
}

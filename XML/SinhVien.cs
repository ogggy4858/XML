using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace XML
{
    public partial class SinhVien : Form
    {
        private string ma = "";

        public SinhVien()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //combobox
            cbbLop.Items.Add("LTMT1");
            cbbLop.Items.Add("QTM");
            cbbLop.Items.Add("TKDH");
            cbbLop.Items.Add("KT");
            cbbLop.Items.Add("TK");
            //listView
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Ma Sinh Vien", 150);
            listView1.Columns.Add("Ho Ten", 200);
            listView1.Columns.Add("ngay Sinh", 150);
            listView1.Columns.Add("Lop", 150);
            //SinhVienDAO dao = new SinhVienDAO();
            //List<SinhVienClass> listSV = dao.Load();
            //foreach (var item in listSV)
            //{
            //    ListViewItem it = new ListViewItem(item.MaSinhVien);
            //    it.SubItems.Add(item.HoTen);
            //    it.SubItems.Add(item.NgaySinh.ToShortDateString());
            //    it.SubItems.Add(item.Lop);
            //    listView1.Items.Add(it);
            //}

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            
            SinhVienClass sv = new SinhVienClass(tbMaSinhVien.Text, tbHoTen.Text
                , Convert.ToDateTime(dtpNgaySinh.Text), cbbLop.Text);
            SinhVienDAO dao = new SinhVienDAO();
            dao.Them(sv);
            SinhVien_Load(sender, e);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SinhVienClass sv = new SinhVienClass(tbMaSinhVien.Text, tbHoTen.Text
               , Convert.ToDateTime(dtpNgaySinh.Text), cbbLop.Text);
            SinhVienDAO dao = new SinhVienDAO();
            dao.Sua(sv);
            SinhVien_Load(sender, e);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            SinhVienClass sv = new SinhVienClass();
            sv.MaSinhVien = tbMaSinhVien.Text;
            SinhVienDAO dao = new SinhVienDAO();
            dao.Xoa(sv);
            SinhVien_Load(sender, e);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {

        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SinhVienDAO dao = new SinhVienDAO();
            List<SinhVienClass> listSV = dao.Load();
            foreach (var item in listSV)
            {
                ListViewItem it = new ListViewItem(item.MaSinhVien);
                it.SubItems.Add(item.HoTen);
                it.SubItems.Add(item.NgaySinh.ToShortDateString());
                it.SubItems.Add(item.Lop);
                listView1.Items.Add(it);
            }
        }

        private void SinhVien_MouseClick(object sender, MouseEventArgs e)
        {
            SinhVien_Load(sender, e);

        }

        private void btSearch_Click(object sender, EventArgs e)
        {

            SinhVienDAO dao = new SinhVienDAO();
            var list = dao.Search(tbSearch.Text);
            listView1.Items.Clear();

            foreach (var item in list)
            {
                ListViewItem it = new ListViewItem(item.MaSinhVien);
                it.SubItems.Add(item.HoTen);
                it.SubItems.Add(item.NgaySinh.ToShortDateString());
                it.SubItems.Add(item.Lop);
                listView1.Items.Add(it);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}

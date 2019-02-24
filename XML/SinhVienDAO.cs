using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace XML
{
    public class SinhVienDAO
    {
        private XmlDocument doc = new XmlDocument();
        XmlTextWriter write;
        private XmlElement root;
        private string FileName = @"H:\project\c#\Wfrom\XML\XML\bin\Debug\sinhvien.xml";
        public SinhVienDAO()
        {
            if (File.Exists(FileName))
            {
                doc.Load(FileName);
                root = doc.DocumentElement;
            }
            else
            {
                write = new XmlTextWriter("sinhvien.xml", System.Text.Encoding.UTF8);
                write.WriteStartDocument(true);
                write.Formatting = Formatting.Indented;
                write.Indentation = 2;
                write.WriteStartElement("root");
                write.WriteEndElement();
                write.WriteEndDocument();
                write.Close();

                doc.Load(FileName);
                root = doc.DocumentElement;
            }
        }
        private bool Check(XmlNode xNode, string MaSinhVien)
        {
            xNode = root.SelectSingleNode("SinhVien[MaSinhVien='" + MaSinhVien + "']");
            if (xNode != null)
                return true;
            else
                return false;
        }
        public void Them(SinhVienClass sv)
        {
            XmlElement SinhVien = doc.CreateElement("SinhVien");

            XmlElement MaSV = doc.CreateElement("MaSinhVien");
            if (Check(MaSV, sv.MaSinhVien))
            {}
            else
            {
                MaSV.InnerText = sv.MaSinhVien;
                SinhVien.AppendChild(MaSV);

                XmlElement HoTen = doc.CreateElement("HoTen");
                HoTen.InnerText = sv.HoTen;
                SinhVien.AppendChild(HoTen);

                XmlElement NgaySinh = doc.CreateElement("NgaySinh");
                NgaySinh.InnerText = sv.NgaySinh.ToShortDateString();
                SinhVien.AppendChild(NgaySinh);

                XmlElement Lop = doc.CreateElement("Lop");
                Lop.InnerText = sv.Lop;
                SinhVien.AppendChild(Lop);

                root.AppendChild(SinhVien);
                doc.Save(FileName);
            }

          
        }
        public void Sua(SinhVienClass sv)
        {
            XmlNode NodeOld = root.SelectSingleNode("SinhVien[MaSinhVien='" + sv.MaSinhVien + "']");
   
            if(NodeOld != null)
            {
                XmlNode NodeNew = doc.CreateElement("SinhVien");

                //if (Check(NodeNew, sv.MaSinhVien))
                //{
                    XmlElement MaSV = doc.CreateElement("MaSinhVien");
                    MaSV.InnerText = sv.MaSinhVien;
                    NodeNew.AppendChild(MaSV);

                    XmlElement HoTen = doc.CreateElement("HoTen");
                    HoTen.InnerText = sv.HoTen;
                    NodeNew.AppendChild(HoTen);

                    XmlElement NgaySinh = doc.CreateElement("NgaySinh");
                    NgaySinh.InnerText = sv.NgaySinh.ToShortDateString();
                    NodeNew.AppendChild(NgaySinh);

                    XmlElement Lop = doc.CreateElement("Lop");
                    Lop.InnerText = sv.Lop;
                    NodeNew.AppendChild(Lop);

                    root.ReplaceChild(NodeNew, NodeOld);
                    doc.Save(FileName);
                //}
            }
        }
        public void Xoa(SinhVienClass sv)
        {
            XmlNode nodeDelete = root.SelectSingleNode("SinhVien[MaSinhVien='" + sv.MaSinhVien  + "']");
            if (nodeDelete != null)
            {
                root.RemoveChild(nodeDelete);
                doc.Save(FileName);
               

            }
        }

        public List<SinhVienClass> Search(string input)
        {
            var node = root.SelectNodes("SinhVien[MaSinhVien='" + input + "']");
            List<SinhVienClass> listSV = new List<SinhVienClass>();
            if (node.Count > 0)
            {
             
                for (int i = 0; i < node.Count; i++)
                {
                    SinhVienClass sv = new SinhVienClass(
                        node[i].ChildNodes.Item(0).InnerText.Trim(),
                        node[i].ChildNodes.Item(1).InnerText.Trim(),
                        Convert.ToDateTime(node[i].ChildNodes.Item(2).InnerText.Trim()),
                        node[i].ChildNodes.Item(3).InnerText.Trim()
                        );
                    listSV.Add(sv);
                }
            }
            return listSV;
        }

        public List<SinhVienClass> Load()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList list;
            FileStream fs = new FileStream("sinhvien.xml", FileMode.Open, FileAccess.ReadWrite);
            xmldoc.Load(fs);
            fs.Close();
            list = xmldoc.GetElementsByTagName("SinhVien");
            List<SinhVienClass> ListSV = new List<SinhVienClass>();
            for (int i = 0; i < list.Count ; i++)
            {
                SinhVienClass cl = new SinhVienClass(list[i].ChildNodes.Item(0).InnerText.Trim(),
                     list[i].ChildNodes.Item(1).InnerText.Trim(),
                      Convert.ToDateTime(list[i].ChildNodes.Item(2).InnerText),
                       list[i].ChildNodes.Item(3).InnerText.Trim()
                    );
                ListSV.Add(cl);
            }
            return ListSV;
        }
    }
}

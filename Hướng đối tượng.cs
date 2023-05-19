using System;
using System.IO;
using static System.Console;
using System.Diagnostics;
using System.Collections;
using System.Security.Cryptography;

public class SinhVien
{
    public int _iD;
    public string _hoTen;
    public string _gioiTinh;

    private int _tuoi;
    private double _diemCSharp;
    private double _diemUnity;
    private double _diem3D;

    private double _diemTrungBinh;
    private string _xepLoai;

    public int Tuoi
    {
        get { return _tuoi; }
        set
        {
            if (value > 0) _tuoi = value;
            else WriteLine("Du lieu khong hop le.");
        }
    }
    
    public double DiemCSharp
    {
        get { return _diemCSharp; }
        set
        {
            if (value >= 0) _diemCSharp = value;
            else WriteLine("Du lieu khong hop le.");
        }
    }
    
    public double DiemUnity
    {
        get { return _diemUnity; }
        set
        {
            if (value >= 0) _diemUnity = value;
            else WriteLine("Du lieu khong hop le.");
        }
    }
    
    public double Diem3D
    {
        get { return _diem3D; }
        set
        {
            if (value >= 0) _diem3D = value;
            else WriteLine("Du lieu khong hop le.");
        }
    }

    public double DiemTrungBinh
    {
        get { return _diemTrungBinh;}
    }

    public string XepLoai
    {
        get { return _xepLoai;}
    }


    public SinhVien(int id)
    {
        _iD = id;
        _hoTen = "";
        _gioiTinh = "";
        _tuoi = 0;
        _diemCSharp = 0;
        _diemUnity = 0;
        _diem3D = 0;
        _diemTrungBinh = 0;
        _xepLoai = "";
    }
    public void TinhDiemTB()
    {
        _diemTrungBinh =  Math.Round(((_diemCSharp + _diem3D + _diemUnity)/3),2);
    }

    public void TinhXepLoai()
    {
        //Write("Xep loai: ");
        if (_diemTrungBinh >= 8 && _diemTrungBinh <=10)
        {
            //WriteLine("Gioi");
            _xepLoai = "Gioi";
        }
        else if ( _diemTrungBinh >=6.5 )
        {
            //WriteLine("Kha");
            _xepLoai = "Kha";
        }
        else if (_diemTrungBinh >= 5)
        {
            //WriteLine("Trung binh");
            _xepLoai = "Trung binh";
        }
        else
        {
            //WriteLine("Yeu");
            _xepLoai = "Yeu";
        }
    }

}

public class QuanLySinhVien
{
    List<SinhVien> sinhViens = new List<SinhVien>();

    public void ThemSinhVien()
    {
        sinhViens.Add(new SinhVien(sinhViens.Count+1));
    }

    public void CapNhatThongTinSinhVien()
    {        
        int id;
        while (true)
        {
            id = sinhViens.Count -1 ;
            id++;
            break;
        }
        WriteLine("ID cua sinh vien: " + id);
        int vitricansua = 0;

        for (int i = 0; i < sinhViens.Count; i++)
        {
            if (sinhViens[i]._iD == id)
            {
                vitricansua = i;
                break;
            }
        }
        Write("Hay nhap ten cua sinh vien: ");
        sinhViens[vitricansua]._hoTen = ReadLine();
        Write("Hay nhap gioi tinh cua sinh vien: ");
        sinhViens[vitricansua]._gioiTinh = ReadLine();

        Write("Hay nhap tuoi cua sinh vien: ");
        sinhViens[vitricansua].Tuoi = Convert.ToInt32(ReadLine());
       
        Write("Hay nhap diem C sharp cua sinh vien: ");
        sinhViens[vitricansua].DiemCSharp = Convert.ToDouble(ReadLine());

        Write("Hay nhap diem Unity cua sinh vien: ");
        sinhViens[vitricansua].DiemUnity = Convert.ToDouble(ReadLine());

        Write("Hay nhap diem 3D cua sinh vien: ");
        sinhViens[vitricansua].Diem3D = Convert.ToDouble(ReadLine());

        sinhViens[vitricansua].TinhDiemTB();
        sinhViens[vitricansua].TinhXepLoai();

        WriteLine("Dem trung binh cua sinh vien: " + sinhViens[vitricansua].DiemTrungBinh);

        WriteLine("Xep loai cua sinh vien: " + sinhViens[vitricansua].XepLoai);
    }
    public void XoaSinhVienTheoID()
    {
        WriteLine("Nhap ID can xoa: ");
        int xoaID = Convert.ToInt32(ReadLine());
        for (int i = 0; i < sinhViens.Count; i++)
        {
            if (sinhViens[i]._iD == xoaID)
            {
                sinhViens.RemoveAt(i);
                break;
            }
        }
        WriteLine("Sinh vien da bi xoa");
    }
    public void TimKiemSinhVienTheoTen()
    {
        Write("Hay nhap ten sinh vien can tim kiem: ");
        string timTen = ReadLine();
        for (int i = 0; i <  sinhViens.Count; i++)
        {
            if (sinhViens[i]._hoTen == timTen)
            {   
                WriteLine("Sinh vien can tim la: ");
                Write("\nMa so ID: " + sinhViens[i]._iD);
                Write("\nHo ten: " + timTen);
                Write("\nTuoi: " + sinhViens[i].Tuoi);
                Write("\nGioi tinh: " + sinhViens[i]._gioiTinh);
                Write("\nDiem C#: " + sinhViens[i].DiemCSharp, " Diem Unity: " + sinhViens[i].DiemUnity, " Diem 3D " + sinhViens[i].Diem3D);
                Write("\nDiem trung binh: " + sinhViens[i].DiemTrungBinh);
                WriteLine("\nXep loai hoc luc: " + sinhViens[i].XepLoai);
            }
        }
    }
    public void TimKiemSinhVienTheoID()
    {
        Write("Hay nhap ID sinh vien can tim kiem: ");
        int timID = Convert.ToInt32(ReadLine());
        for (int i = 0; i < sinhViens.Count; i++)
        {
            if (sinhViens[i]._iD == timID )
            {
                WriteLine("Sinh vien can tim la: ");
                Write("\nMa so ID: " + timID);
                Write("\nHo ten: " + sinhViens[i]._hoTen);
                Write("\nTuoi: " + sinhViens[i].Tuoi);
                Write("\nGioi tinh: " + sinhViens[i]._gioiTinh);
                Write("\nDiem C#: " + sinhViens[i].DiemCSharp  + " Diem Unity: " + sinhViens[i].DiemUnity + " Diem 3D " + sinhViens[i].Diem3D);
                Write("\nDiem trung binh: " + sinhViens[i].DiemTrungBinh);
                WriteLine("\nXep loai hoc luc: " + sinhViens[i].XepLoai);
            }
        }
    }
    public void SapXepSinhVienTheoDiemTB()
    {
        int vitricansua = 0;

        for (int i = 0; i < sinhViens.Count; i++)
        {
            if (sinhViens[i].DiemTrungBinh == sinhViens[vitricansua].DiemTrungBinh)
            {
                vitricansua = i;
                break;
            }
        }
        sinhViens[vitricansua].TinhDiemTB();
        for (int i =0; i < sinhViens.Count; i++)
        {
            for (int j = i + 1; j < sinhViens.Count; j++)
            {
                if (sinhViens[j].DiemTrungBinh <= sinhViens[i].DiemTrungBinh)
                {
                    var tmp = sinhViens[j];
                    sinhViens[j] = sinhViens[i];
                    sinhViens[i] = tmp;
                }
            }
        }
        WriteLine("Danh sach sinh vien sau khi sap xep theo diem trung binh: ");
        Print();
    }
    
    public void SapXepSinhVienTheoTen()
    {
        int index1 = 0;
        for (int i = 0; i < sinhViens.Count; i++)
        {
            if (sinhViens[i]._hoTen == sinhViens[index1]._hoTen)
            {
                index1 = i;
                break;
            }
        }
        for (int i = 0; i < sinhViens.Count; i++)
        {
            for (int j = i+1; j < sinhViens.Count; j++)
            {
                if (String.Compare(sinhViens[j]._hoTen, sinhViens[i]._hoTen) < 0)
                {
                    var tmp = sinhViens[j];
                    sinhViens[j] = sinhViens[i];
                    sinhViens[i] = tmp;
                }
            }
        }
        WriteLine("Danh sach sinh vien sau khi sap xep theo ten: ");
            Print();       
    }
    public void SapXepSinhVienTheoID()
    {
        int index2 = 0;
        for (int i = 0; i < sinhViens.Count; i++)
        {
            if (sinhViens[i]._iD == index2)
            {
                index2 = i;
                break;
            }
        }
        for (int i = 0; i < sinhViens.Count; i++)
        {
            for (int j = i + 1; j < sinhViens.Count; j++)
            {
                if (sinhViens[j]._iD <= sinhViens[i]._iD)
                {
                    var tmp = sinhViens[j];
                    sinhViens[j] = sinhViens[i];
                    sinhViens[i] = tmp;
                }
            }
        }
        WriteLine("Danh sach sinh vien sau khi sap xep theo ID: ");
        Print();
    }


    public void Print()
    {
        for (int i = 0; i < sinhViens.Count; i++)
        {
            WriteLine("Hien thi danh sach sinh vien: ");
            Write("\nMa so ID: " + sinhViens[i]._iD);
            Write("\nHo ten: " + sinhViens[i]._hoTen);
            Write("\nTuoi: " + sinhViens[i].Tuoi);
            Write("\nGioi tinh: " + sinhViens[i]._gioiTinh);
            Write("\nDiem C#: " + sinhViens[i].DiemCSharp + " Diem Unity: " + sinhViens[i].DiemUnity + " Diem 3D " + sinhViens[i].Diem3D);
            Write("\nDiem trung binh: " + sinhViens[i].DiemTrungBinh);
            WriteLine("\nXep loai hoc luc: " + sinhViens[i].XepLoai);
        }
    }
}

public class Program
{
    public static void Main()
    {
        QuanLySinhVien quanLySinhVien = new QuanLySinhVien();

        while(true)
        {
            Write("Chao Mung Ban Den Voi Chuong Trinh Quan Ly Sinh Vien: \n");
            WriteLine("An so 1 de them sinh vien. \n" +
                  "An so 2 de cap nhat thong tin sinh vien. \n" + 
                  "An so 3 de xoa sinh vien theo ID. \n" +
                  "An so 4 de tim kiem sinh vien theo ten. \n" +
                  "An so 5 de tim kiem sinh vien theo ID. \n" +
                  "An so 6 de sap xep nhan vien theo diem trung binh. \n" +
                  "An so 7 de sap xep nhan vien theo ten. \n" +
                  "An so 8 de sap xep nhan vien theo ID. \n" +
                  "An so 9 de hien thi danh sach sinh vien. \n" +
                  "An so 10 de thoat chuong trinh. \n");

            Write("So ma ban chon la: ");
            int x = Convert.ToInt32(ReadLine());
            bool thoat = false;

            switch(x)
            {
                case 1:
                    quanLySinhVien.ThemSinhVien();
                    break;
                case 2:
                    quanLySinhVien.CapNhatThongTinSinhVien();
                    break;
                case 3:
                    quanLySinhVien.XoaSinhVienTheoID();
                    break;
                case 4:
                    quanLySinhVien.TimKiemSinhVienTheoTen();
                    break;
                case 5:
                    quanLySinhVien.TimKiemSinhVienTheoID();
                    break;
                case 6:
                    quanLySinhVien.SapXepSinhVienTheoDiemTB();
                    break;
                case 7:
                    quanLySinhVien.SapXepSinhVienTheoTen();
                    break;
                case 8:
                    quanLySinhVien.SapXepSinhVienTheoID();
                    break;
                case 9:
                    quanLySinhVien.Print();
                    break;
                case 10:
                    thoat = true;
                    break;
                default:
                    Write("Ban nhap sai so roi, hay nhap lai.");
                    break;
            }

            Thread.Sleep(2000);

            if (thoat)
                break;
        }
    }
}

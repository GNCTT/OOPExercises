using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            CanBo canBo = new NhanVien("Nguyen Van A", "Do somthing");
            CanBo canBo1 = new KySu("Nguyen Van B", "IT");
            CanBo canBo2 = new CongNhan("Nguyen Van C", 5);
            CanBo canBo3 = new NhanVien("Nguyen Van D", "Clean");

            quanLyNhanVien.Add(canBo, canBo1, canBo2, canBo3);
            CanBo nv = quanLyNhanVien.GetCanBoByName("Nguyen Van C");
            nv.Introduce();
        }
    }
}

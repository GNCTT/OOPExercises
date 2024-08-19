using System;
using System.ComponentModel;
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
            HandleInput hanleInput = new HandleInput();
            
            while (true)
            {
                Console.WriteLine("App Manage Officer:");
                Console.WriteLine("Type 1 to add Worker");
                Console.WriteLine("Type 2 to add Engineer");
                Console.WriteLine("Type 3 to add Stuff");
                Console.WriteLine("Type 4 to find ofiicer by name");
                Console.WriteLine("Type 5 to show all officer infomation");
                Console.WriteLine("Type 6 to close app");
                string cmd = Console.ReadLine();
                switch(cmd)
                {
                    case "1":
                        {
                            CanBo worker = new CongNhan();
                            worker.GetDataFromInput();
                            quanLyNhanVien.Add(worker);
                            break;
                        }
                    case "2":
                        {
                            CanBo engineer = new KySu();
                            engineer.GetDataFromInput();
                            quanLyNhanVien.Add(engineer);
                            break;
                        }
                    case "3":
                        {
                            CanBo stuff = new NhanVien();
                            stuff.GetDataFromInput();
                            quanLyNhanVien.Add(stuff);
                            break;
                        }
                    case "4":
                        {
                            string nameInput = hanleInput.TypeName();
                            var canbo = quanLyNhanVien.GetCanBoByName(nameInput);
                            if (canbo != null)
                            {
                                Console.WriteLine(canbo.ToString());
                            }
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("List Officer: ");
                            var canbos = quanLyNhanVien.GetListCanbo();
                            foreach (var canbo in canbos)
                            {
                                Console.WriteLine(canbo.ToString());
                            }
                            break;
                        }
                    default:
                        break;
                }
                if (cmd == "6")
                {
                    break;
                }
                Console.WriteLine("----------------------");
            }
        }

    }
}

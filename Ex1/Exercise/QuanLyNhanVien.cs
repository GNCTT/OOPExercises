using System;
using System.Collections.Generic;

namespace Exercise
{
    public class QuanLyNhanVien
    {
        private readonly List<CanBo> _canBos;

        public QuanLyNhanVien()
        {
            _canBos = new List<CanBo>();
        }

        public void Add(CanBo canBo)
        {
            _canBos.Add(canBo);
        }

        public void Add(params CanBo[] listCanbo)
        {
            foreach (var canbo in listCanbo)
            {
                _canBos.Add(canbo);
            }
        }

        public CanBo GetCanBoByName(string hoTen)
        {
            foreach (var canbo in _canBos)
            {
                if (canbo.HoTen.Equals(hoTen))
                {
                    return canbo;
                }
            }
            Console.WriteLine("No Canbo Have Name Like That");
            return null;
        }

        public IEnumerable<CanBo> GetListCanbo()
        {
            return _canBos;
        }

        public void ExitApp()
        {
            Console.WriteLine("Exit App");
        }
    }
}

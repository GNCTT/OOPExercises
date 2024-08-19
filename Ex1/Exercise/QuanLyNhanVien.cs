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
            if (canBo != null)
            {
                _canBos.Add(canBo);
                Console.WriteLine("Add {0} Succesfully.", canBo.ToString());
            }
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
            Console.WriteLine("No Ofiicer Have Name Like That");
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

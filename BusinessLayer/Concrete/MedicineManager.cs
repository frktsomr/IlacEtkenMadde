using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MedicineManager:IMedicineService
    {
        IMedicineDal _medicineDal;
        public MedicineManager(IMedicineDal medicineDal)
        {
            _medicineDal = medicineDal;
        }

        public List<Medicine> GetList()
        {
           return   _medicineDal.List();
        }
    }
}

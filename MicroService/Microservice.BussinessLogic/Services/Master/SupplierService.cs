using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Param;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;

namespace Microservice.BussinessLogic.Services.Master
{
    public class SupplierService : ISupplierService
    {
        ISupplierRepository _supplierRepository = new SupplierRepository();
        MyContext _contex = new MyContext();
        
        public bool Delete(int? id)
        {
            var getid = Get(id);
            var getsupplier=false;
            if (getid != null)
            {
                getsupplier = _supplierRepository.Delete(id);
            }
            return getsupplier;
            
        }

        public List<Suppliers> Get()
        {
            return _supplierRepository.Get();
        }

        public Suppliers Get(int? id)
        {
            if (id==null)
            {
                Console.WriteLine("Id Not Found in Application");
            }
            var getsupplier = _supplierRepository.Get(id);
            if (getsupplier == null)
            {
                Console.WriteLine("Id Not Found in Database");
            }
            return getsupplier;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            //belum fix
            if (String.IsNullOrWhiteSpace(supplierParam.name)==true)
            {
                Console.WriteLine("Nama jangan kosong");
            }
            return _supplierRepository.Insert(supplierParam);


        }

        public bool Update(int? id, SupplierParam supplierParam)
        {
            //belum fix
            if (String.IsNullOrWhiteSpace(supplierParam.name) == true)
            {
                Console.WriteLine("Nama jangan kosong");
            }
            return _supplierRepository.Update(id,supplierParam);
        }
    }
}

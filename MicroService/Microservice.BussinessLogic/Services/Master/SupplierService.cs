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
        bool status = false;
        public bool Delete(int? id)
        {
            var getid = Get(id);
            var getsupplier=false;
            if (getid != null)
            {
                getsupplier = _supplierRepository.Delete(id);
                status = true;
            }
            return status;
            
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
                Console.Read();
            }
            var getsupplier = _supplierRepository.Get(id);
            if (getsupplier == null)
            {
                Console.WriteLine("Id Not Found in Database");
                Console.Read();
            }
            return getsupplier;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            //belum fix
            if (String.IsNullOrWhiteSpace(supplierParam.name)==true)
            {
                Console.WriteLine("Name don't Empty");
                Console.Read();
            }
            else
            {
                _supplierRepository.Insert(supplierParam);
                status = true;
            }
            return status;


        }

        public bool Update(int? id, SupplierParam supplierParam)
        {
            //belum fix
            if (String.IsNullOrWhiteSpace(supplierParam.name) == true)
            {
                Console.WriteLine("Nama jangan kosong");
            }
            var getsupplier = _supplierRepository.Get(id);
            if (getsupplier == null)
            {
                Console.WriteLine("Id Not Found in Database");
            }
            else
            {
                _supplierRepository.Update(id, supplierParam);
                status = true;
            }
            return status;
        }
    }
}

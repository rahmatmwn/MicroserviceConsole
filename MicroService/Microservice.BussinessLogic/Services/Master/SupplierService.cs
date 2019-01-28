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
            if (String.IsNullOrWhiteSpace(id.ToString()) == true)
            {
                Console.WriteLine("Please Insert Id Correctly");
            }
            else
            {
                var getsupplier = _supplierRepository.Get(id);
                if (getsupplier == null)
                {
                    Console.WriteLine("Id Not Found in Database");
                    Console.Read();
                }
                else
                {
                    status = _supplierRepository.Delete(id);
                }
                
            }
            return status;
            
        }

        public List<Suppliers> Get()
        {
            return _supplierRepository.Get();
        }

        public Suppliers Get(int? id)
        {           
            return _supplierRepository.Get(id);
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
            if (String.IsNullOrWhiteSpace(id.ToString()))
            {
                Console.WriteLine("Please Input ID Correctly");
                
            }
            else
            {
                var getsupplier = _supplierRepository.Get(id);
                if (getsupplier == null)
                {
                    Console.WriteLine("Id Not Found in Database");
                    Console.Read();
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(supplierParam.name) == true)
                    {
                        Console.WriteLine("Name Don't Empty");
                    }
                    else
                    {
                        _supplierRepository.Update(id, supplierParam);
                        status = true;
                    }
                }
            }
            
            return status;
        }
    }
}

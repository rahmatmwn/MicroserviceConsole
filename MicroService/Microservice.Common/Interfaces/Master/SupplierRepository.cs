using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Param;

namespace Microservice.Common.Interfaces.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        bool status = false;
        MyContext _contex = new MyContext();
        Suppliers supplier = new Suppliers();
        public bool Delete(int? id)
        {
            var result = 0;
            var supplier = Get(id);
            try
            {
                supplier.IsDelete = true;
                supplier.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                result = _contex.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            if (result > 0)
            {
               status=true;
            }
            return status;
        }

        public List<Suppliers> Get()
        {
            return _contex.Suppliers.Where(x => x.IsDelete == false).ToList();
        }

        public Suppliers Get(int? id)
        {
            return _contex.Suppliers.Where(x=>x.Id == id && x.IsDelete==false).SingleOrDefault();
            //return _contex.Suppliers.Find(id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var result = 0;
            
            supplier.Name = supplierParam.name;
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _contex.Suppliers.Add(supplier);
            result = _contex.SaveChanges();

            if (result >0)
            {
                status= true;
            }
            return status;

        }

        public bool Update(int? id,SupplierParam supplierParam)
        {
            var result = 0;
            Suppliers supplier = Get(id);
            supplier.Name = supplierParam.name;
            supplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = _contex.SaveChanges();
            if (result > 0)
            {
                status= true;
            }
            return status;
        }
    }
}

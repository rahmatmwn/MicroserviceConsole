using Microservice.BussinessLogic.Services;
using Microservice.BussinessLogic.Services.Master;
using Microservice.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Controller
{
    public class SupplierController 
    {
        ISupplierService _supplierService = new SupplierService();
        SupplierParam supplierParam = new SupplierParam();
        public void Suppliers()
        {
            
            char pilihan;
            int result;
            Console.WriteLine("============== Supplier Data =============");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrieve");
            Console.WriteLine("==========================================");
            Console.Write("Pilihanmu : ");
            pilihan = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("==========================================");
            switch (pilihan)
            {
                case '1':
                    Console.Write("Insert Name of Supplier : ");
                     supplierParam.name = Console.ReadLine();
                    _supplierService.Insert(supplierParam);
                    break;
                case '2':
                    Console.Write("Insert Id of Supplier : ");
                    if (String.IsNullOrWhiteSpace(Console.ReadLine()) == true)
                    {
                        Console.WriteLine("Id With not Valid Value");
                        Console.Read();
                    }
                    else
                    {
                        supplierParam.Id = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Insert Name of Supplier : ");
                        supplierParam.name = Console.ReadLine();
                        _supplierService.Update(supplierParam.Id, supplierParam);
                    }
                    
                    
                    break;
                case '3':
                    Console.Write("Insert Id of Supplier : ");
                    if (String.IsNullOrWhiteSpace(Console.ReadLine()) == true)
                    {
                        Console.WriteLine("Id With not Valid Value");
                        Console.Read();
                    }
                    else
                    {
                        supplierParam.Id = Convert.ToInt16(Console.ReadLine());
                        _supplierService.Delete(supplierParam.Id);
                    }
                    
                    break;
                case '4':
                    foreach(var tampilin in _supplierService.Get())
                    {
                        Console.WriteLine("Name          : " + tampilin.Name);
                        Console.WriteLine("Join Date     : " + tampilin.JoinDate);
                        Console.Read();
                    }
                    break;
            }

        }
    }
}

﻿using Microservice.DataAccess.Model;
using Microservice.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface ISupplierRepository
    {
        bool Insert(SupplierParam supplierParam);
        bool Update(int? id,SupplierParam supplierParam);
        bool Delete(int? id);
        List<Suppliers> Get();
        Suppliers Get(int? id);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Test.Repositories
{
    [TestClass]
    public class CustomRepositoryTest
    {
        CustomerRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            objRepo = new CustomerRepository(); 
        }

        [TestMethod]
        public void Country_Custom_getAll()
        {
            //Act
            IEnumerable<Customer> result = objRepo.GetAllCustomers();
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(92, result.AsList().Count);
        }
    }
}

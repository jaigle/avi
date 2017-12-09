using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = objRepo.GetAllAsync();
            
            //Assert

            Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Count);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.DataAccess.Repositories;

namespace WebAPI.DataAccessTests
{
    [TestClass]
    public class CustomRepositoryTests
    {
        private ICustomerRepository _customerRepository;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    _customerRepository = new CustomRepository();
        //}

        //[TestMethod]
        //public void GetAllCustomerTest()
        //{
        //    _customerRepository = new CustomRepository(new ConnectionFactory());
        //    var lista = _customerRepository.GetAllCustomer();
        //    Assert.IsTrue(true);
        //}


    }
}
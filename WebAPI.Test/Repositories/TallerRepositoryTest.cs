using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Test.Repositories
{
    [TestClass]
    public class TallerRepositoryTest
    {
        TallerRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            objRepo = new TallerRepository(); 
        }

        [TestMethod]
        public void Taller_getAll()
        {
            //Act
            IEnumerable<Taller> result = objRepo.GetListaTalleres();
            
            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(92, result.AsList().Count);
        }
    }
}

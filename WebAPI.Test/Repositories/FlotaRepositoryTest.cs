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
    public class FlotaRepositoryTest
    {
        FlotaRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            objRepo = new FlotaRepository(); 
        }

        [TestMethod]
        public void Flota_getAll()
        {
            //Act
            IEnumerable<Flota> result = objRepo.GetListaFlota(0, 495, 0);

            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(92, result.AsList().Count);
        }
    }
}

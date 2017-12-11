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
    public class ComunaRepositoryTest
    {
        ComunaRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            objRepo = new ComunaRepository(); 
        }

        [TestMethod]
        public void Comunas_getAll()
        {
            //Act
            IEnumerable<Comuna> result = objRepo.GetListaComunas();
            
            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(92, result.AsList().Count);
        }
    }
}

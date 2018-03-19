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
        MantencionRepository objMantencion;

        [TestInitialize]
        public void Initialize()
        {
            objRepo = new ComunaRepository();
            objMantencion = new MantencionRepository();
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

        [TestMethod]
        public void DisponibilidadTest()
        {
            string aaaa;
            //Act
            int idtaller = 1;
            DateTime fecha = new DateTime(2018, 1, 1);
            try
            {
                IEnumerable<Disponibilidad> resultado = objMantencion.GetDisponibilidad(idtaller, fecha);
            }
            catch (Exception ex)
            {
                aaaa = ex.Message;
                throw;
            }

            //Assert
            Assert.IsNotNull(null);
        }
    }
}

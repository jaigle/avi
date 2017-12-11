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
    public class ContactoRepositoryTest
    {
        ContactoRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            objRepo = new ContactoRepository();
        }

        [TestMethod]
        public void ContactoNew_BuscarPorRut()
        {
            //Act
            ContactoNew result = objRepo.GetContactoNewByRut("14731715-8");

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1822, result.contacNumero);
        }


        [TestMethod]
        public void ContactoEmpresa_BuscarPorEmpresa()
        {
            //Act
            IEnumerable<ContactoEmpresa> result = objRepo.GetContactoPorEmpresa(0);

            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(1822, result.contacNumero);
        }

        [TestMethod]
        public void ContactoCliente_BuscarPorLlave()
        {
            //Act
            ContactoCliente result = objRepo.GetContactoClienteByKey(9163, 9690);

            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(1822, result.contacNumero);
        }


        [TestMethod]
        public void TipoContacto_Listado()
        {
            //Act
            IEnumerable<TipoContacto> result = objRepo.GetListaTipoContacto();

            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(1822, result.contacNumero);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiLayer.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLayer.Library.Tests
{
    [TestClass()]
    public class BaseManagerTests
    {
        BaseManager myClass = new BaseManager();
        [TestMethod()]
        public void IsValidTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuildTokenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuildTokenPlainTest()
        {
            string mytoken = myClass.BuildTokenPlain("avislo");
            Test.Entities.ResultModel myResult = new Test.Entities.ResultModel();
            myResult = myClass.CheckTokenPlain(mytoken);
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckTokenPlainTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckTokenTest()
        {
            Assert.Fail();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class EmpresaManager : BaseManager
    {
        private EmpresaRepository _empresaRepository;

        public EmpresaManager()
        {
            _empresaRepository = new EmpresaRepository();
        }

        public ResultModel GetEmpresa(string pstrRut, int pintNumCliente)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_empresaRepository.Get(pstrRut, pintNumCliente)));
            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 10;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = String.Empty;
            }
            return resultModel;
        }

        public ResultModel ActualizarEmpresa(Empresa_put value)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.Payload = "";//Tools.Base64Encode(JsonConvert.SerializeObject(_empresaRepository.Edit(value)));
            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 10;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = String.Empty;
            }
            return resultModel;
        }
    }
}

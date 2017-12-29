using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class ContratoManager : BaseManager
    {
        private ContratoRepository _contratoRepository;

        public ContratoManager()
        {
            _contratoRepository = new ContratoRepository();
        }

        public ResultModel GetListadoContratos(string token, int pintCodEmpresa)
        {
            ResultModel resultModel = CheckToken(token);
            try
            {
                if (resultModel.Result)
                    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contratoRepository.GetListaContrato(pintCodEmpresa)));
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

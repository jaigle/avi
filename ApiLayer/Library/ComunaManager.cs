using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class ComunaManager : BaseManager
    {
        private ComunaRepository _comunaRepository;

        public ComunaManager()
        {
            _comunaRepository = new ComunaRepository();
        }

        public ResultModel GetComunas(string token)
        {
            ResultModel resultModel = CheckToken(token);
            try
            {
                if (resultModel.Result)
                    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_comunaRepository.GetListaComunas()));
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

        public ResultModel GetComunas()
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_comunaRepository.GetListaComunas()));
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

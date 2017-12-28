using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class CiudadManager : BaseManager
    {
        private CiudadRepository _ciudadRepository;

        public CiudadManager()
        {
            _ciudadRepository = new CiudadRepository();
        }

        public ResultModel GetCiudades(string token)
        {
            ResultModel resultModel = CheckToken(token);
            //ResultModel resultModel = new ResultModel();
            try
            {
                if (resultModel.Result)
                    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_ciudadRepository.GetListaCiudades()));
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

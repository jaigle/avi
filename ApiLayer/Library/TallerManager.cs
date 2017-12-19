using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class TallerManager : BaseManager
    {
        private TallerRepository _tallerRepository;

        public TallerManager()
        {
            _tallerRepository = new TallerRepository();
        }

        public ResultModel GetTalleres(string token)
        {
            ResultModel resultModel = CheckToken(token);
            try
            {
                if (resultModel.Result)
                    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_tallerRepository.GetListaTalleres()));
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

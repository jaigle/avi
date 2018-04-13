using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class SiniestroManager : BaseManager
    {
        private SiniestroRepository _siniestroRepository;

        public SiniestroManager()
        {
            _siniestroRepository = new SiniestroRepository();
        }

        public ResultModel AddSiniestro(Siniestro value, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_siniestroRepository.Add(value)));
            }
            catch (CustomException myException)
            {
                resultModel.ErrorMessage = myException.LocalError.ErrorMessage;
                resultModel.ErrorCode = myException.LocalError.ErrorCode;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = String.Empty;
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

        public ResultModel AddTercero(SiniestroTercero value, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_siniestroRepository.AddTercero(value)));
            }
            catch (CustomException myException)
            {
                resultModel.ErrorMessage = myException.LocalError.ErrorMessage;
                resultModel.ErrorCode = myException.LocalError.ErrorCode;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = String.Empty;
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

        public ResultModel AddSiniestroFoto(SiniestroFoto value, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_siniestroRepository.AddFoto(value)));
            }
            catch (CustomException myException)
            {
                resultModel.ErrorMessage = myException.LocalError.ErrorMessage;
                resultModel.ErrorCode = myException.LocalError.ErrorCode;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = String.Empty;
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

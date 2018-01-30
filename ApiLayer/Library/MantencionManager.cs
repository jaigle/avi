using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class MantencionManager : BaseManager
    {
        private MantencionRepository _mantencionRepository;

        public MantencionManager()
        {
            _mantencionRepository = new MantencionRepository();
        }

        public ResultModel ActualizarMantencion(Mantencion entity)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_mantencionRepository.Edit(entity)));
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


        public ResultModel AgregarMantencion(Mantencion entity)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_mantencionRepository.Add(entity)));
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

        public ResultModel GetListadoMantencion(int pintIdAgenda, int pintNumCliente)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_mantencionRepository.GetListaMantencion(pintIdAgenda, pintNumCliente)));
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

        public ResultModel GetDisponibilidad(int pintIdTaller, DateTime pFecha)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.Payload =
                    Tools.Base64Encode(
                        JsonConvert.SerializeObject(_mantencionRepository.GetDisponibilidad(pintIdTaller, pFecha)));
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

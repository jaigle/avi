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

        public ResultModel ActualizarMantencion(Mantencion entity, string token)
        {
            //ResultModel resultModel = new ResultModel();
            ResultModel resultModel = CheckToken(token);
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


        public ResultModel AgregarMantencion(Mantencion entity, string token)
        {
            ResultModel resultModel = CheckToken(token);
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

        public ResultModel GetListadoMantencion(int pintIdAgenda, int pintNumCliente, string pstrToken, string token)
        {
            ResultModel resultModel = CheckToken(token);
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_mantencionRepository.GetListaMantencion(pintIdAgenda, pintNumCliente,pstrToken)));
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

        public ResultModel GetDisponibilidad(int pintIdTaller, string pFecha, string token)
        {
            ResultModel resultModel = CheckToken(token);
            DateTime pFecha1;
            try
            {
                try {
                    //pFecha1 = DateTime.ParseExact(pFecha, "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture);
                    pFecha1 = DateTime.ParseExact(pFecha, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw new Exception("Fecha no suministrada o con formato erroneo.");
                }
                resultModel.Payload =
                    Tools.Base64Encode(
                        JsonConvert.SerializeObject(_mantencionRepository.GetDisponibilidad(pintIdTaller, pFecha1)));
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

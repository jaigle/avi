using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class VehiculoManager : BaseManager
    {
        private VehiculoRepository _vehiculoRepository;

        public VehiculoManager()
        {
            _vehiculoRepository = new VehiculoRepository();
        }

        public ResultModel GetVehiculo(string pstrPatente, string token)
        {
            //ResultModel resultModel = CheckToken(token);
            ResultModel resultModel = new ResultModel();
            try
            {
                if (resultModel.Result)
                    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_vehiculoRepository.GetVehiculo(pstrPatente)));
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

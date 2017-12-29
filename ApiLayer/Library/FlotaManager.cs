using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class FlotaManager : BaseManager
    {
        private FlotaRepository _flotaRepository;

        public FlotaManager()
        {
            _flotaRepository = new FlotaRepository();
        }

        public ResultModel GetListadoFlota( int pintIdLCiente, int pintGrupoVehiculo, string token)
        {
            ResultModel resultModel = CheckToken(token);
            try
            {
                if (resultModel.Result)
                    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_flotaRepository.GetListaFlota(0, pintGrupoVehiculo, pintIdLCiente)));
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

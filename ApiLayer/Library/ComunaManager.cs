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
            if (resultModel.Result)
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_comunaRepository.GetListaComunas()));
            }
            return resultModel;
        }
    }
}

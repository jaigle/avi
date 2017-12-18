using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class AnexoManager : BaseManager
    {
        private AnexoRepository _anexoRepository;

        public AnexoManager()
        {
            _anexoRepository = new AnexoRepository();
        }

        public ResultModel GetAnexo(int pintIdAnexo, string token)
        {
            //ResultModel resultModel = CheckToken(token);
            Anexo entity = new Anexo {iDContratoGrupoDF = pintIdAnexo};
            ResultModel resultModel = new ResultModel();
            try
            {
                if (resultModel.Result)
                    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_anexoRepository.Get(pintIdAnexo)));
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

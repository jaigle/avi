using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class ContactoManager : BaseManager
    {
        private ContactoRepository _contactoRepository;

        public ContactoManager()
        {
            _contactoRepository = new ContactoRepository();
        }

        public ResultModel GetContacto(string token)
        {
            //ResultModel resultModel = CheckToken(token);
            //if (resultModel.Result)
            //{
            //    if 
            //    //Si el rut no esta presenta en la tabla ContactoNew

            //    //Crearlo en la tabla ContactoNew y ContactoCliente
                

            //    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_comunaRepository.GetListaComunas()));
            //}
            return null;
        }

        public ResultModel AddContacto(ContactoDto value, string token)
        {
            ResultModel resultModel = new ResultModel();
            //resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.Add(value)));
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

        public ResultModel GetContactoPorEmpresa(int pintIdEmpresa, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.GetContactoPorEmpresa(pintIdEmpresa)));
            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 0;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = token;
            }
            return resultModel;
        }

        public ResultModel GetContactoClientePorLlave(int pintContactNumero, int pintClienteNumero, int pintTipoContacto, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.GetContactoClienteByKey(pintContactNumero, pintClienteNumero, pintTipoContacto)));
            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 0;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = token;
            }
            return resultModel;
        }

        public ResultModel DeleteContactClient(ContactoCliente entity, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                _contactoRepository.DeleteContactoCliente(entity);
                resultModel.Payload = "0";
            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 2;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = token;
            }
            return resultModel;
        }

        public ResultModel PutContactoCliente(ContactoCliente entity, string token)
        {
            ResultModel resultModel = new ResultModel();
            //ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.PutContactoCliente(entity)));
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

        public ResultModel GetListTipoContacto(string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload =
                    Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.GetListaTipoContacto()));
            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 0;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = token;
            }
            return resultModel;
        }

        public ResultModel GetListUsuarios(string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload =
                    Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.GetListaUsuarios()));
            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 0;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = token;
            }
            return resultModel;
        }
    }
}

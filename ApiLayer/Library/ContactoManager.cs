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
            //ResultModel resultModel = CheckToken(token);
            ResultModel resultModel = new ResultModel();
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.Add(value)));
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

        public ResultModel GetContactoPorEmpresa(int pintIdEmpresa, string token)
        {
            //ResultModel resultModel = CheckToken(token);
            ResultModel resultModel = new ResultModel();
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

        public ResultModel GetContactoClientePorLlave(int pintContactNumero, int pintClienteNumero, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (!resultModel.Result) return resultModel;
            try
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.GetContactoClienteByKey(pintContactNumero, pintClienteNumero)));
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

        public ResultModel DeleteContactClient(int pintContactNumero, int pintClienteNumero, string token)
        {
            //ResultModel resultModel = CheckToken(token);
            ResultModel resultModel = new ResultModel();
            if (!resultModel.Result) return resultModel;
            try
            {
                _contactoRepository.DeleteContactoCliente(pintContactNumero, pintClienteNumero);
                resultModel.Payload = "0";
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

        public ResultModel PutContactoCliente(ContactoCliente entity, string token)
        {
            //ResultModel resultModel = CheckToken(token);
            ResultModel resultModel = new ResultModel();
            if (!resultModel.Result) return resultModel;
            try
            {
                _contactoRepository.PutContactoCliente(entity);
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_contactoRepository.GetContactoClienteByKey(entity.contactoNumero, entity.clienteNumero)));
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

        public ResultModel GetListTipoContacto(string token)
        {
            //ResultModel resultModel = CheckToken(token);
            ResultModel resultModel = new ResultModel();
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
    }
}

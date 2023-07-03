using AutoMapper.Internal;
using Castle.DynamicProxy;
using Employment.Application.Dtos.CommonDto;
using Employment.Common.Constants;
using Employment.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.Interceptors
{
    public class ServicesInterceptor : IInterceptor
    {
        private readonly IIntIdHahser _intIdHasher;

        public ServicesInterceptor(IIntIdHahser intIdHasher)
        {
            this._intIdHasher = intIdHasher;
        }
        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Method.Name;
            var args = invocation.Arguments.FirstOrDefault();
            string serviceEntityName = invocation.TargetType.FullName.Split(".").Last().Replace("Service", "");
            if (methodName.ToLower().StartsWith("get") || methodName.ToLower().StartsWith("update"))
            {
                string encodedId = args.GetType().GetProperty("EncodedID").GetValue(args) as string;
                int? modelDecodedId = args.GetType().GetProperty("DecodedID").GetValue(args) as int?;
                try
                {
                    var decodedId = _intIdHasher.DeCode(encodedId as string);
                    invocation.Arguments.FirstOrDefault().GetType().GetProperty("DecodedID").SetValue(args, decodedId);
                }
                catch (Exception ex)
                {
                    throw new NotFoundException(msg: $"{serviceEntityName} not Found :)", entity: serviceEntityName, id: encodedId as string);
                }
                invocation.Proceed();
            }

        }
    }
}

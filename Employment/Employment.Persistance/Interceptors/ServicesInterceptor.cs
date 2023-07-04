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

        /// <summary>
        /// if method name starts with names specified inside the interceptor
        /// the interceptor will retrieve the encodedId and decodedId from method arguments and 
        /// then assigns the value of the decoded id to _intIdHasher.Decode() of EncodedId,
        /// and then pass the decoded id as argument to the method.
        /// (this interceptor is for decoding the method arguments called from the clients)
        /// </summary>
        /// <param name="invocation"></param>
        /// <exception cref="NotFoundException"></exception>
        public void Intercept(IInvocation invocation)
        {
            // exptract method name ---
            string methodName = invocation.Method.Name.ToLower();
            // if method name starts with ... then ---
            if ((methodName.StartsWith("get") && !methodName.EndsWith("list")) || methodName.StartsWith("update"))
            {
                // extract method arguments ---
                var args = invocation.Arguments.FirstOrDefault();
                // extract the service of the method is inside that --- used in the exception throwed 
                string serviceEntityName = invocation.TargetType.FullName.Split(".").Last().Replace("Service", "");
                // find the encoded (_intIdHasher.Code(int id)) id from method arguments ---
                string encodedId = args.GetType().GetProperty("EncodedID").GetValue(args) as string;
                // find the encoded (_intIdHasher.DeCode(int id)) id from method arguments ---
                int? modelDecodedId = args.GetType().GetProperty("DecodedID").GetValue(args) as int?;
                if(modelDecodedId != null)
                {
                    // the try and except is for, when id is incurrect throw not found exception in the catch block ---
                    try
                    {
                        // decode the encoded id ---
                        var decodedId = _intIdHasher.DeCode(encodedId as string);
                        // update the decoded id and pass it to the method as argument ---
                        invocation.Arguments.FirstOrDefault().GetType().GetProperty("DecodedID").SetValue(args, decodedId);
                    }
                    catch (Exception ex)
                    {
                        throw new NotFoundException(msg: $"{serviceEntityName} not Found :)", entity: serviceEntityName, id: encodedId as string);
                    }
                }
            }
            // anyway method will proceed :) ---
            invocation.Proceed();

        }
    }
}

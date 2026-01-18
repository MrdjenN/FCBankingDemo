using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;

namespace FCBankDemo.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IValidator<TRequest>[] _validators;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validators"></param>
        public ValidationBehavior(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            List<ValidationFailure> list = (from error in _validators.Select((IValidator<TRequest> v) => v.Validate(request)).SelectMany((ValidationResult result) => result.Errors)
                                            where error != null
                                            select error).ToList();
            if (list.Any())
            {
                var firstError = list.FirstOrDefault();
                if (firstError == null) 
                    throw new ValidationException("Unknown validation error");
                var errorString = "Error: " + firstError.ErrorMessage;
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = errorString, Content = new StringContent(errorString, System.Text.Encoding.UTF8, "application/json") };
                //throw new Exception(response.ToString());
                throw new ValidationException(response.ReasonPhrase);
            }

            return await next();
        }
    }
}

using BCP.ExchangeRate.BusinessLogic.ExchangeRate.Interface;
using BCP.ExchangeRate.Common;
using BCP.ExchangeRate.Domain.ExchangeRate;
using BCP.ExchangeRate.WebAPI.Models.Response;
using BCP.ExchangeRate.WebAPI.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BCP.ExchangeRate.WebAPI.Controllers
{
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRateBL _exchangeRateBL;

        public ExchangeRatesController(IExchangeRateBL exchangeRateBL)
        {
            _exchangeRateBL = exchangeRateBL;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<GetExchangeRate>>> Get([Required] string originCurrency, [Required] string destinationCurrency, [Required] decimal amount)
        {
            WebApiResponse<GetExchangeRate> response = new WebApiResponse<GetExchangeRate>();

            try
            {
                if (string.IsNullOrEmpty(originCurrency) || string.IsNullOrEmpty(destinationCurrency) || amount == 0)
                {
                    if (string.IsNullOrEmpty(originCurrency))
                        response.Errors.Add(new Error()
                        {
                            Code = StatusCodes.Status400BadRequest,
                            Message = $"Por favor ingrese un valor diferente a vacío para para la moneda origen."
                        });

                    if (string.IsNullOrEmpty(destinationCurrency))
                        response.Errors.Add(new Error()
                        {
                            Code = StatusCodes.Status400BadRequest,
                            Message = $"Por favor ingrese un valor diferente a vacío para la moneda destino."
                        });

                    if (amount == 0)
                        response.Errors.Add(new Error()
                        {
                            Code = StatusCodes.Status400BadRequest,
                            Message = $"Por favor ingrese un valor mayor a cero para el monto."
                        });

                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }

                var entity = await _exchangeRateBL.GetAsync(originCurrency, destinationCurrency, amount);

                if (entity == null)
                {
                    response.Success = false;
                    response.Errors = new List<Error>();
                    response.Errors.Add(new Error()
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = $"No existe un tipo de cambio configurado para la moneda origen {originCurrency} y moneda destino {destinationCurrency}"
                    });

                    return StatusCode(StatusCodes.Status404NotFound, response);
                }

                response.Success = true;
                response.Response = new Response<GetExchangeRate>();
                response.Response.Data = new List<GetExchangeRate>();
                response.Response.Data.Add(entity);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors = new List<Error>();
                response.Errors.Add(new Error()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                });

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PostExchangeRate>>> Post([FromBody] PostExchangeRate entity)
        {
            WebApiResponse<PostExchangeRate> response = new WebApiResponse<PostExchangeRate>();

            var validator = new PostExchangeRateValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(entity);

            try
            {
                if (!result.IsValid)
                {
                    response.Success = false;
                    response.Errors = new List<Error>();

                    Error error = null;

                    foreach (var item in result.Errors)
                    {
                        error = new Error();

                        error.Code = StatusCodes.Status400BadRequest;
                        error.Message = string.Format("{0}: {1}", item.ErrorCode, item.ErrorMessage);

                        response.Errors.Add(error);
                    }

                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }

                await _exchangeRateBL.InsertAsync(entity);

                if (entity == null)
                {
                    response.Success = false;
                    response.Errors = new List<Error>();
                    response.Errors.Add(new Error()
                    {
                        Code = StatusCodes.Status500InternalServerError,
                        Message = Constants.MensajeErrorSistema
                    });

                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }

                response.Success = true;
                response.Response = new Response<PostExchangeRate>();
                response.Response.Data = new List<PostExchangeRate>();
                response.Response.Data.Add(entity);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);

                response.Success = false;
                response.Errors = new List<Error>();
                response.Errors.Add(new Error()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                });

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Framework
{
    public interface ICommand : IDisposable
    {
        Result Execute(ObjectContext context);
    }

    public interface ICommand<T> : IDisposable
    {
        Result<T> Execute(ObjectContext context);
    }

    public abstract class CommandBase : ICommand
    {

        /// <summary>
        /// Validate before execute a command. Base validation does nothing
        /// </summary>
        protected virtual void ValidateCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutingCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutedCore(ObjectContext context, Result result)
        {
        }
        protected abstract Result ExecuteCore(ObjectContext context);
        public Result Execute(ObjectContext context)
        {
            try
            {
                ValidateCore(context);
                OnExecutingCore(context);
                var result = ExecuteCore(context);
                OnExecutedCore(context, result);
                return result;
            }
            catch(UnauthorizedAccessException ex)
            {
                return new Result
                {
                    Message = ex.Message,
                    Code = HttpStatusCode.Unauthorized
                };
            }
            catch(BadRequestException ex)
            {
                return new Result
                {
                    Message = ex.Message,
                    Code = HttpStatusCode.BadRequest
                };
            }
            catch(Exception ex)
            {
                return new Result
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
            finally
            {
                
            }
        }

        public virtual void Dispose()
        {
        }

        protected Result Success(string message = "Success")
        {
            return new Result
            {
                Code = HttpStatusCode.OK,
                Message = message
            };
        }
    }

    public abstract class CommandBase<T> : ICommand<T>
    {

        /// <summary>
        /// Validate before execute a command. Base validation does nothing
        /// </summary>
        protected virtual void ValidateCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutingCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutedCore(ObjectContext context, Result<T> result)
        {
        }
        protected abstract Result<T> ExecuteCore(ObjectContext context);
        public Result<T> Execute(ObjectContext context)
        {
            try
            {
                ValidateCore(context);
                OnExecutingCore(context);
                var result = ExecuteCore(context);
                OnExecutedCore(context, result);
                return result;
            }
            catch (BadRequestException ex)
            {
                return new Result<T>
                {
                    Message = ex.Message,
                    Code = HttpStatusCode.BadRequest
                };
            }
            catch(UnauthorizedAccessException ex)
            {
                return new Result<T>
                {
                    Message = ex.Message,
                    Code = HttpStatusCode.Unauthorized
                };
            }
            catch (Exception ex)
            {
                return new Result<T>
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }
        public virtual void Dispose()
        {
        }
        
        protected Result<T> Success(T data, string message = "Success")
        {
            return new Result<T>
            {
                Data = data,
                Code = HttpStatusCode.OK,
                Message = message,
            };
        }
    }

    public interface IResult
    {
        string Message { get; set; }
        bool IsSuccess { get; }
        HttpStatusCode Code { get; set; }
    }

    public interface IResult<T> : IResult
    {
        T Data { get; set; }
    }

    public class Result : IResult
    {
        public bool IsSuccess
        {
            get
            {
                return this.Code == HttpStatusCode.OK;
            }
        }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public string description { get; set; }
        public Result()
        {
            this.Code = HttpStatusCode.OK;
            this.Message = "Success";
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; set; }
        public IPaging paging { get; set; }
    }

    public interface IPaging
    {
        long? Total { get; set; }
        long? CurrentPage { get; set; }
        long? PageSize { get; set; }
    }

    public class Paging<T> : IPaging, IResult<List<T>>
    {
        public List<T> Data { get;set; }
        public string Message { get;set; }
        public bool IsSuccess { get;set; }
        public HttpStatusCode Code { get; set; }
        public long? Total { get;set; }
        public long? CurrentPage { get;set; }
        public long? PageSize { get;set; }
    }

}

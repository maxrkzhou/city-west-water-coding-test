using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.Configuration
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        List<string> Errors { get; set; }
    }
    public interface IResult<T> : IResult
    {
        T Value { get; set; }
    }

    public class Result : IResult
    {
        public Result()
        {
            Errors = new List<string>();
        }
        private bool _isSuccess;
        public bool IsSuccess
        {
            get
            {
                _isSuccess = Errors.Count > 0 ? false : true;
                return _isSuccess;
            }
            set => _isSuccess = value;
        }
        public List<string> Errors { get; set; }
        public void AddError(string error)
        {
            Errors.Add(error);
            IsSuccess = false;
        }

        public void AddErrors(List<string> errors)
        {
            Errors.AddRange(errors);
            IsSuccess = false;
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public T Value { get; set; }
    }
}

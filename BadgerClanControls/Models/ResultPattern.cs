using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgerClanControls.Models
{
    public class ResultPattern<T,E>
    {
        public T? Value { get; set; }
        public E? Error { get; set; }
        public bool IsSuccess { get; set; }

        private ResultPattern(T? value) 
        {
            Value = value;
            IsSuccess = true;
        }

        private ResultPattern(E? error)
        {
            Error = error;
            IsSuccess = false;
        }

        public static ResultPattern<T, E> Ok(T value) => new(value);
        public static ResultPattern<T,E> Fail(E error) => new(error);
    }
}

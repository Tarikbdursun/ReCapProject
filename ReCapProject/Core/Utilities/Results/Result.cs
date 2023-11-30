﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

       
        public Result(bool success, string message) : this(success)
        {
            message = Message;
        }

        public Result(bool success)
        {
            success = Success;
        }
    }
}

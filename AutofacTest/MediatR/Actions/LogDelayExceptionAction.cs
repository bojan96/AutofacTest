using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutofacTest.MediatR.Request;
using MediatR.Pipeline;

namespace AutofacTest.MediatR.Actions
{
    public class LogDelayExceptionAction : RequestExceptionAction<DelayRequest, ArgumentOutOfRangeException>
    {
        protected override void Execute(DelayRequest request, ArgumentOutOfRangeException exception)
        {
            Debug.WriteLine($"Invalid delay arg {request.Delay}");
        }
    }
}

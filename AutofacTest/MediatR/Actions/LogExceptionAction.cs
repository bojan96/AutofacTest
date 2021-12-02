using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutofacTest.MediatR.Request;
using MediatR.Pipeline;

namespace AutofacTest.MediatR.Actions
{
    public class LogExceptionAction : RequestExceptionAction<DelayRequest>
    {
        protected override void Execute(DelayRequest request, Exception exception)
        {
            Debug.WriteLine(exception);
        }
    }
}

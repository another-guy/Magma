using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Magma.Web.Http.Filters
{
    public sealed class InvalidModelStateException : Exception
    {
        public ModelStateDictionary ModelState { get; private set; }

        public InvalidModelStateException(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }
    }
}

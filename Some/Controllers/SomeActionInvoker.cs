using System;
using System.Web.Mvc;

namespace Some.Controllers
{
    public class SomeActionInvoker:ControllerActionInvoker
    {
        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName.Equals("AddToUser", StringComparison.CurrentCultureIgnoreCase))
            {
                var result = base.InvokeAction(controllerContext, actionName);
                return result;
            }
            if (actionName.Equals("Base",StringComparison.CurrentCultureIgnoreCase))
            {
                //InvokeActionResult(controllerContext, ((TestController)controllerContext.Controller).Base());
                var result = base.InvokeAction(controllerContext,actionName);
                return result;
            }
            return false;
        }
    }
}
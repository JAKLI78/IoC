using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace Some.Controllers
{
    public class SomeActionInvoker:ControllerActionInvoker
    {
        private DbContext _context;

        public SomeActionInvoker(DbContext context)
        {
            _context = context;
        }

        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName.Equals("AddToUser", StringComparison.CurrentCultureIgnoreCase))
            {
                var transaction = _context.Database.BeginTransaction();
                using (transaction)
                {
                    try
                    {
                        var result = base.InvokeAction(controllerContext, actionName);               
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
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
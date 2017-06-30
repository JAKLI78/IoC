﻿using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace Some.ActionInvoker
{
    public class SomeActionInvoker : ControllerActionInvoker
    {
        private readonly DbContext _context;

        public SomeActionInvoker(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context),
                           $"{nameof(context)} cannot be null.");
        }

        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
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
    }
}
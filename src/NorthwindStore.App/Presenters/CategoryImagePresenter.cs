﻿using System;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using NorthwindStore.BL.Facades.Admin;

namespace NorthwindStore.App.Presenters
{
    public class CategoryImagePresenter : IDotvvmPresenter
    {
        private readonly AdminCategoriesFacade facade;

        public CategoryImagePresenter(AdminCategoriesFacade facade)
        {
            this.facade = facade;
        }

        public async Task ProcessRequest(IDotvvmRequestContext context)
        {
            var id = Convert.ToInt32(context.Parameters["Id"]);

            var bytes = facade.GetImage(id);

            context.HttpContext.Response.ContentType = "image/jpeg";
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
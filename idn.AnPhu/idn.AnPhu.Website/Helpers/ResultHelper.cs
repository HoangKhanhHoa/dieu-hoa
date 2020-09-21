using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Helpers
{
    public static class ResultHelper
    {
        public static ActionResult NotFoundResult(idn.AnPhu.Website.Controllers.BaseController controller, bool emptyBody)
        {
            controller.ControllerContext.HttpContext.Response.StatusCode = 404;
            if (emptyBody)
            {
                controller.ControllerContext.HttpContext.Response.End();
            }

            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Errors/404";
            viewResult.MasterName = controller.GetDefaultMasterName();
            return viewResult;
        }

        /// <summary>
        /// Returns a status 404 to the client and the error 404 view.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static ActionResult NotFoundResult(idn.AnPhu.Website.Controllers.BaseController controller)
        {
            return NotFoundResult(controller, false);
        }


        /// <summary>
        /// Returns a http status 403 to the client and the error 403 view.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static ActionResult ForbiddenResult(idn.AnPhu.Website.Controllers.BaseController controller)
        {
            return ForbiddenResult(controller, false);
        }

        /// <summary>
        /// Returns a http status 403 to the client and the error 403 view.
        /// </summary>
        /// <param name="controller">current controller</param>
        /// <param name="emptyBody">true: the http response end without body</param>
        /// <returns></returns>
        public static ActionResult ForbiddenResult(idn.AnPhu.Website.Controllers.BaseController controller, bool emptyBody)
        {
            controller.ControllerContext.HttpContext.Response.StatusCode = 403;
            if (emptyBody)
            {
                controller.ControllerContext.HttpContext.Response.End();
                return new EmptyResult();
            }

            var viewResult = new ViewResult
            {
                ViewName = "Errors/403",
                MasterName = controller.GetDefaultMasterName()
            };
            return viewResult;
        }

        //public static ActionResult MovedPermanentlyResult(idn.AnPhu.Website.Controllers.BaseController controller, object routeValues)
        //{
        //    return new idn.AnPhu.Biz.Extensions.MovedPermanentlyResult(routeValues);
        //}

        /// <summary>
        /// Returns a ViewResult with content type set as xml
        /// </summary>
        public static ActionResult XmlViewResult(idn.AnPhu.Website.Controllers.BaseController controller, object model, string viewName = null)
        {
            controller.ControllerContext.HttpContext.Response.ContentType = "text/xml; charset=UTF-8";
            if (model != null)
            {
                controller.ViewData.Model = model;
            }
            ViewResult result = new ViewResult();
            result.ViewName = viewName;
            result.ViewData = controller.ViewData;
            result.TempData = controller.TempData;
            return result;
        }
    }
}
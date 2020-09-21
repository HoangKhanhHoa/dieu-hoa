using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Auth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "auth_login",
                "{culture}/dang-nhap",
                new { culture = "vi", controller = "Account", action = "Login" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "auth_home",
                "{culture}/quan-tri",
                new { culture = "vi", controller = "Home", action = "Index" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "auth_sys_user",
                "{culture}/quan-tri/nguoi-dung",
                new { culture = "vi", controller = "Sys_User", action = "Index" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );
            context.MapRoute(
                name: "auth_sys_user_create",
                url: "{culture}/quan-tri/nguoi-dung/tao-moi",
                defaults: new
                {
                    culture = "vi",
                    area = "Auth",
                    controller = "Sys_User",
                    action = "Create",
                },
                namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
               name: "auth_sys_user_update",
               url: "{culture}/quan-tri/nguoi-dung/cap-nhat",
               defaults: new
               {
                   culture = "vi",
                   area = "Auth",
                   controller = "Sys_User",
                   action = "Update",
               },
               namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
           );
            context.MapRoute(
              name: "auth_sys_user_detail",
              url: "{culture}/quan-tri/nguoi-dung/chi-tiet",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Sys_User",
                  action = "Detail",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            ///LocationDiscount
            context.MapRoute(
              name: "auth_locationdiscount_index",
              url: "{culture}/quan-tri/danh-muc-dia-chi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "LocationDiscount",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );
            context.MapRoute(
              name: "auth_locationdiscount_create",
              url: "{culture}/quan-tri/danh-muc-dia-chi/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "LocationDiscount",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );
            context.MapRoute(
              name: "auth_locationdiscount_update",
              url: "{culture}/quan-tri/danh-muc-dia-chi/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "LocationDiscount",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            ///Location
            context.MapRoute(
              name: "auth_location_index",
              url: "{culture}/quan-tri/danh-sach-dia-chi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Location",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );
            context.MapRoute(
              name: "auth_location_create",
              url: "{culture}/quan-tri/danh-sach-dia-chi/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Location",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );
            context.MapRoute(
              name: "auth_location_update",
              url: "{culture}/quan-tri/danh-sach-dia-chi/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Location",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            ///Manufacter
            context.MapRoute(
              name: "auth_manufacter_index",
              url: "{culture}/quan-tri/danh-sach-nha-san-xuat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Manufacter",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );
            context.MapRoute(
              name: "auth_manufacter_create",
              url: "{culture}/quan-tri/danh-sach-nha-san-xuat/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Manufacter",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );
            context.MapRoute(
              name: "auth_manufacter_update",
              url: "{culture}/quan-tri/danh-sach-nha-san-xuat/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Manufacter",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );




            context.MapRoute(
                "Auth_default",
                "{culture}/Auth/{controller}/{action}/{id}",
                new { culture = "vi", controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );



            //context.MapRoute(
            //    "Auth_default",
            //    "Auth/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
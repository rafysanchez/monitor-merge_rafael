using System;
using System.Web;
using System.Web.Mvc;
using Prodesp.Gsnet.Rbac20.Presentation.Mvc.Controllers;
using Newtonsoft.Json;
using Prodesp.Gsnet.Framework;
using Prodesp.Gsnet.Rbac20.Presentation.Login.Extension.Mvc.Context;

namespace Prodesp.Gsnet.Monitor.Presentation.MVC.Controllers
{
    public class AccountController : RbacMvcLoginController
    {
        public ActionResult Login()
        {
            return base.InternalLogin();
        }
        [HttpPost]
        public virtual ActionResult Callback(string accessToken)
        {
            var url = Url.Action("Index", "Home", new { area = "" });
            var redir = RedirectToAction("Index", "Home", new { area = "" });
            var user = FromToken(accessToken, true, "7511cd2c-3a92-8795-54cd-efab147aa2b8");
            var cdParametroSiafisico = "MONITOR.TP_USUARIO";
            var result = Prodesp.Gsnet.Rbac20.Presentation.Proxy.ParametroProxy.Pesquisar(new LocalContext(user), cdParametroSiafisico);
            this.CriarCookiesAcesso(JsonConvert.SerializeObject(new { Login = user.Login, Nome = user.Nome, IdJustificador = result?.Data?.Capacity, IdFarmacia = user.Departamentos[0] }), user.AccessToken);
            return base.Callback(user.AccessToken, redir, url);

        }


        [HttpGet]
        public ActionResult SignOut()
        {
            return base.SignOut(RedirectToAction("Login", "Account", null));
        }
        protected void CriarCookiesAcesso(string dadosUsuario, string accessToken)
        {
            HttpCookie cookieAccessToken = new HttpCookie("accessToken", accessToken);
            HttpCookie cookieUsuario = new HttpCookie("usuario", dadosUsuario);

            cookieAccessToken.Expires = DateTime.Now.AddHours(1);
            cookieUsuario.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(cookieAccessToken);
            Response.Cookies.Add(cookieUsuario);
        }
        protected void LimparCookies()
        {
            var accessTokenCookie = new HttpCookie("accessToken", "");
            accessTokenCookie.Expires = DateTime.Now.AddDays(-14);
            var tokenLegado = new HttpCookie("usuario", "");
            tokenLegado.Expires = DateTime.Now.AddDays(-14);
            Response.Cookies.Add(accessTokenCookie);
            Response.Cookies.Add(tokenLegado);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodesp.Gsnet.Monitor.Presentation.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {

            filterContext.ExceptionHandled = true;
            if (filterContext.Exception.GetType() == typeof(UnauthorizedAccessException))
            {
                Response.StatusCode = 401;
            }
            else
            {
                Response.StatusCode = 500;
            }
            filterContext.Result = this.RedirectToAction("HandleError", "ErrorHandler", new { id = Response.StatusCode, status = filterContext.Exception.Message });

            base.OnException(filterContext);
        }
        protected bool VerificarExistenciaTokenLegado()
        {
            var tokenLegadoCookie = Request.Cookies.Get("tokenLegado");
            if (tokenLegadoCookie == null || string.IsNullOrEmpty(tokenLegadoCookie.Value))
                return false;
            return true;
        }
        protected bool VerificarExistenciaAccessToken()
        {
            var accessCookie = Request.Cookies.Get("accessToken");
            if (accessCookie == null || string.IsNullOrEmpty(accessCookie.Value))
                return false;
            return true;
        }
        protected void VerificarAutorizacaoUsuario()
        {
            if (this.VerificarExistenciaTokenLegado() && this.VerificarExistenciaAccessToken())
                return;

            throw new UnauthorizedAccessException("Dados de acesso não encontrados ou não informados. Acesse o sistema novamente");

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
        protected ActionResult ExecutarActionSeForValida(Func<ActionResult> action)
        {
            try
            {
                return action();
            }
            catch (UnauthorizedAccessException e)
            {
                Response.StatusCode = 401;
                Response.StatusDescription = e.Message;
                throw e;
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                throw e;
            }

        }
    }
}
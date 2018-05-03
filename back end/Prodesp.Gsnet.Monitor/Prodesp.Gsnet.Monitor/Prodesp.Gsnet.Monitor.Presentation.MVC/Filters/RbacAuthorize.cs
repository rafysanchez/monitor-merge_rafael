using Prodesp.Gsnet.Monitor.CrossCutting.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Prodesp.Gsnet.Monitor.Presentation.MVC.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class RbacAuthorize : AuthorizeAttribute
    {
        public RbacAuthorize()
        {

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            string accessToken = filterContext.RequestContext.HttpContext.Request.Headers.Get("AccessToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                // verifica se o token ainda é valido
                this.ValidarToken(accessToken);

                // extrai as informações de usuario do token , necessarias para criar a identidade
                var informacoes = this.ExtrairInformacoesToken(accessToken);

                this.GerarIdentidade(informacoes);
            }
            base.OnAuthorization(filterContext);
        }

        public void ValidarToken(string token)
        {

        }

        public object ExtrairInformacoesToken(string token)
        {
            return null;
        }

        public void GerarIdentidade(object dadosToken)
        {
            IIdentity identity = new ProdespIdentity("");
            HttpContext.Current.User = new ProdespPrincipal(identity);
        }
    }
}

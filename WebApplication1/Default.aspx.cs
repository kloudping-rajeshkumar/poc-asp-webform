
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var samlEndpoint = "https://login.microsoftonline.com/b8634501-c092-4bf5-8ad8-07329bfb2e90/saml2";

                var request = new AuthRequest(
                    "Dentzoft-Local", //TODO: put your app's "entity ID" here
                    "http://localhost:44311/about"
                    //"https://azuressotestkloudping.azurewebsites.net/about"//TODO: put Assertion Consumer URL (where the provider should redirect users after authenticating)
                );
                
                Response.Redirect(request.GetRedirectUrl(samlEndpoint));
            }
        }
    }
}
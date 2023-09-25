
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string samlCertificate = @"-----BEGIN CERTIFICATE-----
MIIC8DCCAdigAwIBAgIQEvYGcEvxwohLEnjWwQLIpDANBgkqhkiG9w0BAQsFADA0MTIwMAYDVQQD
EylNaWNyb3NvZnQgQXp1cmUgRmVkZXJhdGVkIFNTTyBDZXJ0aWZpY2F0ZTAeFw0yMzA5MjIxNjIw
NTVaFw0yNjA5MjIxNjIwNDZaMDQxMjAwBgNVBAMTKU1pY3Jvc29mdCBBenVyZSBGZWRlcmF0ZWQg
U1NPIENlcnRpZmljYXRlMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApXDexbKNKjbf
f77BvIaqrwXMGNOMb38HoxsospQS22EO/4+OZ78NkGhvY55pef4v5RhoN1b7bm11QRTuNLojuUpE
6exd5W1nckMCWZ6QDZW5rnxU1nrNeMyLuprQUVGKq0DNVbc3jzmqJw9plA/Juh4qPQP6UUKYZiqw
FAr6X69s4082kFKF4/Nzgr9kkMbzrn0WTEad9ZqkbaW5myBibQWPGamYvLs0ZndNHsk6s9obOja4
6PlP/dEOEC4AFJf3Fvp+WIMu7iOL5SBpXzmpN2fabKp4opq8tKD49/jnYjxj58NYvukCMSofH6g1
zBZMjnrimg99SMbpt2A3rztefQIDAQABMA0GCSqGSIb3DQEBCwUAA4IBAQBHs2UtQdSWIt5MWrJ/
gLnXMC8+PVdeHrnjf6R9craPKTtUJKHr+6dFbOevNOQVdvpyfBe3A/vi2lTthZXLLE9e8EPUIQ4y
a+aGgiQz8EFA7jSmZfcDGHAcXufVap2su1CiAS/FDakLd9uxxEMBh1mPVUyv+7wVuk04dRDdE9Oa
L7+kLzHtCEnSLM+1l7JjxRZu7pd3vOmEIC0lH6X6jFmP0sKBRv2X/cSqUt3v2lDQLLqO0hVVk7ny
f3Eb8SY/LL7Wd16K4VekInOnk+fLQ1y4qVP3rMqn9Iw7hRaHaEESw++lzvohmHwJm3zI4SZuHWIP
Zhu3HCB+y12cMxGB/Jsy
-----END CERTIFICATE-----";
            if (Request.Form.Count > 0)
            {

                var samlResponse = new Response(samlCertificate, Request.Form["SAMLResponse"]);
                if (samlResponse.IsValid()) //all good?
                {
                    Label1.Text = samlResponse.GetFirstName();
                    Label2.Text = samlResponse.GetLastName();
                    Label3.Text = samlResponse.GetEmail();
                }
                else
                {
                    

                }

            }
            else
            {
                var samlEndpoint = "https://login.microsoftonline.com/b8634501-c092-4bf5-8ad8-07329bfb2e90/saml2";

                var request = new AuthRequest(
                    "Dentzoft-Local", //TODO: put your app's "entity ID" here
                    "http://localhost:44311/926127e1-941a-453c-a775-785b5ce5a4fa/acs"
                //"https://azuressotestkloudping.azurewebsites.net/about"//TODO: put Assertion Consumer URL (where the provider should redirect users after authenticating)
                );

                Response.Redirect(request.GetRedirectUrl(samlEndpoint, "http://localhost:44311/about"));
            }
        }
    }
}
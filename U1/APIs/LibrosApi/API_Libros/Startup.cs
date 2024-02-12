using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using API_Libros_BL.Data;

namespace API_Libros
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configura el db context para usar como unica instancia por REQUEST
            app.CreatePerOwinContext(LibrosContext.Create);
        }
    }
}

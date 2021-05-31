using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Text;
using NorthwindStore.BL.DTO;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace NorthwindStore.BL.Facades
{
    public class LoginFacade : FacadeBase
    {

        public ClaimsIdentity SignIn(LoginDTO loginData, string authenticationType)
        {
            // TODO: incorporate ASP.NET Identity

            if (loginData.UserName == "admin" && loginData.Password == "admin")
            {
                return new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, "admin")
                    }, authenticationType);
            }

            return null;
        }
 
    }
}

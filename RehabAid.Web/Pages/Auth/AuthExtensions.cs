using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RehabAid.Web.Pages.Auth
{
    public static class AuthExtensions
    {
        public static async Task InitUser(this CookieSigningInContext context)
        {
            var _currentUserId = Guid.Parse(context.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var _db = (RehabAidContext)context.Request.HttpContext.RequestServices.GetService(typeof(RehabAidContext)); ;
            var user = await _db.User.FirstOrDefaultAsync(c => c.IsActive && c.Id == _currentUserId);

            var claims = new List<System.Security.Claims.Claim>();
            if (user != null)
            {

                var userType = UserType.User;
                if (user.PatientId.HasValue)
                {
                    userType = UserType.Patient;
                    claims.Add(new System.Security.Claims.Claim(ClaimsHelper.UserTypePortalId, user.PatientId.ToString()));
                }


                else if (user.StaffId.HasValue)
                {
                    userType = UserType.Staff;
                
                   

                    claims.Add(new System.Security.Claims.Claim(ClaimsHelper.UserTypePortalId, user.StaffId.ToString()));
                }
                else if (user.SpecialistId.HasValue)
                {
                    userType = UserType.Specialist;
                    claims.Add(new System.Security.Claims.Claim(ClaimsHelper.UserTypePortalId, user.SpecialistId.ToString()));
                }
                else
                {
                    userType = UserType.User;
                    claims.Add(new System.Security.Claims.Claim(ClaimsHelper.UserTypePortalId, user.Id.ToString()));
                }



                claims.Add(new System.Security.Claims.Claim(ClaimsHelper.UserTypeClaim, ((int)userType).ToString()));
            }

            if (claims.Any())
            {
                var appIdentity = new ClaimsIdentity(claims);
                context.Principal.AddIdentity(appIdentity);
            }
        }
        public static string GetId(this ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier) ?? principal.FindFirst(c => c.Type == "sub");
            if (userIdClaim != null && !string.IsNullOrEmpty(userIdClaim.Value))
            {
                return userIdClaim.Value;
            }
            return null;
        }

        public static string GetPortalId(this ClaimsPrincipal principal)
        {
            var key = principal.FindFirst(ClaimsHelper.UserTypePortalId)?.Value;

            return principal.FindFirst(ClaimsHelper.UserTypePortalId)?.Value;

        }

   

       

        public static UserType GetUserType(this ClaimsPrincipal principal)
            => (UserType)int.Parse(principal.FindFirst(ClaimsHelper.UserTypeClaim)?.Value ?? "0");

        public static UserType GetUserType(this ClaimsIdentity identity)
            => (UserType)int.Parse(identity.FindFirst(ClaimsHelper.UserTypeClaim)?.Value ?? "0");

    

        public static bool IsPatient(this ClaimsPrincipal principal)
           => principal.GetUserType().HasFlag(UserType.Patient);

        public static bool IsStaff(this ClaimsPrincipal principal)
           => principal.GetUserType().HasFlag(UserType.Staff);

        public static bool IsSpecialist(this ClaimsPrincipal principal)
           => principal.GetUserType().HasFlag(UserType.Specialist);

        public static bool IsSysUser(this ClaimsPrincipal principal)
           => principal.GetUserType().Equals(UserType.User);
    }
}

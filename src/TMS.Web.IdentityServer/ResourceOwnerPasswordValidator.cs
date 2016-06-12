using System;
using System.Threading.Tasks;
using IdentityServer4.Core.Validation;

namespace TMS.Web.IdentityServer
{
    internal class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task<CustomGrantValidationResult> ValidateAsync(string userName, string password, ValidatedTokenRequest request)
        {
            // Check The UserName And Password In Database, Return The Subject If Correct, Return Null Otherwise
            string subject = null;
            if (subject == null)
            {
                var result = new CustomGrantValidationResult("Username Or Password Incorrect");
                return Task.FromResult(result);
            }
            else
            {
                var result = new CustomGrantValidationResult(subject, "password");
                return Task.FromResult(result);
            }
        }
    }
}
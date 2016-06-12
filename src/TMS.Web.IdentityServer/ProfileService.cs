﻿using System;
using System.Threading.Tasks;
using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;

namespace TMS.Web.IdentityServer
{
    internal class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string subject = context.Subject.Claims.ToList().Find(s => s.Type == "sub").Value;
            try
            {
                // Get Claims From Database, And Use Subject To Find The Related Claims, As A Subject Is An Unique Identity Of User
                List<string> claimStringList = new List<string>();
                if (claimStringList == null)
                {
                    return Task.FromResult(0);
                }
                else
                {
                    List<Claim> claimList = new List<Claim>();
                    for (int i = 0; i < claimStringList.Count; i++)
                    {
                        claimList.Add(new Claim("role", claimStringList[i]));
                    }
                    context.IssuedClaims = claimList.Where(x => context.RequestedClaimTypes.Contains(x.Type));
                    return Task.FromResult(0);
                }
            }
            catch
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.Web.IdentityServer.UI.Consent
{
    public class ConsentInputModel
    {
        public IEnumerable<string> ScopesConsented { get; set; }
        public bool RememberConsent { get; set; }
    }
}
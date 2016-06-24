using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas.Data
{
    public class AreaDetailsPageModelInitialiserData : IInitialiserData<AreaDetailsPageModel>
    {
        public long AreaId { get; set; }
    }
}

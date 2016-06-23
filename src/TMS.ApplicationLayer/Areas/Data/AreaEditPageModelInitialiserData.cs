using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Areas;

namespace TMS.ApplicationLayer.Areas.Data
{
    public class AreaEditPageModelInitialiserData : IInitialiserData<AreaEditPageModel>
    {
        public long AreaId { get; set; }
    }
}

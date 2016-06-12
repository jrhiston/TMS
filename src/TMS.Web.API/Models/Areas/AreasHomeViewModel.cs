using System.Collections.Generic;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;

namespace TMS.Web.API.Models.Areas
{
    public class AreasHomeViewModel
    {
        public AreasHomeViewModel(IEnumerable<IArea> userAreas)
        {
            Areas = new List<AreaViewModel>();

            foreach (var area in userAreas)
            {
                Areas.Add(new AreaViewModel(area));
            }
        }

        public List<AreaViewModel> Areas { get; set; }
    }
}
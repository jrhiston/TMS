using System;
using TMS.Layer.Creators;
using TMS.ModelLayerInterface.People;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class TagForActivityCreator : ICreator<Tuple<CreateTagForActivityPageModel, IPersonKey>>
    {
        public void Create(Tuple<CreateTagForActivityPageModel, IPersonKey> model)
        {
            
        }
    }
}

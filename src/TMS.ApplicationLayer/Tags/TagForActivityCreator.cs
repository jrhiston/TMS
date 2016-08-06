using System;
using TMS.Layer.Creators;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class TagForActivityCreator : ICreator<Tuple<CreateTagForActivityPageModel, PersonKey>>
    {
        public void Create(Tuple<CreateTagForActivityPageModel, PersonKey> model)
        {
            
        }
    }
}

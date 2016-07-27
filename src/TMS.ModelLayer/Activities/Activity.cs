using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ModelLayer.Activities
{
    internal class Activity : ModelObjectBase<ActivityData>, IActivity
    {
        private string _title;
        private string _description;
        private DateTime _creationDate;

        public Activity(string title, 
            string description, 
            DateTime creationDate)
        {
            _title = title;
            _description = description;
            _creationDate = creationDate;
        }

        protected override ActivityData GetData()
        {
            return new ActivityData
            {
                Created = _creationDate,
                Description = _description,
                Title = _title
            };
        }
    }
}

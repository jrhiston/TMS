using System;

namespace TMS.LayerInterface.Activities.Reminders
{
    public interface IReminderData
    {
        //IActivityData ActivityData { get; set; }
        string Description { get; set; }
        DateTime RemindTime { get; set; }
    }
}

using System;

namespace TMS.ModelLayerInterface.Activities.Reminders
{
    public interface IReminder
    {
        IActivity Activity { get; set; }
        string Description { get; set; }
        DateTime RemindTime { get; set; }
    }
}

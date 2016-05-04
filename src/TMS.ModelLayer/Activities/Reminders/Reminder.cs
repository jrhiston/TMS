//using System;
//using TMS.LayerInterface.Activities;
//using TMS.LayerInterface.Activities.Reminders;
//using TMS.ModelLayerInterface.Activities;
//using TMS.ModelLayerInterface.Activities.Reminders;
//using TMS.ModelLayerInterface.Infrastructure.State;

//namespace TMS.ModelLayer.Activities.Reminders
//{
//    public class Reminder : TMSModelObject, IReminder, IReminderData
//    {
//        private Activity m_Activity;
//        private DateTime m_RemindTime;
//        private string m_Description;

//        public IActivity Activity
//        {
//            get
//            {
//                return m_Activity;
//            }
//            set
//            {
//                m_Activity = (Activity) value;
//                MarkAsDirty();
//            }
//        }

//        public ActivityData ActivityData
//        {
//            get
//            {
//                return m_Activity;
//            }
//            set
//            {
//                m_Activity = (Activity) value;
//            }
//        }

//        public DateTime RemindTime
//        {
//            get
//            {
//                return m_RemindTime;
//            }
//            set
//            {
//                m_RemindTime = value;
//                MarkAsDirty();
//            }
//        }

//        public string Description
//        {
//            get
//            {
//                return m_Description;
//            }
//            set
//            {
//                m_Description = value;
//                MarkAsDirty();
//            }
//        }

//        public Reminder(IStateProvider stateProvider) : base(stateProvider)
//        {

//        }
//    }
//}

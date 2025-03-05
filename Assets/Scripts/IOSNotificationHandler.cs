using UnityEngine;
using System;

#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class IOSNotificationHandler : MonoBehaviour
{
    public void ScheduleNotification(DateTime dateTime)
    {
#if UNITY_IOS
        iOSNotificationTimeIntervalTrigger timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(dateTime.Ticks - System.DateTime.Now.Ticks),
            Repeats = false
        };

        iOSNotification notification = new iOSNotification()
        {
            Title = "Energy Recharged!",
            Body = "Your energy has been recharged! Come play again!",
            Subtitle = "Your energy has been recharged!",
            ShowInForeground = true,
            ForegroundPresentationOption = PresentationOption.Alert | PresentationOption.Sound,
            CategoryIdentifier = "category_notification_energy",
            ThreadIdentifier = "thread_notification_energy",
            Trigger = timeTrigger
        };

        iOSNotificationCenter.ScheduleNotification(notification);
#endif
    }
}

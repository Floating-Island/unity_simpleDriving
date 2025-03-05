using System;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class AndroidNotificationHandler : MonoBehaviour
{
    private const string channelId = "channel_notification_energy";
    private const string channelName = "Notification Channel Energy";
    private const string channelDescription = "Channel for energy notifications";
    public void ScheduleNotification(DateTime dateTime)
    {
#if UNITY_ANDROID
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = channelId,
            Name = channelName,
            Importance = Importance.Default,
            Description = channelDescription
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Energy Recharged!",
            Text = "Your energy has been recharged! Come play again!",
            FireTime = dateTime,
            SmallIcon = "default",
            LargeIcon = "default"
        };

        AndroidNotificationCenter.SendNotification(notification, channelId);
#endif
    }
}

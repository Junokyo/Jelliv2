/*
 * Created on 2024
 *
 * Copyright (c) 2024 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using UnityEngine;
using OneSignalSDK;
using Unity.Notifications.Android;
using UnityEngine.Android;

public class NotificationManager : MonoBehaviour
{
    private void Start()
    {
        //Debug.Log("CHAY VAO DAY");
        RequestAuthorization();

        // Replace 'YOUR_ONESIGNAL_APP_ID' with your OneSignal App ID from app.onesignal.com
        OneSignal.Initialize("8b5518d9-f94a-442d-a394-bcef7631054d");
    }

    public void RequestAuthorization()
    {
        Debug.Log("RequestUserPermission : " + Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"));
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }

    }
}

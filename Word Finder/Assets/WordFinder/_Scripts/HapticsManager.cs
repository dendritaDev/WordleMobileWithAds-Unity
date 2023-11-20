using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsManager : MonoBehaviour
{
    public static HapticsManager instance;

    [Header(" Settings ")]
    private bool haptics;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void EnableHaptics()
    {
        haptics = true;
    }

    public void DisableHaptics()
    {
        haptics = false;
    }

    public static void Vibrate()
    {
        if(instance.HapticsEnabled())
        {
            //taptic.Light

            long vibrationDuration = 100;

            if (Application.platform == RuntimePlatform.Android)
            {
                // Llama a la función de vibración de Android
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject vibrator = activity.Call<AndroidJavaObject>("getSystemService", "vibrator");
                vibrator.Call("vibrate", vibrationDuration);
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                // Llama a la función de vibración de iOS
                Handheld.Vibrate();
            }
            else
            {
                Handheld.Vibrate();
                
            }

        }
    }

    public bool HapticsEnabled()
    {
        return haptics;
    }
}

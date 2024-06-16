using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Commons
{
    public static string GetTime(float time) {
        int minutes = (int) Mathf.Floor(time / 60);
        int seconds = (int) (time % 60);
        int milliseconds = (int) (time * 1000f) % 1000;
        return minutes.ToString ("D2") + ":" + seconds.ToString ("D2") + "." + milliseconds.ToString("D2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    private deathDetect[] death;
    private uiInteractions ui;
    private cameraController cc;

    void Start()
    {
        death = FindObjectsOfType<deathDetect>();
        ui = FindObjectOfType<uiInteractions>();
        cc = FindObjectOfType<cameraController>();
        foreach(deathDetect obj in death)
        {
            obj.winedLevel += ui.OpenWin;
            obj.losedLevel += ui.OpenLose;
        }
        if (cc != null)
        {
            cc.losedLevel += ui.OpenLose;
        }
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    void Start()
    {
        // Initially, settings menu is closed
        this.Close();
    }
    // Called to open the settings menu
    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    // Called to close the settings menu
    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    // UI InputField trigger (set in editor)
    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    // UI Slider trigger (set in editor)
    public void OnSpeedSlider(float speed)
    {
        // Broadcast speed change, passing speed value
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}

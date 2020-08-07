using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI system

public class UIController : MonoBehaviour
{
    // Reference to Text object
    public Text score;

    void Update()
    {
        this.score.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnClickSettings()
    {
        Debug.Log("CLICKED!");
    }
}

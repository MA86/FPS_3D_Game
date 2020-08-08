using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI system

public class UIController : MonoBehaviour
{
    // Reference to Text object
    public Text score;
    private int _score = 0;     //TODO initialize with PlayerPref?

    // Reference to script of settings menu object
    public SettingsMenu menu;

    void Start()
    {
        // Initialize UI score label
        this.score.text = this._score.ToString();
    }

    void Awake()
    {
        // Listen for "ENEMY HIT" event
        Messenger.AddListener(GameEvent.ENEMY_HIT, this.OnEnemyHit);
    }

    void OnDestroyed()
    {
        // Messenger documentation says to clean up listen when object is destroyed
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    // Called by OnClick() of Settings button (linked in editor)
    public void OnClickSettings()
    {
        menu.Open();
    }

    // Called by OnClick() of CloseMenu button (linkedin in editor)
    public void OnClickCloseMenu()
    {
        menu.Close();
    }

    private void OnEnemyHit()
    {
        // Count
        this._score += 1;

        // Print the score onto the UI label
        this.score.text = this._score.ToString();
    }
}

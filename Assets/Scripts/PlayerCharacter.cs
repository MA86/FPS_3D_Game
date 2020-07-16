using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int Health = 10;

    // Called when player takes damage
    public void Damage(int damage)
    {
        this.Health -= damage;
    }
}

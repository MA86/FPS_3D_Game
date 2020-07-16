using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 10f;
    public int Damage = 1;


    void Update()
    {
        // Move object to point in local space
        this.transform.Translate(Vector3.forward * (this.Speed * Time.deltaTime), Space.Self);
    }

    // Called when this object collides with another
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCharacter>() is PlayerCharacter player)
        {
            player.Damage(this.Damage);
        }

        // Destroy this object
        Object.Destroy(this.gameObject);
    }
}

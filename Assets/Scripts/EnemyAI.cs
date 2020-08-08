using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    // Publics
    private float Speed = 5f;
    public float ScanRange = 5f;

    // Allows editor to assign a fireball prefab
    [SerializeField] private GameObject fireballPrefab;
    
    private GameObject fireball;
    private bool _IsAlive;

   
    void Start()
    {
        // Initial FSM state is alive
        this._IsAlive = true;
    }

    // Subscribe here (good practice)
    void Awake()
    {
        // Listen to UI speed change event (subscribe!)
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedSlider);
    }

    // Desubscribe here (good practice)
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedSlider);
    }

    void Update()
    {
        if (this._IsAlive)
        {
            // Create a vector with direction
            Vector3 vector = Vector3.forward * (this.Speed * Time.deltaTime);

            // Move the object in the direction and distance of 'vector'
            this.transform.Translate(vector, Space.Self);

            // Create a ray
            Ray ray = new Ray(this.transform.position, this.transform.TransformDirection(Vector3.forward));

            // Stores information about object that's hit
            RaycastHit hit;

            // If an object is hit...
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                // If this object is a player
                if (hit.transform.GetComponent<PlayerCharacter>() is PlayerCharacter)
                {
                    // If fireball prefab is assigned...
                    if (this.fireballPrefab != null)
                    {
                        // If enemy has no fireball
                        if (this.fireball == null)
                        {
                            // Then prepare a projectile
                            this.fireball = Object.Instantiate<GameObject>(this.fireballPrefab);
                            this.fireball.transform.position = this.transform.TransformPoint(Vector3.forward * 1.5f);
                            this.fireball.transform.rotation = this.transform.rotation;
                        }  
                    }
                }
                else if (hit.distance < this.ScanRange)
                {
                    // Otherwise, it's an obstacle object, turn around
                    float turnAngle = Random.Range(-110f, 110f);
                    this.transform.Rotate(0f, turnAngle, 0f);
                }
            }
        }
    }

    // Called to change states
    public void IsAlive(bool alive)
    {
        this._IsAlive = alive;
    }

    // Called by broadcaster
    private void OnSpeedSlider(float x)
    {
        this.Speed = 10f * x; 
    }
}

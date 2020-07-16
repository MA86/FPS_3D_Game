using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    // Privates
    private Camera _camera;
    private Vector3 cameraCenter;
   

    void Start()
    {
        // Reference to camera
        this._camera = this.GetComponent<Camera>();
        
        // Center-point of camera
        this.cameraCenter = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0f);

        // Lock mouse in the center and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // If mouse is pressed...
        if (Input.GetMouseButtonDown(0))
        {
            // Prepare a ray from center of screen
            Ray ray = this._camera.ScreenPointToRay(this.cameraCenter);
            RaycastHit hitInfo;

            // Cast the ray...
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Fire
                StartCoroutine(this.CreateSphere(hitInfo));

                // If the object hit is the enemy...
                if (hitInfo.transform.GetComponent<EnemyCharacter>() is EnemyCharacter enemy)
                {
                    // Let enemy deal with the damage
                    enemy.ReactToHit();
                }
            }
        }
    }

    // Called to spawn a sphere on the object that the ray hit
    private IEnumerator CreateSphere(RaycastHit hit)
    {
        // Create a primitive sphere, set it's position
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        sphere.transform.position = hit.point;

        // Return after 'yield' so that Update() continues
        // Next time StartCoroutine() is called, execution starts after 'yield'
        yield return new WaitForSeconds(1f);

        Object.Destroy(sphere);
    }
}

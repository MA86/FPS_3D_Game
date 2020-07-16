using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // 'Public' variables available on Editor are serialized by Unity. To offer a 'private' 
    // variable on Editor but without ability to be modified by other scripts, use SerializeField 
    // attribute.

    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;


    // Update is called once per frame
    void Update()
    {
        // If there is no enemy on the scene...
        if (this.enemy == null)
        {
            // Instantiate an enemy prefab at specified location
            this.enemy = Object.Instantiate<GameObject>(this.enemyPrefab);
            this.enemy.GetComponent<Transform>().position = new Vector3(0f, 1f, 0f);

            // Set rotation at a random angle
            float randomAngle = Random.Range(0f, 360f);
            this.enemy.GetComponent<Transform>().Rotate(0f, randomAngle, 0f);
        }
    }
}

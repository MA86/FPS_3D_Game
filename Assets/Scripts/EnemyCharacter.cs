using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    private EnemyAI enemyAI;
 
    
    void Start()
    {
        // Reference to EnemyAI script
        this.enemyAI = this.GetComponent<EnemyAI>();
    }
    
    public void ReactToHit()
    {
        StartCoroutine(this.Die());
    }

    private IEnumerator Die()
    {
        this.enemyAI.IsAlive(false);

        this.transform.Rotate(-80f, 0f, 0f);

        yield return new WaitForSeconds(1.5f);

        Object.Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamySpawn : MonoBehaviour
{
    [SerializeField] Attacker[] Enemy;
    Coroutine Spawning;
    bool Spawn = true;
    

    // Start is called before the first frame update
    void Start()
    {
        Spawning = StartCoroutine(spawnRoutine());
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnRoutine()
    {
        // yield return new WaitForSeconds(Random.Range(1f, 5f));
        while (Spawn == true)
        {
          Attacker newEnemy = Enemy[Random.Range(0,Enemy.Length)];
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Attacker newEnemySpawn = Instantiate(newEnemy, transform.position, Quaternion.identity) as Attacker;
            newEnemySpawn.transform.parent = transform;  //serve per creare i nemici come child degli spawner
           
        }
        if ( Spawn == false)
        {
            StopAllCoroutines();
        }
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
        //Spawn = false;
    }

}


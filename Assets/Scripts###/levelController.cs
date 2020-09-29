using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int enemiesAlives  = 0;
    bool timeFinished = false;
    
    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        
        
    }

    public int EnemiesSpawned()
    {
        enemiesAlives++;
        return enemiesAlives;
    }
    public int Enemiesdeath()
    {
        enemiesAlives--;
        return enemiesAlives;
    }

    public void TimeExpired()
    {
        timeFinished = true;
        StopSpawn();
    }

    private void StopSpawn()
    {
        EnamySpawn[] spawners = FindObjectsOfType<EnamySpawn>();
        foreach(EnamySpawn spawner in spawners)
        {
            spawner.StopSpawn();
        }
    }

    private void Update()
    {
        if(timeFinished == true && enemiesAlives <= 0)
        {
            StartCoroutine(HandleWinCondition());            
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(3);

    }

    public void GameOver()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}

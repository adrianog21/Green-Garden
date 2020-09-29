using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Game Time in Seconds")]
    [SerializeField] float gameTime = 10f;
    bool timeTrigger = false;
    
    // Update is called once per frame
    void Update()
    {
        if (timeTrigger) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / gameTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= gameTime);
        if(timerFinished)
        {
            FindObjectOfType<levelController>().TimeExpired();
            timeTrigger = true;
        }
    }
}

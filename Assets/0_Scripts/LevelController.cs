using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Player player;
    void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        player = GetComponent<Player>();
    }

    
    void Update()
    {
        TimeScale();
    }

    public void TimeScale()
    {
        switch(player.counter)
        {
            case 2 :
                Time.timeScale = 1.2f;
                break;

            case 6 :
                Time.timeScale = 1.4f;
                break;

            case 10 :
                Time.timeScale = 1.6f;
                break;

            case 14 :
                Time.timeScale = 1.8f;
                break;        

        }
    }
}

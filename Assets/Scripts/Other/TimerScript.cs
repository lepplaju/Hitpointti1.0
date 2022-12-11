using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private GameObject endScreen;
    private GameObject playerObj;
    private int timeFromStart;
    void Start()
    {
        endScreen = GameObject.FindGameObjectWithTag("EndScreen");
        endScreen.SetActive(false);
        playerObj = GameObject.FindGameObjectWithTag("Player");
        timeFromStart = 0;
        InvokeRepeating("addOne", 7, 1);
    }


    private void addOne()
    {
        if (playerObj)
        {
            timeFromStart += 1;
        }
        if (!playerObj)
        {
            ShowEndScreen();
        }

        
    }
    public int getTimeFromStart()
    {
        return timeFromStart;
    }

    private void ShowEndScreen()
    {
        var text = endScreen.GetComponentInChildren<TMP_Text>();
        text.text = "You Survived for " + timeFromStart + " seconds!";
        endScreen.SetActive(true);
    }
}

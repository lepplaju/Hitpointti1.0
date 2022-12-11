using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSurvivedDisplay : MonoBehaviour
{
    [SerializeField] TimerScript timerScript;
    [SerializeField] private TMP_Text timeSurvivedText;
    private bool showInstructions =true;

    private void Start()
    {
        timerScript = timerScript = GameObject.FindWithTag("Background").GetComponent<TimerScript>();
        timeSurvivedText.text = "Use WASD to move around, Shift to sprint, Click to melee. Objective is to survive as long as possible. Good Luck!";
        Invoke("makeFalse", 7f);
    }
    // Update is called once per frame
    void Update()
    {
        if (!showInstructions)
        {
            timeSurvivedText.text = "Time Survived: " + timerScript.getTimeFromStart();
        }
        
    }
    private void makeFalse()
    {
        showInstructions = false;
    }
}

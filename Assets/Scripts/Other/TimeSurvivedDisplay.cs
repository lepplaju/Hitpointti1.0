using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSurvivedDisplay : MonoBehaviour
{
    [SerializeField] TimerScript timerScript;
    [SerializeField] private TMP_Text timeSurvivedText;

    private void Start()
    {
        timerScript = timerScript = GameObject.FindWithTag("Background").GetComponent<TimerScript>();
    }
    // Update is called once per frame
    void Update()
    {   
         timeSurvivedText.text = "Time Survived: " + timerScript.getTimeFromStart();
               
    }

}

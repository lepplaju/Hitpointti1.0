using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private int timeFromStart;
    void Start()
    {
        timeFromStart = 0;
        InvokeRepeating("addOne", 5, 1);
    }


    private void addOne()
    {
        timeFromStart += 1;
    }
    public int getTimeFromStart()
    {
        return timeFromStart;
    }
}

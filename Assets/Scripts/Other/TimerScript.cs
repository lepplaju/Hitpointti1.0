using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    private GameObject playerObj;
    private int timeFromStart;
    public bool pukkiOnElossa;
    private TMP_Text text;
    private bool showInstructions;
    void Start()
    {
        text = endScreen.GetComponentInChildren<TMP_Text>();
        text.text = "Use WASD to move around, Shift to sprint, Click to melee. Objective is to survive as long as possible. Good Luck! (Press M to toggle music)";
        Invoke("MakeFalse", 7f);
        pukkiOnElossa = true;
        //endScreen = GameObject.FindGameObjectWithTag("EndScreen");
        playerObj = GameObject.FindGameObjectWithTag("Player");
        timeFromStart = 0;
        InvokeRepeating("addOne", 7, 1);

    }
    private void LateUpdate()
    {
        if (!pukkiOnElossa)
        {
            if (Input.GetButtonDown("Restart"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }
        }
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

        if (pukkiOnElossa)
        {
            text.text = "You Survived for " + timeFromStart + " seconds!";
        }
        pukkiOnElossa = false;
        endScreen.SetActive(true);
        Invoke("ShowRestart", 3f);

    }
    public void ShowRestart()
    {
        Debug.Log("showrestart");
        text.text = "You Survived for " + timeFromStart + " seconds! Press R to try Again!";      
    }
    private void MakeFalse()
    {
        endScreen.SetActive(false);
    }
}

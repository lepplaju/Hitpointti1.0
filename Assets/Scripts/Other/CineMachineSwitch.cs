using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraZoomedOut;
    [SerializeField] private CinemachineVirtualCamera cameraFollow;
    [SerializeField] private PukkiHPController pukkiHPController;
    private void Start()
    {
        cameraFollow.Priority = 0;
        cameraZoomedOut.Priority = 1;
        pukkiHPController = GameObject.FindGameObjectWithTag("HpCanvas").GetComponent<PukkiHPController>();
        Invoke("SwitchPrio", 4f);
    }
    private void SwitchPrio()
    {
        Debug.Log("This activates");
        cameraFollow.Priority=1;
        cameraZoomedOut.Priority = 0;
    }
    private void Update()
    {
        if(pukkiHPController.getCurrentHp() <=1)
        {
            Debug.Log("not here");
            cameraFollow.Priority = 0;
            cameraZoomedOut.Priority = 1;
        }
    }
}

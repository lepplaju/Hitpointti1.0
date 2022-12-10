using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float timeToDestroy=.5f;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

}

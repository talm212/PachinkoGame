﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHole : MonoBehaviour
{
    private int i = 0;

    public Machine parent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name.StartsWith("Ball"))
        {
            i = i + 1; 
            Debug.Log("win ball " + i);
            Destroy(col.gameObject);

            this.parent.onEvent("Collision", "winHole");
        }
    }
}
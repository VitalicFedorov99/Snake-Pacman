﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float timeout = 10f;
    //public Snake snake;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeout);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
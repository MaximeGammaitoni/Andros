﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    private PrefabsLoaderManager prefabsLoaderManager;
    [Inject]
    private void Init(PrefabsLoaderManager prefabsLoaderManager)
    {
        this.prefabsLoaderManager = prefabsLoaderManager;
        Debug.Log(prefabsLoaderManager);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

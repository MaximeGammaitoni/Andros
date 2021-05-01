using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    private PrefabsLoaderManager gameManager;
    [Inject]
    private void Init(PrefabsLoaderManager gameManager)
    {
        this.gameManager = gameManager;
        Debug.LogError(gameManager.VFXLoader.VFX1);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

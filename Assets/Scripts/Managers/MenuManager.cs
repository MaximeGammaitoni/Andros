using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [HideInInspector] public static MenuManager singleton;

    [HideInInspector] public Dictionary<string, IEnumerator> coroutines;
    [HideInInspector] public delegate void MenuEventManager();
    [HideInInspector] public static event MenuEventManager SystemOnInit;



    // Declare all your service here

    public void Awake()
    {
        singleton = this;
        Debug.Log("singleton:" + singleton.ToString() + " is created");
        StartMenuManager();
    }
    private void StartMenuManager()
    {
        try
        {

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
    public void OnDisable()
    {

        //TODO : disable other game event
    }

    public void InitUnitySystem()
    {
        if (SystemOnInit != null)
        {
            Debug.Log(" GAME MANAGER INIT UNITY SYSTEM");
            SystemOnInit();
        }
    }


    public void DestroyServices()
    {
        StopAllCoroutines();
        DestroyAllManagers();
        DestroyAllClients();
        DestroyAllListeners();
        coroutines = null;
        //System.Web.HttpRuntime.UnloadAppDomain();
    }

    private void DestroyAllManagers()
    {
        // define your services here
    }
    private void DestroyAllClients()
    {

    }

    private void DestroyAllListeners()
    {

    }
}
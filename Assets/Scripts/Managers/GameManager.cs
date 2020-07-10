using States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager singleton;

    [HideInInspector] public Dictionary<string, IEnumerator> coroutines;
    [HideInInspector] public delegate void GameEventManager();
    [HideInInspector] public static event GameEventManager SystemOnInit;

    [HideInInspector] public static event GameEventManager ApplicationOnQuit;
    [HideInInspector] public static event GameEventManager ApplicationOnPause;
    [HideInInspector] public static event GameEventManager ApplicationOnFocus;

    [HideInInspector] public static event GameEventManager GameUpdate;
    [HideInInspector] public static event GameEventManager GameFixedUpdate;


    // Declare all your service here
    [HideInInspector] public PlayerEvents PlayerEvents { get; set; }
    [HideInInspector] public StatesEvents StatesEvents { get; set; }
    [HideInInspector] public ResourcesLoader ResourcesLoader { get; set; }
    [HideInInspector] public ScoreManager ScoreManager { get; set; }
    [HideInInspector] public StatesManager StatesManager { get; set; }

    public void Awake()
    {
        GameUpdate = null;
        GameFixedUpdate = null;
        singleton = this;
        Debug.Log("singleton:" + singleton.ToString() + " is created");
        StartGameManager();
    }
    private void StartGameManager()
    {
        try
        {
            EventsManager.Init();
            ResourcesLoader = new ResourcesLoader();
            
            ScoreManager = new ScoreManager();
            PlayerEvents = new PlayerEvents();
            StatesEvents = new StatesEvents();
            StatesManager = new StatesManager();
            EventsManager.StartListening("OnBeginIn", testBeginInEvent);
            EventsManager.StartListening("OnBeginOut", testBeginOutEvent);
            EventsManager.StartListening("OnRunIn", testRunInEvent);
            StatesManager.CurrentState = new Begin();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void testBeginInEvent(Args args)
    {
        Debug.Log("beginIn");
        StatesManager.CurrentState = new Run();
    }
    public void testBeginOutEvent(Args args)
    {
        Debug.Log("beginOut");
       
    }
    public void testRunInEvent(Args args)
    {
        Debug.Log("runIn");
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

    private void Update()
    {
        GameUpdate?.Invoke();

    }

    private void OnMouseDown()
    {

    }

    private void FixedUpdate()
    {
        GameFixedUpdate?.Invoke();
    }
    public void StartCouroutineInGameManager(IEnumerator routine, string routineName)
    {
        if (coroutines == null)
        {
            coroutines = new Dictionary<string, IEnumerator>();
        }
        if (coroutines != null && !coroutines.ContainsKey(routineName))
        {
            Coroutine co = StartCoroutine(routine);
            coroutines.Add(routineName, routine);
        }
        else if (coroutines != null && coroutines.ContainsKey(routineName))
        {
            StopCouroutineInGameManager(routineName);
            Coroutine l_co = StartCoroutine(routine);
            coroutines.Add(routineName, routine);
        }
    }
    public void StartCouroutineInGameManager(IEnumerator routine)//Coroutine avec arret automatique du MonoBehavior
    {
        StartCoroutine(routine);
    }
    public void StopCouroutineInGameManager(string coroutineName)
    {
        if (coroutines.ContainsKey(coroutineName))
        {
            StopCoroutine(coroutines[coroutineName]);
            coroutines.Remove(coroutineName);
        }
    }

    void OnApplicationQuit()
    {
        ApplicationOnQuit?.Invoke();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            ApplicationOnFocus?.Invoke();
        }
        else
        {
            ApplicationOnPause?.Invoke();
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
    public GameObject InstantiateInGameManager(UnityEngine.Object original, Vector3 position, Quaternion rotation)
    {
        var go = Instantiate(original, position, rotation) as GameObject;
        return go;
    }
}
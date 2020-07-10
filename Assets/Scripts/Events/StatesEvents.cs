using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatesEvents
{
    public StatesEvents()
    {
        EventsManager.StartListening("OnBeginIn", OnBeginIn);
        EventsManager.StartListening("OnBeginOut", OnBeginOut);

        EventsManager.StartListening("OnRunIn", OnRunIn);
        EventsManager.StartListening("OnRunOut", OnRunOut);

        EventsManager.StartListening("OnWinIn", OnWinIn);
        EventsManager.StartListening("OnWinOut", OnWinOut);

        EventsManager.StartListening("OnEndIn", OnEndIn);
        EventsManager.StartListening("OnEndOut", OnEndOut);

        EventsManager.StartListening("OnPauseIn", OnPauseIn);
        EventsManager.StartListening("OnPauseOut", OnPauseOut);
        Debug.Log(GameManager.singleton.ScoreManager?.MyString);
    }

    public  UnityAction<Args> OnBeginIn;
    public  UnityAction<Args> OnBeginOut;

    public  UnityAction<Args> OnRunIn;
    public  UnityAction<Args> OnRunOut;

    public  UnityAction<Args> OnWinIn;
    public  UnityAction<Args> OnWinOut;

    public  UnityAction<Args> OnEndIn;
    public  UnityAction<Args> OnEndOut;

    public UnityAction<Args> OnPauseIn;
    public UnityAction<Args> OnPauseOut;
    public class StatesEventArgs : Args
    {
        
    }
}

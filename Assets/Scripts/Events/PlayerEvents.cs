using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    public PlayerEvents()
    {
        OnPlayerDeath += PlayerDeath;
        EventsManager.StartListening("PlayerDeath", OnPlayerDeath);
        PlayerIsDead();
    }

    public UnityAction<Args> OnPlayerDeath;
    public class PlayerDeathArgs : Args
    {
        public GameObject PlayerGo;
    }
    private void PlayerDeath(Args args)
    {
        if (args.GetType() != typeof(PlayerEvents.PlayerDeathArgs))
            throw new Exception("argument must be a PlayerDeathArgs");
        //PlayerEvents.PlayerDeathArgs _args = ((PlayerEvents.PlayerDeathArgs)args);

    }
    public void PlayerIsDead()
    {
        EventsManager.TriggerEvent("PlayerDeath", new PlayerDeathArgs { PlayerGo = new GameObject("test") });
    }

}

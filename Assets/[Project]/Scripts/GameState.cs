using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Menu,
    InGame,
    NoneSet
}

public class GameState : MonoBehaviour
{
    public static GameState instance;
    [SerializeField] State currentGameState;
    
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        SetGameState(State.Menu);
    }

    public void SetGameState(State stateToSet)
    {
        print("Set State : " + stateToSet);
        if(stateToSet == currentGameState)
            return;
        
        currentGameState = stateToSet;
        RefreshGame();
    }

    public State GetGameState()
    {
        return currentGameState;
    }

    public bool CompareSate(State toCompare)
    {
        if(currentGameState == toCompare)
            return true;
        else
            return false;
    }

#region Call by MenuElement Events
    public void SetMenuState()
    {
        SetGameState(State.Menu);
    }

    public void SetInGameState()
    {
        SetGameState(State.InGame);
    }
#endregion

    void RefreshGame()
    {
        GameManager.intance.ClearGame();
        switch (currentGameState)
        {
            case State.Menu :
                GameManager.intance.ActiveMenu();
            break;

            case State.InGame : 
                GameManager.intance.ActiveInGame();
            break;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public enum State
{
    Menu,
    InGame
}

public class GameState : MonoBehaviour
{
    public static GameState instance;
    void Awake()
    {
        instance = this;
    }
    State currentGameState;
    
    void Start()
    {
        currentGameState = State.InGame;
        SetGameState(State.Menu);
    }

    // public State gameState //! serialisable ?
    // {
    //     get
    //     {
    //         return currentGameState;
    //     }
    //     set
    //     {
    //         if(value == currentGameState)
    //             return;
            
    //         currentGameState = value;
    //     }
    // }

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

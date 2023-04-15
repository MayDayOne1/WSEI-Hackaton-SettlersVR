using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameState gameState;
    [SerializeField] VillageManager villageManager;

    private void Awake()
    {
        gameState = GameState.Playing;
        villageManager.onAllVillagersLost += GameLost;
    }

    public void GameLost()
    {
        gameState = GameState.Lost;

    }

    public enum GameState
    {
        Playing,
        Won,
        Lost
    }
}

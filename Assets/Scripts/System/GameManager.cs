using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager poolManager; 
    public Player player;
    private void Awake()
    {
        instance = this;
    }
}

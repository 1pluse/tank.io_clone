using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager poolManager; 
    public Player player;
    public Ui_Manager Ui_Manager;
    private void Awake()
    {
        instance = this;
    }
}

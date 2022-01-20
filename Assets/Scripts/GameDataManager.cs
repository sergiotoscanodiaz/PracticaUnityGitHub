using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private int score;
    private bool won;

    public int Score { get => score; set => score = value; }
    public bool Won { get => won; set => won = value; }

    private void Awake()
    {
        int numInstances = FindObjectsOfType<GameDataManager>().Length;
        if(numInstances != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

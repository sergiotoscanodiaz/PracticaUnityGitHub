using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEndManager : MonoBehaviour
{
    public TextMeshProUGUI finalTextMessage;
    private GameDataManager gameData;

    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameDataManager>();
        string finalMessage = (gameData.Won) ? "YOU WIN!!" : "YOU LOSE!!";
        if (gameData.Won) finalMessage += " Score:" + gameData.Score;

        finalTextMessage.text = finalMessage;
    }


}

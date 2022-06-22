using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI bestScore;

    private void Start()
    {
        SaveBestScore();
    }
    public void SaveName()
    {
        Manager.Instance.playerName = inputName.text;
    }
    public void SaveBestScore()
    {
        bestScore.text = "Best score: " + Manager.Instance.bestPlayerName + " " + Manager.Instance.score;
    }
}

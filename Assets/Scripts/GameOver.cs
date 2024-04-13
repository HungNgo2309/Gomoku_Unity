using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text winnerName;
    public Button restart;
    public void SetName(string s)
    {
        winnerName.text = s;
    }
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Awake()
    {
        restart.onClick.AddListener(OnClick);
    }
}

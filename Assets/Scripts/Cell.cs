using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public int row;
    public int column;
    private Board board;
    public Sprite xSprite;
    public Sprite oSprite;
    private Image image;
    private Button button;
    public GameObject gameOverWindow;
    private Transform canvas;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void Start()
    {
        board = FindObjectOfType<Board>();
        canvas = FindObjectOfType<Canvas>().transform;
    }
    public void ChangeImage(string s)
    {
        if (s == "x")
            image.sprite = xSprite;
        else
            image.sprite = oSprite;
    }
    public void OnClick()
    {
        ChangeImage(board.currentturn);
        if(board.Check(this.row, this.column))
        {
            GameObject window= Instantiate(gameOverWindow,canvas);
            window.GetComponent<GameOver>().SetName(board.currentturn);
        }
        if (board.currentturn == "x")
            board.currentturn = "o";
        else
            board.currentturn = "x";
    }
}

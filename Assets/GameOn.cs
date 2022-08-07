using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOn : MonoBehaviour
{
    private int Points = 0;
    private bool gameFinished = true;
    private int Level = 0;
    private Text points_texto;
    private Text big_texto;
    public GameObject PointsText;
    public GameObject BigText;
    public GameObject Block;
    public GameObject Ball;
    public GameObject PlayAgainButton;
    public GameObject Platform;

    private string[] levels = {
        "11,00,00,00,00,00,00,00,00,15",

        "20,30,40,50,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "10,10,10,10,10,10,10,10,10,10;" +
        "11,12,10,10,10,10,10,10,10,10;" +
        "10,23,33,44,55,66,77,88,99,10;"
    };

    void Start()
    {
        points_texto = PointsText.GetComponent<Text>();
        big_texto = BigText.GetComponent<Text>();
        big_texto.text = "Artzkanoid";
        //GameObject ball_just_created = CreateBall();
        //ball_just_created.transform.parent = Platform.transform;
    }

    public void RestartGame()
    {
        Debug.Log("!!!");
        Level = 0;
        Points = 0;

        BeginGame();
    }

    void BeginGame()
    {
        PlayAgainButton.SetActive(false);
        big_texto.text = "Start!";
        foreach (var block in GameObject.FindGameObjectsWithTag("Block")) Destroy(block);
        foreach (var ball in GameObject.FindGameObjectsWithTag("Ball")) Destroy(ball);
        CreateLevel(Level);
        CreateBall();
        gameFinished = false;
        StartCoroutine(ReallyStart());
    }

    IEnumerator ReallyStart()
    {
        Debug.Log("Really Start");
        yield return new WaitForSeconds(.1f);
        big_texto.text = "";
    }

    void FixedUpdate()
    {
        if (gameFinished) return;
        if(GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            big_texto.text = "You Win!";
            gameFinished = true;
            Level++;
            if(Level < levels.Length)
            {
                BeginGame();
                StartCoroutine(ReallyStart());
                gameFinished = false;
            }
        }

        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            big_texto.text = "Game Over";
            PlayAgainButton.SetActive(true);
            gameFinished = true;
        }
    }

    private void CreateLevel(int level)
    {
        string[] lines = levels[level].Split(';');
        for(int i = 0; i < lines.Length; i++)
        {
            string[] blocks = lines[i].Split(',');
            for(int j = 0; j < blocks.Length; j++)
            {
                if (blocks[j] != "00" && blocks[j] != "")
                {
                    GameObject bloco = Instantiate(Block, new Vector2(0, 0), Quaternion.identity);
                    bloco.GetComponent<SquareDie>().ChangeObject($"{j}-{i}-{blocks[j]}");
                }
            }
        }
    }

    private GameObject CreateBall()
    {
        var ball = Instantiate(Ball, new Vector2(0, -3.64f), Quaternion.identity);
        ball.GetComponent<Moves>().Begin();
        return ball;
    }

    public void AddPoints(int points)
    {
        Points += points;
        points_texto.text = $"Pontos: {Points}";
    }
}

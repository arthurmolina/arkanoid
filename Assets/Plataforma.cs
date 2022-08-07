using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform transf;
    public float velocity;
    public GameObject Ball;
    public GameObject LeftButton;
    public GameObject RightButton;
    private Buttons LeftButtonScript;
    private Buttons RightButtonScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();
        LeftButtonScript = LeftButton.GetComponent<Buttons>();
        RightButtonScript = RightButton.GetComponent<Buttons>();
    }

    void FixedUpdate()
    {
        rb.velocity = velocity * new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (LeftButtonScript.ButtonIsPressed() ) { GoLeft(); }
        if (RightButtonScript.ButtonIsPressed()) { GoRight(); }
    }

    public void GoLeft()
    {
        rb.velocity = velocity * new Vector3(-0.8f, 0, 0);
    }

    public void GoRight()
    {
        rb.velocity = velocity * new Vector3(0.8f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Capsule")
        {
            switch(collision.gameObject.GetComponent<Capsule>().GetPrize())
            {
                case '1': // Little Platform
                    transf.localScale = new Vector3(1, 0.379932f, 1);
                    StartCoroutine(ResetSize());
                    break;
                case '2': // Big Platform
                    transf.localScale = new Vector3(5, 0.379932f, 1);
                    StartCoroutine(ResetSize());
                    break;
                case '3': // One Ball
                    CreateBall();
                    break;
                case '4': // Two Ball
                    CreateBall();
                    CreateBall(1);
                    break;
                case '5': // Big Ball
                    foreach (var ball in GameObject.FindGameObjectsWithTag("Ball"))
                        ball.GetComponent<Transform>().localScale = new Vector3(2, 2, 2);
                    StartCoroutine(ResetBallSize());
                    break;
                case '6': // Little Ball
                    foreach (var ball in GameObject.FindGameObjectsWithTag("Ball"))
                        ball.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    StartCoroutine(ResetBallSize());
                    break;
            }

        }
    }
    IEnumerator ResetSize()
    {
        yield return new WaitForSeconds(10.0f);
        transf.localScale = new Vector3(3.200372f, 0.379932f, 1);
    }

    IEnumerator ResetBallSize()
    {
        yield return new WaitForSeconds(10.0f);
        foreach (var ball in GameObject.FindGameObjectsWithTag("Ball"))
            ball.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void CreateBall(int side = 0)
    {
        Vector2 vetor = new Vector2(0, -3.64f);
        if(side == 1 ) { vetor = new Vector2(-0.6f, -3.65f); }
        var ball = Instantiate(Ball, vetor, Quaternion.identity);
        ball.GetComponent<Moves>().Begin(side);
    }
}

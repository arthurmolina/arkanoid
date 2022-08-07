using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private char prize = '0';

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("XXXX");
    }

    public void DefinePrize(char prize)
    {
        this.prize = prize;
        switch (prize)
        {
            case '1':
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case '2':
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case '3':
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case '4':
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case '5':
                GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            case '6':
                GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case '7':
                GetComponent<SpriteRenderer>().color = Color.gray;
                break;
            case '8':
                GetComponent<SpriteRenderer>().color = Color.black;
                break;
        }
    }

    public char GetPrize()
    {
        return prize;
    }
}

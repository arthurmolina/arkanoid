using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SquareDie : MonoBehaviour
{
    private Transform transf;
    public GameObject Capsule;
    private char prize = '0';
    private float[] x = new float[10];
    private float[] y = new float[15];
    public void ChangeObject( string info )
    {
        DefineLocations();
        string[] block_info = info.Split('-');

        transf = GetComponent<Transform>();
        transf.localPosition = new Vector2(
            x[Int32.Parse(block_info[0])],
            y[Int32.Parse(block_info[1])]
            );
        ColorChange(block_info[2][0]);
        prize = block_info[2][1];
    }

    private void DefineLocations()
    {
        double var_x = (7.08 + 7.12) / 9;
        for(int i = 0; i < 10; i++ ) x[i] = (float)(-7.12 + (i * var_x));

        double var_y = (4.24 + 1.81) / 14;
        for (int i = 0; i < 15; i++) y[i] = (float)(4.24 - (i * var_y));
    }

    private void CreatePrize()
    {
        if(prize != '0')
        {
            GameObject capsule = Instantiate(Capsule, transf.position, Quaternion.identity);
            capsule.GetComponent<Capsule>().DefinePrize(prize);
        }
    }
    private void ColorChange( char color )
    {
        switch(color)
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
            default:
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject controller = GameObject.FindGameObjectsWithTag("GameController")[0];
        GameOn controller_script = controller.GetComponent<GameOn>();
        controller_script.AddPoints(10);
        CreatePrize();
        Destroy(gameObject);
    }
}

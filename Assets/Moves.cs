using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    private Rigidbody2D rig;
    private float speed = 400;
    // Start is called before the first frame update
    public void Begin(int side = 0)
    {
        rig = GetComponent<Rigidbody2D>();
        float x = 20 * Time.deltaTime * speed;
        if(side == 1)
        {
            x = -x;
        }
        rig.AddForce(new Vector2(x, 20 * Time.deltaTime * speed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

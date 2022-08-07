using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    private GameObject myself;
    Vector3 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myself = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GameOver")
        {
            Debug.Log("Game over");
            Destroy(gameObject);
            Application.Quit();

        } else
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
}

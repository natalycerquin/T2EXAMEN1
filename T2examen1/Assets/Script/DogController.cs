using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer flip;

    private string Tope = "Tope";
    float speed = 0.0f;
    private string col_suelo = "Suelo";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Transform transform = GetComponent<Transform>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tope))
        {
            speed = speed * -1;
            flip.flipX = !flip.flipX;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == col_suelo)
        {
            speed = 5.0f;
        }
    }
}

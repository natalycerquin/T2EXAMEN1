using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed = 0.0f;

     private Text puntaje;
    private int NumPuntaje;
    private string Enemigo = "Enemigo";
    // Start is called before the first frame update
    void Start()
    {
        Transform transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
       
        Destroy(this.gameObject, 3);

        puntaje = GameObject.Find("Pun").GetComponent<Text>();
        NumPuntaje = int.Parse(puntaje.text);
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5.0f;
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Enemigo))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject,0);
            NumPuntaje += 10;
            puntaje.text = NumPuntaje.ToString();
        }
    }
}

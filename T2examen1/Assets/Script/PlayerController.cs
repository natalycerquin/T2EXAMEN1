using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer flip;


    public GameObject Bullet1;
    public GameObject Bullet2;

    private int Estate = 0;
    private float speed = 0.0f;
    private int salto = 2;
    public float jumpSpeed = 1600.0f;
    private string Estado = "Estado";
    private string Gold = "Gold";
    private string Bronze = "Bronze";
    private string Silver = "Silver";

    public Text TextGold;
    public Text TextBronze;
    public Text TextSilver;
    private int puntajeGold;
    private int puntajeBronze;
    private int puntajeSilver;

    private string col_suelo = "Suelo";
    // Start is called before the first frame update
    void Start()
    {
        TextGold.text = "0";
        TextBronze.text = "0";
        TextSilver.text = "0";

        puntajeGold = int.Parse(TextGold.text);
        puntajeBronze = int.Parse(TextBronze.text);
        puntajeSilver = int.Parse(TextSilver.text);

        rb = GetComponent<Rigidbody2D>();
        Transform transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Estate = 0;
        animator.SetInteger(Estado, Estate);
        speed = 0.0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            flip.flipX = false;
            Estate = 1;
            speed = 7.0f;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetInteger(Estado, Estate);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            flip.flipX = true;
            speed = 7.0f;
            Estate = 1;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.SetInteger(Estado, Estate);

        }
        if (salto <= 1)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Estate = 2;

                animator.SetInteger(Estado, Estate);
                rb.AddForce(Vector2.up * jumpSpeed);
                salto++;
                jumpSpeed = 800.0f;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Estate = 3;
            animator.SetInteger(Estado, Estate);
        }
        if (Input.GetKeyUp(KeyCode.X))
        { 
            Debug.Log("Entro");
            var bull = flip.flipX ? Bullet1 : Bullet2;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotancion = Bullet1.transform.rotation;
            Instantiate(bull, position, rotancion);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == col_suelo)
        {
            salto = 0;
            jumpSpeed = 1600.0f;
            Estate = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Gold))
        {
            Destroy(other.gameObject);
            puntajeGold += 30;
            TextGold.text = puntajeGold.ToString();
        }
        if (other.gameObject.CompareTag(Silver))
        {
            Destroy(other.gameObject);
            puntajeSilver += 20;
            TextSilver.text = puntajeSilver.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag(Bronze))
        {
            Destroy(other.gameObject);
            puntajeBronze  += 10;
            TextBronze.text = puntajeBronze.ToString();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool moving;

    Vector3 originalPos;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Zombie"))
        {
            GameControlScript.health -= 1;
            gameObject.transform.position = originalPos;
        }
        if (col.gameObject.tag.Equals("Nivel1_Final"))
        {
            SceneManager.LoadScene(2);
        }
        if (col.gameObject.tag.Equals("Nivel2_Final"))
        {
            SceneManager.LoadScene(3);
        }
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);

        if(horizontalInput != 0)
        {
            moving = true;   
        }
        else
        {
            moving = false;
        }

        if(moving)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }
        else
        {
            body.velocity = Vector2.zero;
        }

        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(horizontalInput < -0.01f)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        /*
        if(Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }*/

        anim.SetBool("run", horizontalInput != 0);
    }
}

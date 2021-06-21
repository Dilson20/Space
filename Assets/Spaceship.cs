using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private bool isArrowUp;
    private bool isArrowDown;
    private bool isArrowLeft;
    private bool isArrowRight;
    public GameObject Explosion;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isArrowUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isArrowUp = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isArrowDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isArrowDown = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isArrowRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isArrowRight = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isArrowLeft = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isArrowLeft = false;
        }

        Vector2 moveVector = new Vector2();

        if (isArrowUp)
        {
            moveVector.y = moveSpeed;
        }

        if (isArrowDown)
        {
            moveVector.y = -moveSpeed;
        }

        if (isArrowLeft)
        {
            moveVector.x = -moveSpeed;
        }

        if (isArrowRight)
        {
            moveVector.x = moveSpeed;
        }


        rigidbody.velocity = moveVector;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Bound"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            GameObject explosion = Instantiate(Explosion);
            explosion.transform.position = transform.position;
        }
    }
}

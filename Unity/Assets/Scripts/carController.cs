using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float carSpeed;
    public float maxPos = 2.02f;
    Vector3 position;
    public uiManager ui;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
        position.x = Mathf.Clamp (position.x, -1.9f, 2.02f);
        transform.position = position;
    }

 
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyCAR")
        {
            Destroy (gameObject);
            ui.gameOverActivated();
        }
    }


    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            if (touch.position.x <middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }
           else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }


        }
        else
        {
            SetValocityZero();
        }
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void SetValocityZero()
    {
        rb.velocity = Vector2.zero;
    }

}

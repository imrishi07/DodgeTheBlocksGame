using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float mapWidth = 5f;

   

    Rigidbody2D _rb;

    private void Start()
    {
       _rb =  GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = _rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        _rb.MovePosition(newPosition);

        if (x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().EndGame();
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }


}

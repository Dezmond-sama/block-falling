using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D rb;
    public float mapWidth = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        Vector2 newPos = rb.position + Vector2.right * x;
        newPos.x = Mathf.Clamp(newPos.x, -mapWidth, mapWidth);
        rb.MovePosition(newPos);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().GameEnd();
    }
}

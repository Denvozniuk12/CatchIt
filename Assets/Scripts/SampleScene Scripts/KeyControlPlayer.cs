using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControlPlayer : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    private float speed = 20f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
    }

    void Update()
    {
        if (!Player.lose)
        {
            float moveX = Input.GetAxis("Horizontal");
            if (rb.position.x > 2.4f)
            {
                player.position = new Vector3(2.4f, rb.position.y, 0);
            }
            if (rb.position.x < -2.4f)
            {
                player.position = new Vector3(-2.4f, rb.position.y, 0);
            }
            rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        }
    }
}

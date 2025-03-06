using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    private float inputhorizontal;
    private float inputhvertical;
    private Rigidbody2D rb;
    [SerializeField] private int velocidade = 5;
    [SerializeField] Animation puloanimado;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        inputhorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 300);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputhorizontal * velocidade,rb.velocity.y);
    }
     

    void animacaopulo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animacaopulo(espaço);
        }
    }


}

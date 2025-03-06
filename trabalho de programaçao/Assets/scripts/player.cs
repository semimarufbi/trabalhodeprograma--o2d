using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float inputhorizontal;
    private Rigidbody2D rb;
    [SerializeField] private int velocidade = 5;
    [SerializeField] Animator animacao;
    public SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        animacao = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Captura o movimento horizontal do jogador
        inputhorizontal = Input.GetAxis("Horizontal");

        // Chama a fun��o para flipar o sprite (mudar dire��o)
        spriteflip(inputhorizontal);

        // Verifica se o personagem est� se movendo
        if (inputhorizontal != 0)
        {
            // Quando o personagem est� se movendo, a anima��o "andando" � ativada.
            animacao.SetBool("andando", true);
        }
        else
        {
            // Quando o personagem n�o est� se movendo, a anima��o "andando" � desativada.
            animacao.SetBool("andando", false);
        }

        // L�gica para pulo (aciona a anima��o de pulo)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 300);
            animacao.SetTrigger("espa�o");
            animacao.SetTrigger("desmuda");// Anima��o de pulo
        }
    }

    private void FixedUpdate()
    {
        // Movimenta o personagem com base no input horizontal
        rb.velocity = new Vector2(inputhorizontal * velocidade, rb.velocity.y);
    }

    // Fun��o para flipar o sprite dependendo do movimento horizontal
    public void spriteflip(float horizontal)
    {
        if (horizontal < 0)
        {
            sprite.flipX = true; // Flip para a esquerda
        }
        else if (horizontal > 0)
        {
            sprite.flipX = false; // Flip para a direita
        }
    }
}

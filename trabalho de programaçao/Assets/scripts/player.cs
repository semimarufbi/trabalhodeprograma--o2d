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

        // Chama a função para flipar o sprite (mudar direção)
        spriteflip(inputhorizontal);

        // Verifica se o personagem está se movendo
        if (inputhorizontal != 0)
        {
            // Quando o personagem está se movendo, a animação "andando" é ativada.
            animacao.SetBool("andando", true);
        }
        else
        {
            // Quando o personagem não está se movendo, a animação "andando" é desativada.
            animacao.SetBool("andando", false);
        }

        // Lógica para pulo (aciona a animação de pulo)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 300);
            animacao.SetTrigger("espaço");
            animacao.SetTrigger("desmuda");// Animação de pulo
        }
    }

    private void FixedUpdate()
    {
        // Movimenta o personagem com base no input horizontal
        rb.velocity = new Vector2(inputhorizontal * velocidade, rb.velocity.y);
    }

    // Função para flipar o sprite dependendo do movimento horizontal
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Referência ao prefab que será spawnado
    public GameObject objetoPrefab;

    // Intervalo em que o objeto será spawnado
    public float intervaloDeSpawn = 2f;

    // Limites da área onde o objeto pode aparecer
    public float limiteX = 10f;
    public float limiteY = 5f;

    // A camada onde o "Ground" se encontra
    public LayerMask groundLayer;

    // Variável para o objeto instanciado
    private GameObject objetoInstanciado;

    private void Start()
    {
        // Começa a gerar o objeto aleatório
        SpawnObjeto();
    }

    // Função para spawnar o objeto
    public void SpawnObjeto()
    {
        // Gerar uma posição aleatória dentro do intervalo definido
        Vector3 posicaoAleatoria = GerarPosicaoAleatoria();

        // Verificar se a posição está livre (sem "Ground")
        while (Physics2D.OverlapCircle(posicaoAleatoria, 0.5f, groundLayer)) // 0.5f é o raio de verificação
        {
            // Se houver algo com a tag "Ground", gera uma nova posição
            posicaoAleatoria = GerarPosicaoAleatoria();
        }

        // Instancia o objeto na posição aleatória
        objetoInstanciado = Instantiate(objetoPrefab, posicaoAleatoria, Quaternion.identity);
    }

    // Função para gerar uma posição aleatória
    private Vector3 GerarPosicaoAleatoria()
    {
        // Gerar uma posição aleatória dentro dos limites
        float posX = Random.Range(-limiteX, limiteX);
        float posY = Random.Range(-limiteY, limiteY);
        return new Vector3(posX, posY, 0f); // Considerando o eixo Z 0 (2D)
    }

    // Função para ser chamada quando o objeto for coletado
    public void ColetarObjeto()
    {
        // Destrói o objeto instanciado após ser coletado
        if (objetoInstanciado != null)
        {
            Destroy(objetoInstanciado);
            // Depois de coletar, spawnar outro objeto
            SpawnObjeto();
        }
    }
}

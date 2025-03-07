using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Refer�ncia ao prefab que ser� spawnado
    public GameObject objetoPrefab;

    // Intervalo em que o objeto ser� spawnado
    public float intervaloDeSpawn = 2f;

    // Limites da �rea onde o objeto pode aparecer
    public float limiteX = 10f;
    public float limiteY = 5f;

    // A camada onde o "Ground" se encontra
    public LayerMask groundLayer;

    // Vari�vel para o objeto instanciado
    private GameObject objetoInstanciado;

    private void Start()
    {
        // Come�a a gerar o objeto aleat�rio
        SpawnObjeto();
    }

    // Fun��o para spawnar o objeto
    public void SpawnObjeto()
    {
        // Gerar uma posi��o aleat�ria dentro do intervalo definido
        Vector3 posicaoAleatoria = GerarPosicaoAleatoria();

        // Verificar se a posi��o est� livre (sem "Ground")
        while (Physics2D.OverlapCircle(posicaoAleatoria, 0.5f, groundLayer)) // 0.5f � o raio de verifica��o
        {
            // Se houver algo com a tag "Ground", gera uma nova posi��o
            posicaoAleatoria = GerarPosicaoAleatoria();
        }

        // Instancia o objeto na posi��o aleat�ria
        objetoInstanciado = Instantiate(objetoPrefab, posicaoAleatoria, Quaternion.identity);
    }

    // Fun��o para gerar uma posi��o aleat�ria
    private Vector3 GerarPosicaoAleatoria()
    {
        // Gerar uma posi��o aleat�ria dentro dos limites
        float posX = Random.Range(-limiteX, limiteX);
        float posY = Random.Range(-limiteY, limiteY);
        return new Vector3(posX, posY, 0f); // Considerando o eixo Z 0 (2D)
    }

    // Fun��o para ser chamada quando o objeto for coletado
    public void ColetarObjeto()
    {
        // Destr�i o objeto instanciado ap�s ser coletado
        if (objetoInstanciado != null)
        {
            Destroy(objetoInstanciado);
            // Depois de coletar, spawnar outro objeto
            SpawnObjeto();
        }
    }
}

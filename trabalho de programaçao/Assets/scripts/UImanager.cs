using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Para utilizar o Text no Unity

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pontosText;  // Refer�ncia ao componente Text no UI
    private int pontos = 0;  // A pontua��o do jogador

    private void Start()
    {
        // Inicializa a pontua��o na UI
        AtualizarPontos();
    }

    // Fun��o para aumentar os pontos
    public void AdicionarPontos(int quantidade)
    {
        pontos += quantidade;  // Adiciona a quantidade de pontos coletados
        AtualizarPontos();  // Atualiza o texto na UI
    }

    // Fun��o para atualizar o texto de pontos na UI
    private void AtualizarPontos()
    {
        pontosText.text = "Pontos: " + pontos.ToString();  // Atualiza o texto com a pontua��o
    }
}

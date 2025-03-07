using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Para utilizar o Text no Unity

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pontosText;  // Referência ao componente Text no UI
    private int pontos = 0;  // A pontuação do jogador

    private void Start()
    {
        // Inicializa a pontuação na UI
        AtualizarPontos();
    }

    // Função para aumentar os pontos
    public void AdicionarPontos(int quantidade)
    {
        pontos += quantidade;  // Adiciona a quantidade de pontos coletados
        AtualizarPontos();  // Atualiza o texto na UI
    }

    // Função para atualizar o texto de pontos na UI
    private void AtualizarPontos()
    {
        pontosText.text = "Pontos: " + pontos.ToString();  // Atualiza o texto com a pontuação
    }
}

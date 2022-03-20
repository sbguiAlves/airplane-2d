using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemGameOver;
    [SerializeField]
    private Text valorRecorde;
    [SerializeField]
    private Image posicaoMedalha;
    [SerializeField]
    private Sprite medalhaOuro;
    [SerializeField]
    private Sprite medalhaPrata;
    [SerializeField]
    private Sprite medalhaBronze;

    private Pontuacao pontuacao;
    private int recorde;

    private void Start()
    {
        pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void AtualizarInterfaceGrafica()
    {
        recorde = PlayerPrefs.GetInt("recorde");
        valorRecorde.text = recorde.ToString();
        VerificarCorMedalha();
    }

    public void MostrarInterface()
    {
        Time.timeScale = 0;
        AtualizarInterfaceGrafica();
        imagemGameOver.SetActive(true);
    }

    public void EsconderInterface()
    {
        imagemGameOver.SetActive(false);
    }

    private void VerificarCorMedalha()
    {
        if (pontuacao.Pontos > recorde - 2)
        {
            posicaoMedalha.sprite = medalhaOuro;
            //Medalha de Ouro
        }
        else if (pontuacao.Pontos > recorde / 2)
        {
            posicaoMedalha.sprite = medalhaPrata;
            //Medalha de Prata
        }
        else
        {
            posicaoMedalha.sprite = medalhaBronze;
            //Medalha de Bronze
        }
    }
}

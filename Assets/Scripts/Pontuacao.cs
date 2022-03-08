using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    private int pontos;
    [SerializeField]
    private Text textoPontuacao;

    private AudioSource audioPontuacao;

    private void Awake() {
        this.audioPontuacao = this.GetComponent<AudioSource>();
    }

    public void AdicionarPontos()
    {
        this.pontos++;
        textoPontuacao.text = pontos.ToString();
        audioPontuacao.Play();
    }

    public void ReiniciarPontos()
    {
        pontos = 0;
        textoPontuacao.text = pontos.ToString();
    }
}

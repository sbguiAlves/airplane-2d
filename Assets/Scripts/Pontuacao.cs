using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public int Pontos{ get; private set;}
    [SerializeField]
    private Text textoPontuacao;

    private AudioSource audioPontuacao;

    private void Awake() {
        this.audioPontuacao = this.GetComponent<AudioSource>();
    }

    public void AdicionarPontos()
    {
        this.Pontos++;
        textoPontuacao.text = Pontos.ToString();
        audioPontuacao.Play();
    }

    public void ReiniciarPontos()
    {
        Pontos = 0;
        textoPontuacao.text = Pontos.ToString();
    }

    public void SalvarRecorde()
    {
        int recordeAtual = PlayerPrefs.GetInt("recorde");

        if(Pontos > recordeAtual)
        {
            PlayerPrefs.SetInt("recorde", this.Pontos);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    private JogadorAviao jogadorAviao;
    private Pontuacao pontuacao;
    private InterfaceGameOver interfaceGameOver;

    private void Start() //acionado quando a cena inteira foi criada
    {
        interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
        jogadorAviao = GameObject.FindObjectOfType<JogadorAviao>(); //pega um objeto só. Busca a dependencia dentro da cena inteira
        pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        pontuacao.SalvarRecorde();
        interfaceGameOver.MostrarInterface();
    }

    public void ReiniciarJogo()
    {
        interfaceGameOver.EsconderInterface();
        Time.timeScale = 1;
       // this.aviao.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.ReiniciarPontos();
    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>(); //pega varios objetos do tipo

        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}

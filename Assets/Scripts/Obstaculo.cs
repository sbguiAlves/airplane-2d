using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.05f;
    [SerializeField]
    private float variacaoDaPosicaoY;
    private Vector3 posicaoDoAviao;
    private bool pontuei;
    private Pontuacao pontuacao;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }

    private void Start()
    {
        pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.posicaoDoAviao = GameObject.FindObjectOfType<Aviao>().transform.position;
    }

    private void Update()
    {
        /*O obstaculo movimenta-se para esquerda de acordo com o tempo*/
        this.transform.Translate(Vector3.left * velocidade * Time.deltaTime);

        if(!pontuei && this.transform.position.x < posicaoDoAviao.x)
        {
            pontuei = true;
            pontuacao.AdicionarPontos();
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        Destruir();
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}

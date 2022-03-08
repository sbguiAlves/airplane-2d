using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    private Vector3 posicaoInicial; 
    private float tamanhoRealDaImagem;

    private void Awake() {
        posicaoInicial = this.transform.position;
        float tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x;
        float escala = this.transform.localScale.x;

        tamanhoRealDaImagem = tamanhoDaImagem * escala;
    }

    private void Update()
    {
        float deslocamento = Mathf.Repeat(velocidade * Time.time,this.tamanhoRealDaImagem); //loop os numeros entre 0 e o tamanho da imagem
        this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
    }
}

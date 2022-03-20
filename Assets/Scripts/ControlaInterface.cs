using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    private JogadorAviao scriptJogadorAviao;

    [SerializeField]
    private GameObject painelDeVidas;

    [HideInInspector]
    public int quantidadeDeVidas = 0;
    private int indiceSprite;

    private void Start()
    {
        scriptJogadorAviao = GameObject.FindWithTag("Jogador").GetComponent<JogadorAviao>();
        quantidadeDeVidas = scriptJogadorAviao.statusAviao.VidaAviao;
    }

    public void AtualizarQuantidadeDeVidas()
    {
        quantidadeDeVidas--;
        painelDeVidas.transform.GetChild(quantidadeDeVidas).gameObject.SetActive(false);
        /*
        Tem a quantidade de vidas, por exemplo, quatro vidas
        Se ele sofre dano, ele tem que perder uma vida e isso na UI
        significa que o ultimo filho tem que chamar o método Set enable para falso
        
        */
    }

}

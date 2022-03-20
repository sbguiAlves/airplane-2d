using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    [SerializeField]
    private float cadenciaDoTiro = 1;
    [SerializeField]
    private float tempoDeRecarga = 3;
    [SerializeField]
    private float municaoDaArma = 3;
    [SerializeField]
    private GameObject canoDaArma;
    [SerializeField]
    private GameObject bala;

    private bool atirou;
    private Vector3 direcao;

    private float trocarDirecao = 1;

    private MovimentarAviao movimentaInimigo;
    private Status statusInimigo;

    private void Start()
    {
        statusInimigo = GetComponent<Status>();
        movimentaInimigo = GetComponent<MovimentarAviao>();
        atirou = false;
    }

    private void FixedUpdate()
    {
        movimentaInimigo.Movimentar(Vector2.up * trocarDirecao, statusInimigo.VelocidadeAviao);

        if (!atirou)
        {
            StartCoroutine(Atirar());
        }
    }

    //Cadencia da cadencia. Dar espaço para o jogador se preparar para outra leva de tiros
    private IEnumerator Atirar() //ver se dá pra fazer uma interface pra n quer q repetir função
    {
        atirou = true;
        for (int i = 0; i < municaoDaArma; i++)
        {
            direcao = new Vector3(canoDaArma.transform.position.x, canoDaArma.transform.position.y, 0f);
            Instantiate(bala, direcao, Quaternion.identity);
            yield return new WaitForSecondsRealtime(cadenciaDoTiro);
        }

        float temp = trocarDirecao;
        trocarDirecao = 0;

        yield return new WaitForSeconds(tempoDeRecarga);

        trocarDirecao = temp;
        atirou = false;
    }

    public void TomarDano()
    {
        //Dar o dano no aviao inimigo
        //Se o total de vida zerar, chefao é derrota e dá condição de vitória
    }

    public void Destruir()
    {

    }

    private void OnTriggerEnter2D(Collider2D objetoDeColisao)
    {
        if (objetoDeColisao.name == "BordaMaxima")
            trocarDirecao = -1;

        if (objetoDeColisao.name == "BordaMinima")
            trocarDirecao = 1;
    }

}
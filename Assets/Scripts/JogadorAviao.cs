using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorAviao : MonoBehaviour
{
    //private Animator animacao;
    //private Diretor diretor;

    private MovimentarAviao movimento;
    private Vector2 direcao;

    public ControlaInterface scriptControlaInterface;
    public InterfaceGameOver scriptInterfaceGameOver;
    public Status statusAviao;

    [SerializeField]
    private ParticleSystem fumacaDefeitoAviao;

    private bool isFlying;

    private void Start()
    {
        isFlying = true;
        //this.diretor = GameObject.FindObjectOfType<Diretor>(); //pega um objeto só. Busca a dependencia dentro da cena inteira
        //this.animacao = GetComponent<Animator>();
        movimento = GetComponent<MovimentarAviao>();
        statusAviao = GetComponent<Status>();
        fumacaDefeitoAviao = GetComponentInChildren<ParticleSystem>();

    }

    /*Fixed Update: normalmente usado para Rigidbody por trabalhar com taxas de quadro fixo
    em vez de taxas variadas (30,45,60, 120fps, etc.), evitando que haja atrasos em respostas
    da física nos objetos
    
    - Inputs devem ser executados dentro do Update (boa prática). Assim, utiliza-se
    gatilhos no Update para atualizar o status no Fixed Update*/

    private void Update()
    {
        if (isFlying == true)
        {
            //float eixoX = Input.GetAxis("Horizontal");
            float eixoY = Input.GetAxis("Vertical");

            direcao = new Vector2(0, eixoY);
        }
        else
        {
            movimento.Cair();
        }

        // if (Input.GetButtonDown("Jump"))
        // {
        //      TomarDano();
        //  }

        //a animação sempre vai tá rodando

        //animacao.SetFloat("VelocidadeY", fisica.velocity.y);
    }

    private void FixedUpdate()
    {
        movimento.Movimentar(direcao, statusAviao.VelocidadeAviao); // mudar isso pro inspector
    }

    public void TomarDano()
    {
        statusAviao.VidaAviao--;
        scriptControlaInterface.AtualizarQuantidadeDeVidas();

        if (statusAviao.VidaAviao <= 0)
        {
            //efeito sonoro do avião caindo
            isFlying = false;
            fumacaDefeitoAviao.Play(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Fazer ele colidir com o obstáculo e parar o game
        if (colisao.tag == "Barreira")
            scriptInterfaceGameOver.MostrarInterface();

    }

    /*public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
    }*/

    /*private void Impulsionar()
    {
        /*  - velocity = zero: Impedir que as forças se acumulam na forma de velocidade, anulando-as
            - AddForce: Adiciona velocidade por meio da força da gravidade
        fisica.velocity = Vector2.zero;
        fisica.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
        this.deveImpulsionar = false; // pois o impulso já foi computado}*/

    /* private void OnCollisionEnter2D(Collision2D colisao) // as colisões só vão dar dano, e o avião pisca quando leva dano
     {
         /*  Ao colidir com um obstaculo, o objeto deixa de simular a física
             e fica parado;
         this.fisica.simulated = false;
         this.diretor.FinalizarJogo();
     }*/
}

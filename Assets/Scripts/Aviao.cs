using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{
    private Rigidbody2D fisica;

    [SerializeField] //coloca no inspector
    public float forca;

    private Diretor diretor;
    private Vector3 posicaoInicial;

    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        this.fisica = GetComponent<Rigidbody2D>(); // Busca as dependencias do proprio objeto onde esta nosso componente
        this.diretor = GameObject.FindObjectOfType<Diretor>(); //pega um objeto só. Busca a dependencia dentro da cena inteira
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            this.Impulsionar();
        }
    }

    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
    }

    private void Impulsionar()
    {
        /*  - velocity = zero: Impedir que as forças se acumulam na forma de velocidade, anulando-as
            - AddForce: Adiciona velocidade por meio da força da gravidade*/
        fisica.velocity = Vector2.zero;
        fisica.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        /*  Ao colidir com um obstaculo, o objeto deixa de simular a física
            e fica parado;*/
        this.fisica.simulated = false;
        this.diretor.FinalizarJogo();
    }
}

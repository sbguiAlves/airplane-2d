using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]
    private float velocidadeDoTiro = 20;
    private int danoDoTiro = 1;

    private Rigidbody2D rigidbodyTiro;

    private void Start()
    {
        rigidbodyTiro = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(rigidbodyTiro.tag == "Bala")
            rigidbodyTiro.MovePosition(rigidbodyTiro.position + Vector2.right * velocidadeDoTiro * Time.deltaTime);
        if(rigidbodyTiro.tag == "Obstaculo")
            rigidbodyTiro.MovePosition(rigidbodyTiro.position + Vector2.left * velocidadeDoTiro * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D objetoDecolisao)
    {
        if(rigidbodyTiro.tag == "Bala")
        {
            switch(objetoDecolisao.tag)
            {
                case "Chefe":
                //Dar Dano
                break;
                case "Obstaculo":
                Destroy(objetoDecolisao.gameObject);
                Destroy(this.gameObject);
                //Destruir a bala do inimigo
                break;
            }
            //Destroy(this.gameObject)/
        }
    }
}

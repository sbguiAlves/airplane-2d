using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarAviao : MonoBehaviour
{
    private Rigidbody2D meuRigidBody;

    private float velocidadeDeQueda = 50;
    private Vector2 direcaoDeQueda;

    private void Awake()
    {
        meuRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Movimentar(Vector2 direcao, float velocidade)
    {
        meuRigidBody.MovePosition(meuRigidBody.position + direcao.normalized * velocidade * Time.deltaTime);
    }

    /*public void Morrer()
    {
        meuRigidBody.constraints = RigidbodyConstraints2D.None;
        meuRigidBody.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
    }*/

    public void Cair()
    {
        meuRigidBody.constraints = RigidbodyConstraints2D.None;
        meuRigidBody.AddForce(meuRigidBody.position + Vector2.right * velocidadeDeQueda * Time.time);
        meuRigidBody.gravityScale = 20; // já multiplicado por uma massa fictícia 
    }

}

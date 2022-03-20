using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    [SerializeField]
    private GameObject canoDaArma;
    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private AudioClip somDoTiro;
    [SerializeField]
    private float tempoDeRecarga = 1f;

    private bool estaAtirando;
    private Vector3 direcao;

    private void Start()
    {
        estaAtirando = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !estaAtirando)
        {
            StartCoroutine(Atirar());
        }
    }

    private IEnumerator Atirar()
    {
        direcao = new Vector3(canoDaArma.transform.position.x, canoDaArma.transform.position.y, 0f);
        //Audio do tiro
        estaAtirando = true;
        Instantiate(bala, direcao, Quaternion.identity);
        yield return new WaitForSeconds(tempoDeRecarga);
        estaAtirando = false;
    }
}

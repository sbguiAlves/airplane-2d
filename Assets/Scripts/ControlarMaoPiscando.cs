using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarMaoPiscando : MonoBehaviour
{
    private SpriteRenderer imagem;

    private void Awake()
    {
        imagem = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) //vou mudar para uma interface com a barra de espaço
        {
            Desaparecer();
        }

    }

    private void Desaparecer()
    {
        imagem.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int VidaInicialAviao = 5;
    public float VelocidadeAviao = 10;

    [HideInInspector]
    public int VidaAviao;

    private void Awake()
    {
        VidaAviao = VidaInicialAviao;
    }
}

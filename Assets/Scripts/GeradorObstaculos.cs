using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerar;
    private float cronometro;
    [SerializeField]
    private GameObject Obstaculo;

    private void Awake() {
        cronometro = tempoParaGerar;
    }

    private void Update()
    {
        cronometro -= Time.deltaTime;

        if(cronometro < 0)
        {
            GameObject.Instantiate(Obstaculo,transform.position,Quaternion.identity);
            cronometro = tempoParaGerar;
        }
    }
}

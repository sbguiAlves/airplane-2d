using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDificuldade : MonoBehaviour
{
    [SerializeField]
    private float tempoParaDificuldadeMaxima;
    private float contadorDeTempo;
   
   /*   Get: método público
        private set: método privado, ninguem pode atribuir valores*/
    public float Dificuldade{get; private set;} 

    private void Update() {
        contadorDeTempo += Time.deltaTime;
        Dificuldade = contadorDeTempo / tempoParaDificuldadeMaxima;
        Dificuldade = Mathf.Min(1, Dificuldade);
    }
}

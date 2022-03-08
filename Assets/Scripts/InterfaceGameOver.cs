using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemGameOver;
    [SerializeField]
    private Text valorRecorde;

    private void AtualizarInterfaceGrafica()
    {
        int recorde = PlayerPrefs.GetInt("recorde");
        valorRecorde.text = recorde.ToString();
    }

    public void MostrarInterface()
    {
        AtualizarInterfaceGrafica();
        imagemGameOver.SetActive(true);
    }

    public void EsconderInterface()
    {
        imagemGameOver.SetActive(false);
    }
}

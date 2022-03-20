using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    - CreateAssetMenu: cria um botão personalizado para o atalho de Menu em Assets
    - fileName: nome padrão ao criar o asset
    - menuName: Dentro de variavel compartilhada, vai ter o submenu float
*/

[CreateAssetMenu(fileName = "variavel compartilhada", menuName = "Variavel Compartilhada / float")] 
/*
    ScriptableObject: Tudo que é acessado nesta classe é compartilhado
    com os demais objetos na cena.
*/
public class VariavelCompartilhadaFloat : ScriptableObject
{
    public float valor;
}

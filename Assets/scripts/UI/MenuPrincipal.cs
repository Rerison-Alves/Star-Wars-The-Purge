using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] public string NomeLevel;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeLevel);

    }
    public void AbrirOpcoes()
    {


    }
    public void FecharOpcoes()
    {


    }
    public void Sair()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }
}

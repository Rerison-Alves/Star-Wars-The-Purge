using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void Jogar()
    {
        levelLoader.LoadNextLevel();

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

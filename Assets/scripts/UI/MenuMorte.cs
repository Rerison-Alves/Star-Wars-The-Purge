using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMorte : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void Reiniciar()
    {
        levelLoader.LoadNewLevel(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMorte : MonoBehaviour
{
    public string cenaName;
    public void Reiniciar()
    {
        SceneManager.LoadScene(cenaName);
    }
}

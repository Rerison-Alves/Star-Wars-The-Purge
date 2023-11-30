using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenu;
    public string nomeMenu;
    public string cenaName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true; // Pausa todos os sons do jogo
    }

    void ContinueGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false; // Continua todos os sons do jogo
    }

    public void Continue()
    {
        ContinueGame();
    }
    public void Sair()
    {
        SceneManager.LoadScene(nomeMenu);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(cenaName);
        ContinueGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenu;
    public string nomeMenu;
    public string cenaName;

    // Flag para verificar se o som estava ativo antes de pausar o jogo
    private bool isAudioEnabled = true;

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

        // Salva o estado atual do AudioListener
        isAudioEnabled = AudioListener.pause;
        AudioListener.pause = true; // Pausa todos os sons do jogo
    }

    void ContinueGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;

        // Restaura o estado do AudioListener
        AudioListener.pause = isAudioEnabled;
    }

    public void Continue()
    {
        ContinueGame();
    }

    public void Sair()
    {
        Time.timeScale = 1;

        // Reseta o AudioListener antes de ir para o menu
        ResetAudioListener();

        SceneManager.LoadScene(nomeMenu);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(cenaName);
        ContinueGame();
    }

    // Método para resetar o AudioListener
    private void ResetAudioListener()
    {
        // Garante que o AudioListener está ativado ao sair
        AudioListener.pause = false;
    }
}

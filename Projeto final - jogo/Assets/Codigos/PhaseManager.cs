using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PhaseManager : MonoBehaviour
{

    public  GameObject  start;              // Game object do painel default
    public GameObject title;            // Game object do painel Titulo
    public GameObject options;            // Game object do painel Options
    public GameObject credits;            // Game object do painel de Creditos
    public bool isInTitle = false;

    // Start is called before the first frame update
    void Start()
    {
        isInTitle = true;
        title = GameObject.Find("TitleScreen");
        start = GameObject.Find("Default");
        start.SetActive(false);
        options = GameObject.Find("Options");
        options.SetActive(false);
        credits = GameObject.Find("Credits");
        credits.SetActive(false);
    }
    void Update()
    {
        if ((Mouse.current.leftButton.isPressed ||
            Mouse.current.rightButton.isPressed ||
            Mouse.current.middleButton.isPressed ||
            Keyboard.current.anyKey.wasPressedThisFrame) &&
            isInTitle == true)
        {                                         // qualquer tecla pressionada ira carregar o menu principal
            isInTitle = false;
            title.SetActive(false);
            Comeco();
            
        }
    }


    public void Fases() {                   // Desativa o painel start e ativa o phaseSelector
        start.SetActive(false);
    }

    public void Comeco()
    {                  // Deixa só o painel start ativo
        start.SetActive(true);
        title.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
    }
    public void Options()
    {                 // Desativa o painel start e ativa o options
        start.SetActive(false);
        options.SetActive(true);
    }
    public void Credits()
    {                 
        start.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
    }
    public void Exit() {                    // Fecha o jogo
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }

    public void Fase1() {                   // Carrega a fase 1
        SceneManager.LoadScene("Intro");
    }

    public void Creditos() {                   // Carrega a fase Creditos
        SceneManager.LoadScene("Creditos");
    }
    public void MenuPrincipal()
    {                                          // Alternativa para voltar ao menu principal
        SceneManager.LoadScene("Start");
    }

    public void Resolucao1280x720()
    {               // Seta a resolução em 1280x720
        Screen.SetResolution(1280, 720, true);
        Debug.Log("Nova resolucao: 1280x720");
    }

    public void Resolucao1920x1080()
    {              // Seta a resolução em 1920x1080
        Debug.Log("Nova resolucao: 1920x1080");
        Screen.SetResolution(1920, 1080, true);
    }

    public void Resolucao800x600()
    {                // Seta a resolução em 800x600
        Screen.SetResolution(800, 600, true);
        Debug.Log("Nova resolucao: 800x600");
    }

    public void Resolucao1366x768()
    {               // Seta a resolução em 1366x768
        Screen.SetResolution(1366, 768, true);
        Debug.Log("Nova resolucao: 1366x768");
    }
}

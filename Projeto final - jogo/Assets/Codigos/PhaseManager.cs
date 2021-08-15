using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PhaseManager : MonoBehaviour
{

    public  GameObject  start;              // Game object do painel default
    public GameObject title;            // Game object do painel Titulo
    public bool isInTitle = false;

    // Start is called before the first frame update
    void Start()
    {
        isInTitle = true;
        title = GameObject.Find("TitleScreen");
        start = GameObject.Find("Default");
        start.SetActive(false);
    }
    void Update()
    {
        if (Mouse.current.leftButton.isPressed ||
            Mouse.current.rightButton.isPressed ||
            Mouse.current.middleButton.isPressed ||
            Keyboard.current.anyKey.wasPressedThisFrame &&
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

    public void Comeco() {                  // Deixa só o painel start ativo
        start.SetActive(true);
        title.SetActive(false);
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
}

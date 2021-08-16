using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnHandler : MonoBehaviour
{
    private Scene scene;

    public void iniciar()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void voltar()
    {
        SceneManager.LoadScene("Start");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnHandler : MonoBehaviour
{
    private Scene scene;

    public void iniciar()
    {
        Application.LoadLevel("Fase 1");
    }
}

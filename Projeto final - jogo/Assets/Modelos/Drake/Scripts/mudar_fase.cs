using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mudar_fase : MonoBehaviour
{
    private Scene scene;
    private void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel("Fase 2");

}
}

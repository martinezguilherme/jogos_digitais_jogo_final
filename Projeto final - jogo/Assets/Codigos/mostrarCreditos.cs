using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarCreditos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel("Creditos");
        Debug.Log("Fim!");
    }
}

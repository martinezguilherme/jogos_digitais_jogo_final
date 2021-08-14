using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSeguir : MonoBehaviour
{
    public Transform alvoCamera;

    public float suavisarVelocidade = 0.125f;
    public Vector3 deslocamento;

    private void LateUpdate()
    {
        Vector3 posicaoDesejada = alvoCamera.position + deslocamento;
        Vector3 posicaoSuavisa = Vector3.Lerp(transform.position, posicaoDesejada, suavisarVelocidade);

        transform.position = posicaoSuavisa;

        transform.LookAt(alvoCamera);
    }

}

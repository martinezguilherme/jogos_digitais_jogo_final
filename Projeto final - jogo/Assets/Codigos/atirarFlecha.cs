using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirarFlecha : MonoBehaviour
{


    public GameObject Emissor;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Flecha;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float forcaFlecha;

    public float tempoEntreDisparos;

    public IEnumerator atirar()
    {
        yield return new WaitForSeconds(tempoEntreDisparos);
        FindObjectOfType<gerenciarAudio>().Reproduzir("arcoEFlecha");

        GameObject instanciaTemporariaFlecha;
        instanciaTemporariaFlecha = Instantiate(Flecha, Emissor.transform.position, Emissor.transform.rotation) as GameObject;

        instanciaTemporariaFlecha.transform.Rotate(Vector3.left * 270);


        Rigidbody corpoRogidoTemporario;
        corpoRogidoTemporario = instanciaTemporariaFlecha.GetComponent<Rigidbody>();

        corpoRogidoTemporario.AddForce(transform.forward * forcaFlecha);

        Destroy(instanciaTemporariaFlecha, 10.0f);

    }


}

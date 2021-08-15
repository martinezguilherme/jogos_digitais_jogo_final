using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoFlecha : MonoBehaviour
{

    public LayerMask camadaInimigos;
    public int danoBaseFlecha = 15;
    float raioDanoFlecha = 0.25f;

    // Update is called once per frame
    void Update()
    {
        
        Collider[] inimigosAcertados = Physics.OverlapSphere(transform.position, raioDanoFlecha, camadaInimigos);

        foreach (Collider inimigo in inimigosAcertados)
        {
            Debug.Log("Acertamos com flecha: " + inimigo.name);
            inimigo.GetComponent<inimigo>().receberDano(danoBaseFlecha);

            
            FindObjectOfType<gerenciarAudio>().Reproduzir("flechaImpacto");


            // Destroi a flecha após acertar um inimigo
            DestroyImmediate(gameObject);
        }

    }
}

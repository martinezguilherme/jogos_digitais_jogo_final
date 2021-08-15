using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matar : MonoBehaviour
{
    public Transform player;
    public LayerMask camadaInimigos;
    public int danoBaseEscudo = 50;
    float raioDanoEscudo = 1.6f;

    public void atacarEscudo()
    {
        Collider[] inimigosAcertados = Physics.OverlapSphere(player.position, raioDanoEscudo, camadaInimigos);

        foreach (Collider inimigo in inimigosAcertados)
        {
            Debug.Log("Acertamos com escudo: " + inimigo.name);
            inimigo.GetComponent<inimigo>().receberDano(danoBaseEscudo);
            FindObjectOfType<gerenciarAudio>().Reproduzir("escudoBatendo");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{

    SkeletonMovement skeletonMovement;
    public LayerMask camadaAlvos;

    public int vidaMaxima = 100;
    int vidaAtual;

    public float alcanceAtaque = 20;

    int danoBase = 20;

    // Start is called before the first frame update
    void Start()
    {
        skeletonMovement = GetComponent<SkeletonMovement>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        vidaAtual = vidaMaxima;
    }

    public void atacar()
    {
        Collider[] personagemAcertados = Physics.OverlapSphere(transform.position, alcanceAtaque, camadaAlvos);

        foreach (Collider personagem in personagemAcertados)
        {
            Debug.Log("Acertamos" + personagem.name);
            if(personagem.GetComponent<controlarPersonagem>() != null && personagem.GetComponent<controlarPersonagem>().vidaAtual > 0){
                personagem.GetComponent<controlarPersonagem>().receberDano(danoBase);
            }else if(personagem.GetComponent<PlayerManager>() != null && personagem.GetComponent<PlayerManager>().vidaAtual > 0)
            {
                personagem.GetComponent<PlayerManager>().receberDano(danoBase);
            }
        }
    }

    public void receberDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            morrer();
        }
    }

    void morrer()
    {
        Debug.Log("Inimigo " + transform.name + " morreu");
        skeletonMovement.vivo = false;
        FindObjectOfType<gerenciarAudio>().Reproduzir("skeletonMorte");
    }

    // Update is called once per frame
    void Update()
    {

        //atacar();
    }
}

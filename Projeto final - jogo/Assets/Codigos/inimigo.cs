using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{

    public LayerMask camadaAlvos;

    public int vidaMaxima = 100;
    int vidaAtual;

    public float alcanceAtaque = 20;

    int danoBase = 20;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    void atacar()
    {
        Collider[] personagemAcertados = Physics.OverlapSphere(transform.position, alcanceAtaque, camadaAlvos);

        foreach (Collider personagem in personagemAcertados)
        {
            Debug.Log("Acertamos" + personagem.name);
            personagem.GetComponent<controlarPersonagem>().receberDano(danoBase);
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
        // Chamar aqui a animação de morte do personagem
    }

    // Update is called once per frame
    void Update()
    {

        //atacar();
    }
}

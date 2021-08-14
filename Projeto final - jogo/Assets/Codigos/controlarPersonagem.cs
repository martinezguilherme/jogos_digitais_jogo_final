using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controlarPersonagem : MonoBehaviour
{
    Animator animator;

    int estaAndandoHash;
    int estaCorrendoHash;
    int estaAtacandoHash;
    int estaVivoHash;
    int espadaEquipadaHash;
    int bestaEquipadaHash;

    Controladorpersonagem entrada;

    Vector2 movimentoAtual;
    bool movimentoPressionado;
    bool correrPressionado;
    bool ataquePressionado;
    bool equiparBestaPressionado;
    bool equiparEspadaPressionado;

    string caminhoEspada = "/Anna Harris/mixamorig:RightHand/Modelo espada";
    string caminhoBesta = "/Anna Harris/mixamorig:RightHand/Modelo besta";

    public Transform pontoDeAtaque;
    public float alcanceDeAtaque = 0.5f;
    public int danoBase = 20;
    public LayerMask camadaInimigos;

    public int vidaMaxima = 100;
    int vidaAtual;




    private void Awake()
    {
        entrada = new Controladorpersonagem();
        entrada.Personagem.Mover.performed += ctx =>
        {
            movimentoAtual = ctx.ReadValue<Vector2>();
            movimentoPressionado = movimentoAtual.x != 0 || movimentoAtual.y != 0;
        };
        entrada.Personagem.Correr.performed += ctx => correrPressionado = ctx.ReadValueAsButton();
        entrada.Personagem.Atacar.performed += ctx => ataquePressionado = ctx.ReadValueAsButton();
        entrada.Personagem.Equiparbesta.performed += ctx => equiparBestaPressionado = ctx.ReadValueAsButton();
        entrada.Personagem.Equiparespada.performed += ctx => equiparEspadaPressionado = ctx.ReadValueAsButton();

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        estaAndandoHash = Animator.StringToHash("estaAndando");
        estaCorrendoHash = Animator.StringToHash("estaCorrendo");
        estaAtacandoHash = Animator.StringToHash("estaAtacando");
        estaVivoHash = Animator.StringToHash("estaVivo");
        espadaEquipadaHash = Animator.StringToHash("espadaEquipada");
        bestaEquipadaHash = Animator.StringToHash("bestaEquipada");

        vidaAtual = vidaMaxima;

    }

    // Update is called once per frame
    void Update()
    {
        movimentar();
        virar();
        atacar();
        trocarEquipamento();

    }

    void movimentar()
    {
        bool estaAndando = animator.GetBool(estaAndandoHash);
        bool estaCorrendo = animator.GetBool(estaCorrendoHash);
        bool movCorrida = movimentoPressionado && correrPressionado;

        if (!estaAndando && !estaCorrendo)
        {
            FindObjectOfType<gerenciarAudio>().pararReproducao("AndarTerra");
            FindObjectOfType<gerenciarAudio>().pararReproducao("CorrerTerra");


        }

        if (!movimentoPressionado)
        {
            animator.SetBool(estaAndandoHash, false);
        }


        if (movimentoPressionado && !estaAndando)
        {
            animator.SetBool(estaAndandoHash, true);
            FindObjectOfType<gerenciarAudio>().Reproduzir("AndarTerra");

        }

        if (!movimentoPressionado && estaAndando)
        {
            animator.SetBool(estaAndandoHash, false);
            FindObjectOfType<gerenciarAudio>().pararReproducao("AndarTerra");

        }

        if (movCorrida && !estaCorrendo)
        {
            animator.SetBool(estaCorrendoHash, true);
            FindObjectOfType<gerenciarAudio>().pararReproducao("AndarTerra");
            FindObjectOfType<gerenciarAudio>().Reproduzir("CorrerTerra");


        }

        if (!movCorrida && estaCorrendo)
        {
            animator.SetBool(estaCorrendoHash, false);
            FindObjectOfType<gerenciarAudio>().pararReproducao("CorrerTerra");
            FindObjectOfType<gerenciarAudio>().Reproduzir("AndarTerra");


        }

    }

    void trocarEquipamento()
    {
        bool espadaEquipada = animator.GetBool(espadaEquipadaHash);
        bool bestaEquipada = animator.GetBool(bestaEquipadaHash);


        if (equiparEspadaPressionado)
        {
            GameObject armaPersonagemEspada;
            GameObject armaPersonagemBesta;

            armaPersonagemEspada = GameObject.Find(caminhoEspada);
            armaPersonagemBesta = GameObject.Find(caminhoBesta);

            // Desabilita a besta caso esteja ativada
            armaPersonagemBesta.SetActive(false);
            animator.SetBool(bestaEquipadaHash, false);


            // Habilita a espada caso não esteja e desabilita caso esteja
            bool estadoAtual = armaPersonagemEspada.activeSelf;
            armaPersonagemEspada.SetActive(!estadoAtual);
            animator.SetBool(espadaEquipadaHash, !estadoAtual);
        }

        if (equiparBestaPressionado)
        {
            GameObject armaPersonagemEspada;
            GameObject armaPersonagemBesta;

            armaPersonagemEspada = GameObject.Find(caminhoEspada);
            armaPersonagemBesta = GameObject.Find(caminhoBesta);

            // Desabilita a espada caso esteja ativada
            armaPersonagemEspada.SetActive(false);
            animator.SetBool(espadaEquipadaHash, false);


            // Habilita a espada caso não esteja e desabilita caso esteja
            bool estadoAtual = armaPersonagemBesta.activeSelf;
            armaPersonagemBesta.SetActive(!estadoAtual);
            animator.SetBool(bestaEquipadaHash, !estadoAtual);
        }

    }

    void atacar()
    {
        bool estaAtacando = animator.GetBool(estaAtacandoHash);
        bool bestaEquipada = animator.GetBool(bestaEquipadaHash);
        bool espadaEquipada = animator.GetBool(espadaEquipadaHash);


        if (ataquePressionado && !estaAtacando)
        {
            animator.SetBool(estaAtacandoHash, true);

            if (espadaEquipada)
            {
                Collider[] inimigosAcertados = Physics.OverlapSphere(pontoDeAtaque.position, alcanceDeAtaque, camadaInimigos);

                FindObjectOfType<gerenciarAudio>().Reproduzir("somEspadaVento");

                foreach(Collider inimigo in inimigosAcertados)
                {
                    Debug.Log("Acertamos" + inimigo.name);
                    inimigo.GetComponent<inimigo>().receberDano(danoBase);
                    FindObjectOfType<gerenciarAudio>().Reproduzir("somEspada");
                }
            }

            if (bestaEquipada)
            {

                FindObjectOfType<gerenciarAudio>().Reproduzir("esticandoArco");
                StartCoroutine(gameObject.GetComponent<atirarFlecha>().atirar());
            }

        }

        if (!ataquePressionado && estaAtacando)
        {
            animator.SetBool(estaAtacandoHash, false);
            FindObjectOfType<gerenciarAudio>().pararReproducao("somEspadaVento");

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pontoDeAtaque.position, alcanceDeAtaque);
    }

    void virar()
    {
        Vector3 posicaoAtual = transform.position;

        Vector3 novaPosicao = new Vector3(movimentoAtual.x, 0, movimentoAtual.y);

        Vector3 posicaoOlharPara = posicaoAtual + novaPosicao;

        transform.LookAt(posicaoOlharPara);
    }

    public void receberDano(int dano)
    {
        vidaAtual -= dano;
        FindObjectOfType<gerenciarAudio>().Reproduzir("dano");

        if (vidaAtual <= 0)
        {
            morrer();
        }
    }

    void morrer()
    {
        Debug.Log("Personagem " + transform.name + " morreu");
        animator.SetBool(estaVivoHash, false);
        FindObjectOfType<gerenciarAudio>().Reproduzir("SomDeMorteFeminino");

    }

    void OnEnable()
    {
        entrada.Personagem.Enable();
    }

    void OnDisable()
    {
        entrada.Personagem.Disable();
    }
}

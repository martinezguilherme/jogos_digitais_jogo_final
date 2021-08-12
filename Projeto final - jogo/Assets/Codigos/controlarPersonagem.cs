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

    GameObject armaPersonagem;

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

        if (movimentoPressionado && !estaAndando)
        {
            animator.SetBool(estaAndandoHash, true);
        }

        if (!movimentoPressionado && estaAndando)
        {
            animator.SetBool(estaAndandoHash, false);
        }

        if (movCorrida && !estaCorrendo)
        {
            animator.SetBool(estaCorrendoHash, true);
        }

        if (!movCorrida && estaCorrendo)
            {
            animator.SetBool(estaCorrendoHash, false);
        }
    }

    void trocarEquipamento()
    {
        bool espadaEquipada = animator.GetBool(espadaEquipadaHash);

        if (equiparEspadaPressionado)
        {
            armaPersonagem = GameObject.Find("/Anna Harris/mixamorig:RightHand/Modelo espada");
            bool estadoAtual = armaPersonagem.activeSelf;
            armaPersonagem.SetActive(!estadoAtual);
            animator.SetBool(espadaEquipadaHash, !estadoAtual);
        }
    }

    void atacar()
    {
        bool estaAtacando = animator.GetBool(estaAtacandoHash);

        if (ataquePressionado && !estaAtacando)
        {
            animator.SetBool(estaAtacandoHash, true);
        }

        if (!ataquePressionado && estaAtacando)
        {
            animator.SetBool(estaAtacandoHash, false);
        }

    }

    void virar()
    {
        Vector3 posicaoAtual = transform.position;

        Vector3 novaPosicao = new Vector3(movimentoAtual.x, 0, movimentoAtual.y);

        Vector3 posicaoOlharPara = posicaoAtual + novaPosicao;

        transform.LookAt(posicaoOlharPara);
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

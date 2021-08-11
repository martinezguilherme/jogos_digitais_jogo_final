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

    Controladorpersonagem entrada;

    Vector2 movimentoAtual;
    bool movimentoPressionado;
    bool correrPressionado;
    bool ataquePressionado;

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



    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        estaAndandoHash = Animator.StringToHash("estaAndando");
        estaCorrendoHash = Animator.StringToHash("estaCorrendo");
        estaAtacandoHash = Animator.StringToHash("estaAtacando");
        estaVivoHash = Animator.StringToHash("estaVivo");
    }

    // Update is called once per frame
    void Update()
    {
        movimentar();
        virar();
        atacar();

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

    void atacar()
    {
        Debug.Log(ataquePressionado);
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

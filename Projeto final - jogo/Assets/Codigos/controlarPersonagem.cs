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

    CameraManager cameraManager;
    public Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;

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
    public float correcaoRotacao;
    public int danoBase = 20;
    public LayerMask camadaInimigos;

    public int vidaMaxima = 100;
    public int vidaAtual;

    bool usarRotacaoCamera = true;

    float tempoEntreAtaquesBesta = 3;
    float tempoAtual;




    private void Awake()
    {
        cameraManager = FindObjectOfType<CameraManager>();
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

        entrada.Personagem.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        tempoAtual = Time.time;
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
        if (animator.GetBool(estaVivoHash)){
            movimentar();
            virar();
            atacar();
            trocarEquipamento();

        }
        
        HandleCameraInput();

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


            // Habilita a espada caso n�o esteja e desabilita caso esteja
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


            // Habilita a espada caso n�o esteja e desabilita caso esteja
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

            if (bestaEquipada && Time.time - tempoAtual >= tempoEntreAtaquesBesta)
            {
                tempoAtual = Time.time;
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
        // Angulo de rotação da personagem
        float angulo = movimentoAtual.x * correcaoRotacao;

        // Segue orientação da camera caso não esteja rocionando
        if (movimentoPressionado && movimentoAtual.x == 0 && usarRotacaoCamera){
            transform.eulerAngles = FindObjectOfType<CameraManager>().transform.eulerAngles;
        }

        // Desabilita o uso da camera caso o personagem se movimente lateralmente
        if (movimentoPressionado && movimentoAtual.x != 0){
            usarRotacaoCamera = false;
        }

        // Habilita novamenta caso pare de se movimentar 
        if(movimentoAtual.y == 0 && movimentoAtual.x == 0){
            usarRotacaoCamera = true;
        }

        // Rotaciona em relação ao eixo y
        transform.Rotate(Vector3.up, angulo);
    }

    public void receberDano(int dano)
    {
        vidaAtual -= dano;
        FindObjectOfType<gerenciarAudio>().Reproduzir("dano");

        if (vidaAtual <= 0 && animator.GetBool(estaVivoHash))
        {
            morrer();
        }
    }

    void morrer()
    {
        Debug.Log("Personagem " + transform.name + " morreu");
        animator.SetBool(estaVivoHash, false);
        FindObjectOfType<gerenciarAudio>().Reproduzir("SomDeMorteFeminino");
        animator.SetBool(estaVivoHash, false);

        animator.SetBool(estaAndandoHash, false);
        animator.SetBool(estaCorrendoHash, false);
        animator.SetBool(estaAtacandoHash, false);

    }

    void OnEnable()
    {
        entrada.Personagem.Enable();
    }

    void OnDisable()
    {
        entrada.Personagem.Disable();
    }

       private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }

     private void HandleCameraInput()
    {
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }
}

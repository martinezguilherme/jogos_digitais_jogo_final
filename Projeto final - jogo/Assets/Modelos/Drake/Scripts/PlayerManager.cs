using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    CameraManager cameraManager;
    AnimatorManager animatorManager;
    PlayerLocomotion playerLocomotion;
    public bool isInteracting;
    public bool isUsingRootMotion;

    public int vidaMaxima = 100;
    public int vidaAtual;

    private void Awake()
    {
        vidaAtual = vidaMaxima;
        animatorManager = GetComponent<AnimatorManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

   private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
        isInteracting = animator.GetBool("isInteracting");
        isUsingRootMotion = animator.GetBool("isUsingRootMotion");
    }

    public void receberDano(int dano)
    {
        Debug.Log("dano");
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
        animatorManager.PlayTargetAnimation("morrendo", true, true);
        FindObjectOfType<gerenciarAudio>().Reproduzir("SomDeMorteFeminino");
        Invoke("reiniciar", 3);

    }

    void reiniciar(){
         SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }
}

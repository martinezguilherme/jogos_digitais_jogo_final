using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
public class SkeletonMovement : MonoBehaviour
{

    float tempo;

    public float tempoEntreAtaques = 1;
    private NavMeshAgent navComponent;
    private int distanciaAtrairMonstro = 10;
    public bool vivo = true;
    public Transform jogador;
    public Transform monstro;
    private Animator anim;
    public float distanciaParaAtacar = 2.7f;
    public GameObject monstroObject;
    public float velocidade;

       void Start()
    {
        tempo = Time.time;
        anim = GetComponent<Animator>();
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
    }

       void Morrer(){
        monstroObject.SetActive(false);
    }


     void Update(){
        if (vivo == true){
            if (Vector3.Distance(jogador.position, this.transform.position) < distanciaAtrairMonstro)
            {
                Vector3 direction = jogador.position - this.transform.position;
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 5.0f * Time.deltaTime);

                anim.SetBool("parado", false);
                if (direction.magnitude > distanciaParaAtacar && direction.magnitude < distanciaAtrairMonstro)
                {
                    navComponent.SetDestination(jogador.position);
                    navComponent.speed = velocidade;
                    anim.SetBool("andando", true);
                    anim.SetBool("atacando", false);
                }
                else if(direction.magnitude <= distanciaParaAtacar)
                {
                    anim.SetBool("andando", false);
                    anim.SetBool("atacando", true);
                    navComponent.speed = 0;
                    if (Time.time - tempo >= tempoEntreAtaques){
                        GetComponent<inimigo>().atacar();
                        tempo = Time.time;

                    }
                }
            }else{
                navComponent.speed = 0;
                anim.SetBool("parado", true);
                anim.SetBool("andando", false);
                anim.SetBool("atacando", false);
            }
        }else{
            anim.SetBool("morto", true);
            anim.SetBool("parado", false);
            anim.SetBool("andando", false);
            anim.SetBool("atacando", false);          
            Invoke("Morrer", 3);  
        }
 }
}


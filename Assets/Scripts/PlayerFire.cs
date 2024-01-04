using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private Animator Anim;
    private PlayerMovement playerMovement;
    [SerializeField] private float AttackCooldown;
    [SerializeField] private Transform  FirePoint;
    [SerializeField] private GameObject[]  Firekiller;
    private float Cooldowntimer = Mathf.Infinity;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            Attack();

        Cooldowntimer += Time.deltaTime;

    }

    private void Attack()
    {
        Anim.SetTrigger("Attack");
        Cooldowntimer = 0;

        Firekiller[0].transform.position = FirePoint.position;
        Firekiller[0].GetComponent<TileManager>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    
}
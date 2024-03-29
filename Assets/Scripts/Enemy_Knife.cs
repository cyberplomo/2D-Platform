using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knife : MonoBehaviour
{
   [SerializeField] private float MovementDistance;
   [SerializeField] private float speed;
   [SerializeField] private float damage;
 

   private bool movingLeft;
   private float LeftEdge;
   private float RightEdge;
   

   private void Awake()
   {
      LeftEdge = transform.position.x - MovementDistance;
      RightEdge = transform.position.x + MovementDistance;
   }

   private void Update()
   {
      if (movingLeft)
      {
         if (transform.position.x > LeftEdge)
         {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
         }
         else
            movingLeft = false;
      }
      else
      {
         if (transform.position.x < RightEdge)
         {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
         }
         else
            movingLeft = true;
      }
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.tag == "Player")
      {
         collision.GetComponent<Health>().TakeDamage(damage);
      }
   }
}

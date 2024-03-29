using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   private Inventory inventory;
   public GameObject potion;
   

   private void Start()
   {
      inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
      
   }

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         for (int i = 0; i < inventory.slots.Length; i++)
         {
            if (inventory.isFull[i] == false)
            {
               inventory.isFull[i] = true;
               Instantiate(potion, inventory.slots[i].transform, false);
               Destroy(gameObject);
               break;
            }
         }
      }
   }
}

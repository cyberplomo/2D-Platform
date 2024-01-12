using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotUse : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    // Hız artışı için orijinal hız değeri
    private float originalMoveSpeed;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        // Oyun başladığında orijinal hız değerini kaydedin
        originalMoveSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed;
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Transform child in inventory.slots[0].transform)
            {
                Destroy(child.gameObject);
            }

            // Karakter hızını artır
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed = originalMoveSpeed * 2f; // Örneğin, %20 daha hızlı
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Transform child in inventory.slots[1].transform)
            {
                Destroy(child.gameObject);
            }

            // Karakter hızını artır
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed = originalMoveSpeed * 2f; // Örneğin, %20 daha hızlı
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (Transform child in inventory.slots[2].transform)
            {
                Destroy(child.gameObject);
            }

            // Karakter hızını artır
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed = originalMoveSpeed * 2f; // Örneğin, %20 daha hızlı
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (Transform child in inventory.slots[3].transform)
            {
                Destroy(child.gameObject);
            }

            // Karakter hızını artır
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed = originalMoveSpeed * 2f; // Örneğin, %20 daha hızlı
        }

        // Diğer tuşlar için benzer şekilde devam edebilirsiniz

        // Bu kısmı ekleyerek karakterin hızını sıfırlayabilirsiniz (gerekirse)
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed = originalMoveSpeed;
        }
    }
}
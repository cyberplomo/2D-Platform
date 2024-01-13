using UnityEngine;

public class Door : MonoBehaviour
{
    // Kapı objesini tutmak için bir referans
    

    void Update()
    {
        // "e" tuşuna basıldığında
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
       
    }
}
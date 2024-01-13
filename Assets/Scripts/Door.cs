using UnityEngine;

public class Door : MonoBehaviour
{
    void Update()
    {
        // E tuşuna basıldığında
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Kapıyı yok et
            Destroy(gameObject);
        }
    }
}
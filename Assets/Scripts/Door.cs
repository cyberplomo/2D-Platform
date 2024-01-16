using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Text interactionText; 
    public float interactionDistance = 2f;

    private bool isDoorDestroyed = false;

    void Update()
    {
       
        if (!isDoorDestroyed)
        {
           
            float distanceToDoor = Vector2.Distance(transform.position, PlayerMovement.instance.transform.position);

           
            if (Input.GetKeyDown(KeyCode.E) && distanceToDoor < interactionDistance)
            {
                
                Destroy(gameObject);
                isDoorDestroyed = true;
                Destroy(interactionText);
            }

           
            if (distanceToDoor < interactionDistance)
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                interactionText.gameObject.SetActive(false);
            }
        }
       
    }
}
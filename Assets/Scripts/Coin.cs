using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public int coinCount;

    public Text coinText;

    [SerializeField] private AudioClip pickupSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            //gameObject.SetActive(false);
        }
    }
    void Update()
    {   
        coinText.text = coinCount.ToString();
    }
   

}

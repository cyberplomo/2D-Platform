using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
  [SerializeField] private AudioClip checkpointSound;
  private Transform currentCheckpoint;
  private Health playerHealth;

  private void Awake()
  {
    playerHealth = GetComponent<Health>();
  }

  public void Respawn()
  {
    transform.position = currentCheckpoint.position;
    playerHealth.Respawn();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.transform.tag == "Checkpoint")
    {
      currentCheckpoint = collision.transform;
      SoundManager.instance.PlaySound(checkpointSound);
      collision.GetComponent<Collider2D>().enabled = false;
      collision.GetComponent<Animator>().SetTrigger("appear");
    }
    else if (collision.transform.tag == "NextLevel")
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    else if (collision.transform.tag == "PreviousLevel")
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
  }
}

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
  private Vector3 respawnPoint;
  private UIManager uiManager;
  public GameObject fallDetector;

  private void Start()
  {
    respawnPoint = transform.position;
  }

  private void Update()
  {
    fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
  }

  private void Awake()
  {
    playerHealth = GetComponent<Health>();
    uiManager = FindObjectOfType<UIManager>();
  }

  public void CheckRespawn()
  {
    if (currentCheckpoint == null)
    {
      uiManager.GameOver();
      return;
    }
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
    else if (collision.transform.tag == "FallDetector")
    {
      transform.position = respawnPoint;
    }
  }
}

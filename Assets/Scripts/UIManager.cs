using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  [Header("Game Over")]
  [SerializeField] private GameObject gameOverScreen;
  [SerializeField] private AudioClip gameoverSound;
  [Header("Pause")]
  [SerializeField] private GameObject pauseScreen;
  private void Awake()
  {
    gameOverScreen.SetActive(false);
    pauseScreen.SetActive(false);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if(pauseScreen.activeInHierarchy)
        PauseGame(false);
      else
        PauseGame(true);
    }
  }

  public void GameOver()
  {
    gameOverScreen.SetActive(true);
    SoundManager.instance.PlaySound(gameoverSound);
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
  }
  public void MainMenu()
  {
    SceneManager.LoadScene(0);
    
  }
  public void Quit()
  {
    Application.Quit();

    
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #endif
  }

  public void PauseGame(bool status)
  {
    pauseScreen.SetActive(status);

   Time.timeScale = System.Convert.ToInt32(!status);
  }

  public void SoundVolume()
  {
    SoundManager.instance.ChangeSoundVolume(0.2f);
  }
  public void MusicVolume()
  {
    SoundManager.instance.ChangeMusicVolume(0.2f);
  }
}

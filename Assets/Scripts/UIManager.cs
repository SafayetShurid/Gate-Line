﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public Text scoreText;
    public Text yourScoreText;
    public GameObject soundOnButton;
    public GameObject soundOffButton;

    public AudioSource ButtonAudioSource;

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
        if(yourScoreText!=null)
        {
            yourScoreText.text = PlayerPrefs.GetInt("LastScore", 0).ToString();
        }

        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            if (soundOnButton != null)
            {
                soundOnButton.SetActive(true);
                soundOffButton.SetActive(false);
            }

        }
        else
        {
            if (soundOnButton != null)
            {
                soundOnButton.SetActive(true);
                soundOffButton.SetActive(false);
            }
        }
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("Sound", 1);
        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
    }

    public void SoundOff()
    {
        PlayerPrefs.SetInt("Sound", 0);
        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
    }
   
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonClickSound()
    {
        if(PlayerPrefs.GetInt("Sound",0)==1)
        {
            ButtonAudioSource.Play();
        }
        else
        {

        }
    }

    
}
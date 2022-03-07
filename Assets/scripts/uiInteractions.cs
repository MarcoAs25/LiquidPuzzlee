using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiInteractions : MonoBehaviour
{
    [SerializeField] public Button[] LevelButtons;
    [SerializeField] public Button ButtomMusic;
    [SerializeField] public GameObject MenuInicial, MenuFases;

    [SerializeField] public GameObject MenuPause, MenuWinLose;
    [SerializeField] public Button NextLevel;
    [SerializeField] private bool pause = true;

    [SerializeField] public int menu = 0, QuantidadeTelas;
    [SerializeField] public GameObject[] TelasFases;
    [SerializeField] public MonetizationManager mm;
    private void Start()
    {
        mm = FindObjectOfType<MonetizationManager>();
        pause = true;
        Time.timeScale = 1f;
        changeTextBtnSound();

        if (MenuInicial != null && MenuFases != null)
        {
            MenuInicial.SetActive(true);
            MenuFases.SetActive(false);
        }
    }
    private void changeTextBtnSound()
    {
        if (SoundManager.inst.isMuted())
        {
            ButtomMusic.GetComponentInChildren<Text>().text = "Music: off";
        }
        else
        {
            ButtomMusic.GetComponentInChildren<Text>().text = "Music: on";
        }
    }
    #region ==========================LÓGICA MENU INICIAL E FASES===========================
    

    public void OpenMenuFases()
    {
        int n = LevelManager.inst.getNivelMaisAltoTerminado();
        foreach (GameObject tF in TelasFases)
        {
            LevelButtons = tF.GetComponentsInChildren<Button>();
            foreach (Button btn in LevelButtons)
            {
                if (n >= 0)
                {
                    btn.interactable = true;
                }
                else
                {
                    btn.interactable = false;
                }
                n--;
            }
        }

        TelasFases[menu].SetActive(true);

        MenuInicial.SetActive(false);
        MenuFases.SetActive(true);
    }

    public void NextTF()
    {
        
        foreach (GameObject TF in TelasFases)
        {
            TF.SetActive(false);
        }
        menu++;
        menu = menu % QuantidadeTelas;
        TelasFases[Mathf.Abs(menu)].SetActive(true);
    }

    public void prevTF()
    {
        foreach (GameObject TF in TelasFases)
        {
            TF.SetActive(false);
        }
        menu--;
        menu = menu % QuantidadeTelas;
        TelasFases[Mathf.Abs(menu)].SetActive(true);
    }


    public void OpenMenuInicial()
    {
        MenuInicial.SetActive(true);
        MenuFases.SetActive(false);
    }

    public void MuteUnmute()
    {
        SoundManager.inst.mute();
        changeTextBtnSound();
    }

    public void AplicationQuit()
    {
        Application.Quit();
    }

    public void LoadNivel(int n)
    {
        mm.ShowInterstitial();
        LevelManager.inst.nivelAtual = n;
        SceneManager.LoadScene(LevelManager.inst.getNivelAtual().ToString());
    }

    #endregion

    #region ======Menu WIN/LOSE E PAUSE
    public void PauseResume()
    {
        if (!GameManager.inst.action)
        {
            if (pause)
            {
                Time.timeScale = 0f;
                pause = !pause;
                MenuPause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pause = !pause;
                MenuPause.SetActive(false);
            }

        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenWin()
    {
        if (!LevelManager.inst.isLastLevel())
        {
            LevelManager.inst.ChangeNewLevel();
            NextLevel.interactable = true;
        }
        else
        {
            NextLevel.interactable = false;
        }
        MenuWinLose.GetComponentInChildren<Text>().text = "Win!!";
        
        MenuWinLose.SetActive(true);
    }

    public void OpenLose()
    {
        Debug.Log("-----------------------------------------");
        NextLevel.interactable = false;
        MenuWinLose.GetComponentInChildren<Text>().text = "Lose!";
        MenuWinLose.SetActive(true);
    }


    public void LoadNextLevel()
    {
        mm.ShowInterstitial();
        SceneManager.LoadScene(LevelManager.inst.getNivelAtual().ToString());
    }

    public void ReloadScene()
    {
        mm.ShowInterstitial();
        Scene scene = SceneManager.GetActiveScene();
        LevelManager.inst.nivelAtual = int.Parse(scene.name);
        SceneManager.LoadScene(LevelManager.inst.getNivelAtual());
    }
    #endregion
}

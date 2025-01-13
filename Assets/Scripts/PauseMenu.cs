using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PlayerInputActions playerControls;
    public InputAction menu;
    public GameObject pauseUI;
    public static bool isPaused;
    public KeyCode keyCode = KeyCode.P;

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        menu = playerControls.UI.Pause;
        menu.Enable();
        menu.performed += PauseGame;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        isPaused = false;
    }

    public void SkillTree()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

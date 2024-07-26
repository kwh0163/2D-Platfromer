using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool isPaused;
    private void Start()
    {
        isPaused = false;
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float time = isPaused ? 1 : 0;
            Time.timeScale = time;
            animator.speed = time;
            isPaused = !isPaused;
        }
    }
}

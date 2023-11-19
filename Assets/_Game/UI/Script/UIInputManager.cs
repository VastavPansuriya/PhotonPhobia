using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Vastav.UI
{
    public class UIInputManager : MonoBehaviour
    {
        public static UIInputManager Instance { get; private set; }

        public UnityEvent OnWin;
        public UnityEvent OnLoss;

        private bool isWin;
        private bool isLoss;


        private void OnEnable()
        {
            OnWin.AddListener(SetWin);
            OnLoss.AddListener(SetLoss);
        }

        private void OnDisable()
        {
            OnWin.RemoveListener(SetWin);
            OnLoss.RemoveListener(SetLoss);
        }

        private void SetWin()
        {
            isWin = true;
        }

        private void SetLoss()
        {
            isLoss = true;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (isWin)
            {
                GoHome();
                Next();
            }

            if (isLoss)
            {
                GoHome();
                Restart();
            }
        }

        private void GoHome()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }

        private void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void Next()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
        }

    }
}
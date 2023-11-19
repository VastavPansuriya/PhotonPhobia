using UnityEngine;
using UnityEngine.SceneManagement;

namespace Vastav.UI
{
    public class HomeScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject infoPanel;

        private int IsMute
        {
            get { return PlayerPrefs.GetInt("IsMute", 0); }
            set { PlayerPrefs.SetInt("IsMute", value); }
        }
        private void Start()
        {
            CheckToggle();
        }

        private void CheckToggle()
        {
            AudioManager.Instance.MuteToggle(IsMute == 0);
        }

        private void Update()
        {
            ToggleInfoPanel();
            MuteToggle();
            LoadGame();
        }
        private void LoadGame()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
            }
        }

        private void MuteToggle()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                IsMute = IsMute == 0 ? 1 : 0;
                CheckToggle();
            }
        }

        private void ToggleInfoPanel()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                infoPanel.SetActive(true);
            }
            else
            {
                infoPanel.SetActive(false);
            }
        }
    }
}
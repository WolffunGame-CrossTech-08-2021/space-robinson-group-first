using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource _sndButtonEnter;

    private void OnValidate()
    {
        _sndButtonEnter = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void MouseHoverButton()
    {
        _sndButtonEnter.Play();
    }

}


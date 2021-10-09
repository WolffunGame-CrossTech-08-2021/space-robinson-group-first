using UnityEngine;

namespace UI
{
    public enum Window
    {
        None,
        MainMenu,
        InGame,
        Pause
    }
    
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private InGame inGame;
        [SerializeField] private Pause pause;
        
        
    }
}

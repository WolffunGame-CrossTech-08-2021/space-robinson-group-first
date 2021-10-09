using UnityEngine;
using UnityEngine.Rendering;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
            GraphicsSettings.transparencySortAxis = new Vector3(0.0f, 1.0f, 1.0f);
        }
    }
}

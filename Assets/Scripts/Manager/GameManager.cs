using System;
using System.Collections;
using Hero;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Weapon;
using Weapon.Data;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject defaultPlayerPrefab;
        public Transform respawnPoint;
        public FollowCamera followCamera;

        public BaseWeaponData defaultWeapon;

        [NonSerialized] public GameObject player;
        [NonSerialized] public HeroEntity heroEntity;

        private void OnValidate()
        {
            if (respawnPoint == null)
                respawnPoint = GameObject.FindWithTag("Respawn").transform;
        }

        private void Start()
        {
            CreateCharacter();
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(StartLoad());
            }
        }
        
        IEnumerator StartLoad()
        {
            var sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
            while (!operation.isDone)
            {
                yield return null;
            }
            CreateCharacter();
        }

        private void CreateCharacter()
        {
            if (respawnPoint == null)
                respawnPoint = GameObject.FindWithTag("Respawn").transform;
            
            player = Instantiate(defaultPlayerPrefab, respawnPoint.position, Quaternion.identity);
            heroEntity = player.GetComponent<HeroEntity>();
            followCamera.playerTransform = player.transform;
        }

        public void GameOver()
        {
            UIManager.Instance.GameOver();
            Time.timeScale = 0f;
            Cursor.visible = true;
            
            // Save game ...
        }

        public void Restart()
        {
            UIManager.Instance.Restart();
            Start();
            Time.timeScale = 1f;
            
            // Reset súng đạn, chuyển về màn cũ các kiểu con đà điểu
        }
    }
}

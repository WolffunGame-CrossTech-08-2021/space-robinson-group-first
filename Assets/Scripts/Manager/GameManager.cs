using System;
using Hero;
using UnityEngine;
using UnityEngine.Rendering;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject defaultPlayerPrefab;
        public Transform respawnPoint;
        public UI.FollowCamera followCamera;
        
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
        }

        private void CreateCharacter()
        {
            player = Instantiate(defaultPlayerPrefab, respawnPoint);
            heroEntity = player.GetComponent<HeroEntity>();
            followCamera.playerTransform = player.transform;
        }
    }
}

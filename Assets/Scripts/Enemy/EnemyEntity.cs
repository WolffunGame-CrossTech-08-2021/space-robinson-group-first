using ECS;
using UnityEngine;

namespace Enemy
{
    public class EnemyEntity : BaseEntity
    {
        protected override void EntityDead()
        {
            Debug.Log($"{gameObject.name} dead !");
        }
    }
}

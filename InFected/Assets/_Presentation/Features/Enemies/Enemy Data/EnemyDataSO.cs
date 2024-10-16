using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/Enemy Data")]
    public class EnemyDataSO : ScriptableObject
    {
        [field: SerializeField] public EnemyPerception.PerceptionParameters PerceptionParameters { get; private set; }
        [field: SerializeField] public EnemyMovement.MovementParameters MovementParameters { get; private set; }
        [field: SerializeField] public EnemyCommunication.CommunicationParameters CommunicationParameters { get; private set; }
        [field: SerializeField] public EnemyWeapon.WeaponParameters WeaponParameters { get; private set; }
    }
}

using UnityEngine;

namespace Enemy
{
    public class EnemyAlertTriggerZone : MonoBehaviour
    {
        [SerializeField] private EnemyController[] enemies;

        [Space]
        [SerializeField] private Transform alertTarget;
        [SerializeField] private bool runToTarget;

        [Space]
        [SerializeField] private bool makeInactiveAfterTrigger;
        [SerializeField] private bool isZoneActive;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isZoneActive) { return; }

            if (collision.TryGetComponent(out Player.Player player))
            {
                foreach (EnemyController enemy in enemies)
                {
                    if (enemy != null)
                    {
                        if (runToTarget && alertTarget != null)
                        {
                            enemy.SetPositionOfInterest(alertTarget.position);
                        }
                        else
                        {
                            enemy.SetPositionOfInterest(player.transform.position);
                        }
                    }
                }

                if (makeInactiveAfterTrigger)
                {
                    isZoneActive = false;
                }
            }
        }
    }
}

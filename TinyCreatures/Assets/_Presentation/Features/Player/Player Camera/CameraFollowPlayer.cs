using UnityEngine;

namespace Player
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform player;

        private void Update()
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }
}

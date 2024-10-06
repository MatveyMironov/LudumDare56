using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyPerception
    {
        private PerceptionParameters perceptionParameters;

        public EnemyPerception(PerceptionParameters perceptionParameters)
        {
            this.perceptionParameters = perceptionParameters;
        }

        public Player PercievedPlayer { get; private set; }

        public void Use(Transform perciever)
        {
            TryDetectPlayer(perciever.position);
        }

        private void TryDetectPlayer(Vector2 percieverPosition)
        {
            if (TryDetectInRadius(percieverPosition, out Player player))
            {
                if (CheckObstruction(player, percieverPosition))
                {
                    PercievedPlayer = player;
                    return;
                }
            }

            PercievedPlayer = null;
        }

        private bool TryDetectInRadius(Vector2 percieverPosition, out Player foundPlayer)
        {
            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(percieverPosition, perceptionParameters.PerceptionRadius, perceptionParameters.PercievedLayers);
            foreach (Collider2D detectedObject in detectedObjects)
            {
                if (detectedObject.TryGetComponent(out Player player))
                {
                    foundPlayer = player;
                    return true;
                }
            }

            foundPlayer = null;
            return false;
        }

        private bool CheckObstruction(Player player, Vector2 percieverPosition)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 directionToPlayer = playerPosition - percieverPosition;
            float distanceToPlayer = Vector2.Distance(playerPosition, percieverPosition);

            if (!Physics2D.Raycast(percieverPosition, directionToPlayer, distanceToPlayer, perceptionParameters.ObstructionLayers))
            {
                return true;
            }

            return false;
        }

        [Serializable]
        public class PerceptionParameters
        {
            [field: SerializeField] public LayerMask PercievedLayers { get; private set; }
            [field: SerializeField] public LayerMask ObstructionLayers { get; private set; }
            [field: SerializeField] public float PerceptionRadius { get; private set; }
        }
    }
}

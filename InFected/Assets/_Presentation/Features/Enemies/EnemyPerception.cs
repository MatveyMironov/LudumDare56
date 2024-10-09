using System;
using UnityEngine;
using Player;

namespace Enemy
{
    public class EnemyPerception
    {
        private PerceptionReferences _references;
        private PerceptionParameters _parameters;

        public EnemyPerception(PerceptionReferences references, PerceptionParameters parameters)
        {
            _references = references;
            _parameters = parameters;
        }

        public Player.Player PercievedPlayer { get; private set; }

        public void Use()
        {
            TryDetectPlayer(_references.Perciever.position);
        }

        private void TryDetectPlayer(Vector2 percieverPosition)
        {
            if (TryDetectInRadius(percieverPosition, out Player.Player player))
            {
                if (CheckObstruction(player, percieverPosition))
                {
                    PercievedPlayer = player;
                    return;
                }
            }

            PercievedPlayer = null;
        }

        private bool TryDetectInRadius(Vector2 percieverPosition, out Player.Player foundPlayer)
        {
            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(percieverPosition, _parameters.PerceptionRadius, _parameters.PercievedLayers);
            foreach (Collider2D detectedObject in detectedObjects)
            {
                if (detectedObject.TryGetComponent(out Player.Player player))
                {
                    foundPlayer = player;
                    return true;
                }
            }

            foundPlayer = null;
            return false;
        }

        private bool CheckObstruction(Player.Player player, Vector2 percieverPosition)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 directionToPlayer = playerPosition - percieverPosition;
            float distanceToPlayer = Vector2.Distance(playerPosition, percieverPosition);

            if (!Physics2D.Raycast(percieverPosition, directionToPlayer, distanceToPlayer, _parameters.ObstructionLayers))
            {
                return true;
            }

            return false;
        }

        [Serializable]
        public class PerceptionReferences
        {
            [field: SerializeField] public Transform Perciever { get; private set; }
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

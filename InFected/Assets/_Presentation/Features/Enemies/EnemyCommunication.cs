using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyCommunication
    {
        private CommunicationReferences _references;
        private CommunicationParameters _parameters;

        public EnemyCommunication(CommunicationReferences references, CommunicationParameters parameters)
        {
            _references = references;
            _parameters = parameters;
        }

        public void CommunicatePosition(Vector3 position)
        {
            Collider2D[] recievers = Physics2D.OverlapCircleAll(_references.Communicator.position, _parameters.CommunicationRadius, _parameters.RecievingLayers);
            foreach (Collider2D reciever in recievers)
            {
                if (reciever.TryGetComponent(out EnemyController enemy))
                {
                    enemy.SetPositionOfInterest(position);
                }
            }
        }

        [Serializable]
        public class CommunicationReferences
        {
            [field: SerializeField] public Transform Communicator { get; private set; }
        }

        [Serializable]
        public class CommunicationParameters
        {
            [field: SerializeField] public LayerMask RecievingLayers { get; private set; }
            [field: SerializeField] public float CommunicationRadius { get; private set; }
        }
    }
}

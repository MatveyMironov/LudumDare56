using UnityEngine;

namespace Door
{
    public class DoorMotor : MonoBehaviour
    {
        [SerializeField] private Transform door;
        [SerializeField] private Collider2D doorCollider;
        [SerializeField] private Vector3 closedPosition;
        [SerializeField] private Vector3 openedPosition;
        [SerializeField] private float movingSpeed;
        [SerializeField] private AudioSource openingSource;

        public bool IsClosing { get; private set; }
        public bool IsOpening { get; private set; }

        public bool IsClosed { get { return door.localPosition == closedPosition; } }
        public bool IsOpened { get { return door.localPosition == openedPosition; } }

        private void Update()
        {
            if (IsClosing)
            {
                CloseDoor();
            }
            else if (IsOpening)
            {
                OpenDoor();
            }
        }

        public void StartOpeningDoor()
        {
            if (IsOpening || IsOpened) { return; }

            openingSource.Play();
            IsClosing = false;
            IsOpening = true;
        }

        public void StartClosingDoor()
        {
            if (IsClosing || IsClosed) { return; }

            openingSource.Play();
            doorCollider.enabled = true;
            IsOpening = false;
            IsClosing = true;
        }

        private void OpenDoor()
        {
            door.localPosition = Vector3.MoveTowards(door.localPosition, openedPosition, movingSpeed * Time.deltaTime);

            if (IsOpened)
            {
                FinishOpeningDoor();
            }
        }

        private void CloseDoor()
        {
            door.localPosition = Vector3.MoveTowards(door.localPosition, closedPosition, movingSpeed * Time.deltaTime);

            if (IsClosed)
            {
                FinishClosingDoor();
            }
        }

        private void FinishOpeningDoor()
        {
            IsOpening = false;
            doorCollider.enabled = false;
        }

        private void FinishClosingDoor()
        {
            IsClosing = false;
        }
    }
}

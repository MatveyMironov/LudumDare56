using UnityEngine;

namespace UI
{
    public abstract class LoadCapacityDisplayer : MonoBehaviour
    {
        public abstract void DisplayCapacity(int capacity);
        public abstract void HideCapacity();

        public abstract void DisplayLoad(int load);
        public abstract void HideLoad();
    }
}

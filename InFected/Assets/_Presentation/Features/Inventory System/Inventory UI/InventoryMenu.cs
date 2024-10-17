using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;

    public bool IsOpened { get { return menuObject.activeInHierarchy; } }

    public void OpenMenu()
    {
        menuObject.SetActive(true);
    }

    public void CloseMenu()
    {
        menuObject.SetActive(false);
    }
}

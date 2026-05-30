using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public SettingsController settings;
    public InventoryController inventory;
    public TabController tabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    public void OpenMenu()
    {
        if (!menuCanvas.activeSelf && PauseController.IsGamePaused)
        {
            return;
        }

        menuCanvas.SetActive(!menuCanvas.activeSelf);
        PauseController.SetPause(menuCanvas.activeSelf);
        settings.FullExit();
        tabs.ExitTab();
        tabs.TabsControl(menuCanvas.activeSelf);
    }

    public void Enter(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (tabs.currentPage)
            {
                case 0:
                    break;
                case 1:
                    inventory.Enter();
                    break;
                case 2:
                    break;
                case 3:
                    settings.Enter();
                    break;
            }
        }
    }

    public void Exit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (tabs.currentPage)
            {
                case 0:
                    break;
                case 1:
                    inventory.Exit();
                    break;
                case 2:
                    break;
                case 3:
                    settings.Exit();
                    break;
            }
        }
    }
}

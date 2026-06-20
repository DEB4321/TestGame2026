using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public PartyController party;
    public InventoryController inventory;
    public SettingsController settings;
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
        party.Exit();
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
                    party.Enter();
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
                    if (!party.characterSelected) {
                        tabs.ExitTab();
                    }

                    party.Exit();
                    break;
                case 1:
                    inventory.Exit();
                    break;
                case 2:
                    break;
                case 3:
                    settings.Exit();

                    if (settings.IsASettingSelected())
                    {
                        tabs.ExitTab();
                    }
                    break;
            }
        }
    }
}

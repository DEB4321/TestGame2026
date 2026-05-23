using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
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
        settings.Exit();
        tabs.ExitTab();
        tabs.TabsControl(menuCanvas.activeSelf);
    }
}

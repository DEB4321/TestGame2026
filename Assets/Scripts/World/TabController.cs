using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
    private int currentPage = 0;
    private bool tabSelected = false;
    private bool tabsOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateTab(0);
    }

    public void ActivateTab(int tabNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }

        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;
    }

    public void ChangeTabRight(InputAction.CallbackContext context)
    {
        if (context.started && !tabSelected && tabsOpen)
        {
            currentPage++;

            if (currentPage >= pages.Length)
            {
                currentPage = 0;
            }

            ActivateTab(currentPage);
        }
    }

    public void ChangeTabLeft(InputAction.CallbackContext context)
    {
        if (context.started && !tabSelected && tabsOpen)
        {
            currentPage--;

            if (currentPage < 0)
            {
                currentPage = pages.Length - 1;
            }

            ActivateTab(currentPage);
        }
    }

    public void SelectTab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            tabSelected = true;
        }
    }

    public void ExitTab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            tabSelected = false;
        }
    }

    public void ExitTab()
    {
        tabSelected = false;
    }

    public void TabsControl(bool status)
    {
        tabsOpen = status;
    }
}

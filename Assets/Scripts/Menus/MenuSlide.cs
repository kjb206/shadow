using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public RectTransform menuPanel; // Assign the menu panel in the inspector
    public float slideSpeed = 10f;
    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;
    private bool isMenuOpen = false;

    public Button[] tabButtons; // Array of tab buttons
    public GameObject[] tabPanels; // Corresponding tab panels
    private int currentTab = 0; // Tracks the active tab

    void Start()
    {
        hiddenPosition = new Vector2(-menuPanel.rect.width, menuPanel.anchoredPosition.y);
        visiblePosition = new Vector2(0, menuPanel.anchoredPosition.y);
        menuPanel.anchoredPosition = hiddenPosition;
        
        foreach (Button button in tabButtons)
        {
            button.onClick.AddListener(() => SwitchTab(System.Array.IndexOf(tabButtons, button)));
        }
    }

    public void ToggleMenu()
    {
        StopAllCoroutines();
        StartCoroutine(SlideMenu(isMenuOpen ? hiddenPosition : visiblePosition));
        isMenuOpen = !isMenuOpen;
    }

    private IEnumerator SlideMenu(Vector2 targetPosition)
    {
        while (Vector2.Distance(menuPanel.anchoredPosition, targetPosition) > 0.1f)
        {
            menuPanel.anchoredPosition = Vector2.Lerp(menuPanel.anchoredPosition, targetPosition, Time.unscaledDeltaTime * slideSpeed);
            yield return null;
        }
        menuPanel.anchoredPosition = targetPosition;
        if (!isMenuOpen) DisableMenu();
    }

    private void DisableMenu()
    {
        foreach (Button button in tabButtons) button.interactable = false;
    }

    private void EnableMenu()
    {
        foreach (Button button in tabButtons) button.interactable = true;
    }

    public void SwitchTab(int tabIndex)
    {
        if (tabIndex == currentTab) return;
        
        for (int i = 0; i < tabPanels.Length; i++)
        {
            tabPanels[i].SetActive(i == tabIndex);
        }
        currentTab = tabIndex;
    }
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Tab))
    {
        ToggleMenu();
    }
}
}

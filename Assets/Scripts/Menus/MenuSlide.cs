using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public RectTransform menuPanel;
    public float slideSpeed = 3f;
    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;
    private bool isMenuOpen = false;

    public Button[] tabButtons;
    public GameObject[] tabPanels;
    private int currentTab = -1;

    void OnEnable()
    {
        hiddenPosition = new Vector2(-menuPanel.rect.width, menuPanel.anchoredPosition.y);
        visiblePosition = new Vector2(menuPanel.rect.width / 2, menuPanel.anchoredPosition.y);
        menuPanel.anchoredPosition = hiddenPosition;

        foreach (var panel in tabPanels)
        {
            if (panel != null) panel.SetActive(false);
        }

        for (int i = 0; i < tabButtons.Length; i++)
        {
            int tabIndex = i;
            tabButtons[i].onClick.RemoveAllListeners();
            tabButtons[i].onClick.AddListener(() => SwitchTab(tabIndex));
        }
    }

    public void ToggleMenu()
    {
        StopAllCoroutines();
        StartCoroutine(SlideMenu(isMenuOpen ? hiddenPosition : visiblePosition));
        isMenuOpen = !isMenuOpen;

        Time.timeScale = isMenuOpen ? 0f : 1f;

        PlayerMovement playerMovement = GameObject.FindWithTag("Player")?.GetComponent<PlayerMovement>();
        if (playerMovement != null) playerMovement.enabled = !isMenuOpen;
    }

    private IEnumerator SlideMenu(Vector2 targetPosition)
    {
        while (Vector2.Distance(menuPanel.anchoredPosition, targetPosition) > 0.1f)
        {
            menuPanel.anchoredPosition = Vector2.Lerp(menuPanel.anchoredPosition, targetPosition, Time.unscaledDeltaTime * slideSpeed);
            yield return null;
        }
        menuPanel.anchoredPosition = targetPosition;
    }
    public void SwitchTab(int tabIndex)
    {
        if (tabIndex < 0 || tabIndex >= tabPanels.Length) return;

        if (tabIndex == currentTab && tabPanels[tabIndex].activeSelf)
        {
            tabPanels[tabIndex].SetActive(false);
            currentTab = -1;
            return;
        }

        for (int i = 0; i < tabPanels.Length; i++)
        {
            if (tabPanels[i] != null) tabPanels[i].SetActive(i == tabIndex);
        }

        currentTab = tabPanels[tabIndex].activeSelf ? tabIndex : -1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) ToggleMenu();
    }
}

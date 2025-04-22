using UnityEngine;
using UnityEngine.UI;

public class CraftMenuBehaviour : GameBehaviour
{
    private GameObject craftPanel;
    private bool isMenuVisible = false;
    private MouseBehaviour mouseBehaviour;
    private GameMenuBehaviour gameMenuBehaviour;

    public CraftMenuBehaviour(MouseBehaviour mouseBehaviour, GameMenuBehaviour gameMenuBehaviour)
    {
        this.mouseBehaviour = mouseBehaviour;
        this.gameMenuBehaviour = gameMenuBehaviour;
    }

    public override void Start()
    {
        CreateCraftUI();
        craftPanel.SetActive(false);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    private void CreateCraftUI()
    {
        // Create Canvas
        GameObject canvasObj = new GameObject("CraftCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // Create full screen background panel
        craftPanel = new GameObject("CraftPanel");
        craftPanel.transform.SetParent(canvasObj.transform, false);
        Image panelImage = craftPanel.AddComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0.8f);

        // Set panel to cover full screen
        RectTransform panelRect = craftPanel.GetComponent<RectTransform>();
        panelRect.anchorMin = Vector2.zero;
        panelRect.anchorMax = Vector2.one;
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;

        // Create title
        CreateTitle("Crafting Menu", new Vector2(0, 200));
    }

    private void CreateTitle(string text, Vector2 position)
    {
        GameObject titleObj = new GameObject("Title");
        titleObj.transform.SetParent(craftPanel.transform, false);
        
        Text titleText = titleObj.AddComponent<Text>();
        titleText.text = text;
        titleText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        titleText.alignment = TextAnchor.MiddleCenter;
        titleText.color = Color.white;
        titleText.fontSize = 32;

        RectTransform titleRect = titleObj.GetComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0.5f, 0.5f);
        titleRect.anchorMax = new Vector2(0.5f, 0.5f);
        titleRect.pivot = new Vector2(0.5f, 0.5f);
        titleRect.anchoredPosition = position;
        titleRect.sizeDelta = new Vector2(400, 50);
    }

    private void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        craftPanel.SetActive(isMenuVisible);

        if (isMenuVisible)
        {
            // Close game menu if it's open
            if (gameMenuBehaviour != null)
            {
                gameMenuBehaviour.HideMenu();
            }
            mouseBehaviour.UnlockMouse();
        }
        else
        {
            mouseBehaviour.LockMouse();
        }
    }

    public void HideMenu()
    {
        isMenuVisible = false;
        craftPanel.SetActive(false);
        mouseBehaviour.LockMouse();
    }

    public bool IsMenuVisible()
    {
        return isMenuVisible;
    }
} 
using UnityEngine;
using UnityEngine.UI;

public class GameMenuBehaviour : GameBehaviour
{
    private GameObject menuPanel;
    private GameObject buttonContainer;
    private bool isMenuVisible = false;
    private MouseBehaviour mouseBehaviour;
    private CraftMenuBehaviour craftMenuBehaviour;

    public GameMenuBehaviour(MouseBehaviour mouseBehaviour)
    {
        this.mouseBehaviour = mouseBehaviour;
    }

    public void SetCraftMenuBehaviour(CraftMenuBehaviour craftMenuBehaviour)
    {
        this.craftMenuBehaviour = craftMenuBehaviour;
    }

    public override void Start()
    {
        CreateMenuUI();
        menuPanel.SetActive(false);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (craftMenuBehaviour != null && craftMenuBehaviour.IsMenuVisible())
            {
                craftMenuBehaviour.HideMenu();
                ShowMenu();
            }
            else
            {
                ToggleMenu();
            }
        }
    }

    private void CreateMenuUI()
    {
        // Create Canvas
        GameObject canvasObj = new GameObject("MenuCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // Create full screen background panel
        menuPanel = new GameObject("MenuPanel");
        menuPanel.transform.SetParent(canvasObj.transform, false);
        Image panelImage = menuPanel.AddComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0.8f);

        // Set panel to cover full screen
        RectTransform panelRect = menuPanel.GetComponent<RectTransform>();
        panelRect.anchorMin = Vector2.zero;
        panelRect.anchorMax = Vector2.one;
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;

        // Create button container for bottom left alignment
        buttonContainer = new GameObject("ButtonContainer");
        buttonContainer.transform.SetParent(menuPanel.transform, false);
        RectTransform containerRect = buttonContainer.AddComponent<RectTransform>();
        containerRect.anchorMin = new Vector2(0, 0);
        containerRect.anchorMax = new Vector2(0, 0);
        containerRect.pivot = new Vector2(0, 0);
        containerRect.anchoredPosition = new Vector2(50, 50);
        containerRect.sizeDelta = new Vector2(200, 120); // Width of buttons + spacing

        // Create Resume Button
        CreateButton("Resume", new Vector2(0, 70), () => ToggleMenu());
        CreateButton("Quit", new Vector2(0, 0), () => {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        });
    }

    private void CreateButton(string text, Vector2 position, UnityEngine.Events.UnityAction onClick)
    {
        GameObject buttonObj = new GameObject(text + "Button");
        buttonObj.transform.SetParent(buttonContainer.transform, false);
        
        // Add Image Component
        Image buttonImage = buttonObj.AddComponent<Image>();
        buttonImage.color = new Color(0.2f, 0.2f, 0.2f, 0f);

        // Add Button Component
        Button button = buttonObj.AddComponent<Button>();
        button.targetGraphic = buttonImage;
        button.onClick.AddListener(onClick);

        // Set Button Position and Size
        RectTransform buttonRect = buttonObj.GetComponent<RectTransform>();
        buttonRect.sizeDelta = new Vector2(200, 50);
        buttonRect.anchoredPosition = position;

        // Add Text
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);
        Text buttonText = textObj.AddComponent<Text>();
        buttonText.text = text;
        buttonText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        buttonText.alignment = TextAnchor.MiddleLeft;
        buttonText.color = Color.white;
        buttonText.fontSize = 24;

        // Center text
        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;
    }

    private void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;

        if (isMenuVisible){
            ShowMenu();
        }else{
            HideMenu();
        }
    }

    private void ShowMenu()
    {
        isMenuVisible = true;
        menuPanel.SetActive(true);
        mouseBehaviour.UnlockMouse();
    }

    public void HideMenu()
    {
        isMenuVisible = false;
        menuPanel.SetActive(false);
        mouseBehaviour.LockMouse();
    }
} 
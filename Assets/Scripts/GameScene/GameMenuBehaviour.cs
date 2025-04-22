using UnityEngine;
using UnityEngine.UI;

public class GameMenuBehaviour : GameBehaviour
{
    private GameObject menuPanel;
    private GameObject buttonContainer;
    private bool isMenuVisible = false;
    private MouseBehaviour mouseBehaviour;
    private CraftMenuBehaviour craftMenuBehaviour;

    // Screen size relative values
    private const float BUTTON_WIDTH_PERCENT = 0.1f; // 10% of screen width
    private const float BUTTON_HEIGHT_PERCENT = 0.05f; // 5% of screen height
    private const float BUTTON_SPACING_PERCENT = 0.01f; // 1% of screen height
    private const float MARGIN_PERCENT = 0.01f; // 1% margin from edges

    private const int SCREEN_WIDTH = 1920;
    private const int SCREEN_HEIGHT = 1080;

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
        CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
        scaler.matchWidthOrHeight = 0.5f; // Balance between width and height scaling
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
        
        // Calculate button sizes based on screen resolution
        float screenWidth = SCREEN_WIDTH;
        float screenHeight = SCREEN_HEIGHT;
        float buttonWidth = screenWidth * BUTTON_WIDTH_PERCENT;
        float buttonHeight = screenHeight * BUTTON_HEIGHT_PERCENT;
        float buttonSpacing = screenHeight * BUTTON_SPACING_PERCENT;
        float margin = screenWidth * MARGIN_PERCENT;

        // Position container with margin
        containerRect.anchoredPosition = new Vector2(margin, margin);
        containerRect.sizeDelta = new Vector2(buttonWidth, buttonHeight * 2 + buttonSpacing);

        // Create Resume Button
        CreateButton("Resume", new Vector2(0, buttonHeight + buttonSpacing), buttonWidth, buttonHeight, () => ToggleMenu());
        CreateButton("Quit", new Vector2(0, 0), buttonWidth, buttonHeight, () => {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        });
    }

    private void CreateButton(string text, Vector2 position, float width, float height, UnityEngine.Events.UnityAction onClick)
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
        buttonRect.sizeDelta = new Vector2(width, height);
        buttonRect.anchoredPosition = position;

        // Add Text
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);
        Text buttonText = textObj.AddComponent<Text>();
        buttonText.text = text;
        buttonText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        buttonText.alignment = TextAnchor.MiddleLeft;
        buttonText.color = Color.white;
        buttonText.fontSize = Mathf.RoundToInt(height * 0.4f); // Font size relative to button height

        // Position text with padding
        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 0);
        textRect.anchorMax = new Vector2(1, 1);
        textRect.offsetMin = new Vector2(height * 0.2f, 0); // Left padding relative to button height
        textRect.offsetMax = Vector2.zero;
    }

    private void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        menuPanel.SetActive(isMenuVisible);

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
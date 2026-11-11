
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CaveWinTrigger : MonoBehaviour
{
    private bool hasWon = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasWon) return;

        Student3RabbitController rabbit =
            other.GetComponentInParent<Student3RabbitController>();

        if (rabbit != null)
        {
            hasWon = true;

            Debug.Log("VICTORY! Rabbit reached the cave!");

            ShowVictoryScreen();
        }
    }

    private void ShowVictoryScreen()
    {
        Time.timeScale = 0f;

        GameObject canvasObject = new GameObject("VictoryCanvas");

        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasScaler scaler = canvasObject.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        scaler.matchWidthOrHeight = 0.5f;

        canvasObject.AddComponent<GraphicRaycaster>();

        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventObject = new GameObject("EventSystem");
            eventObject.AddComponent<EventSystem>();
            eventObject.AddComponent<StandaloneInputModule>();
        }

        // Background overlay
        GameObject overlay = CreateImage(
            "BackgroundOverlay",
            canvasObject.transform,
            new Color(0.025f, 0.055f, 0.04f, 0.88f),
            Vector2.zero,
            Vector2.one
        );

        // Main victory card
        GameObject card = CreateImage(
            "VictoryCard",
            overlay.transform,
            new Color(0.10f, 0.19f, 0.13f, 1f),
            new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f)
        );

        RectTransform cardRect = card.GetComponent<RectTransform>();
        cardRect.sizeDelta = new Vector2(760, 650);

        // Heading
        CreateText(
            "LEVEL COMPLETED",
            card.transform,
            58,
            new Color(1f, 0.82f, 0.39f),
            new Vector2(0.5f, 0.85f),
            new Vector2(0.9f, 0.97f)
        );

        // Decorative stars
        CreateText(
            "★     ★     ★",
            card.transform,
            42,
            Color.white,
            new Vector2(0.1f, 0.68f),
            new Vector2(0.9f, 0.77f)
        );

        // Victory message
        CreateText(
            "YOU MADE IT!",
            card.transform,
            65,
            Color.white,
            new Vector2(0.05f, 0.52f),
            new Vector2(0.95f, 0.67f)
        );

        // Description
        CreateText(
            "The rabbit has safely reached the woodland cave!",
            card.transform,
            27,
            new Color(0.83f, 0.90f, 0.81f),
            new Vector2(0.05f, 0.40f),
            new Vector2(0.95f, 0.50f)
        );

        // Mission panel
        GameObject mission = CreateImage(
            "MissionPanel",
            card.transform,
            new Color(0.20f, 0.38f, 0.23f, 1f),
            new Vector2(0.1f, 0.25f),
            new Vector2(0.9f, 0.37f)
        );

        CreateText(
            "★  MISSION ACCOMPLISHED  ★",
            mission.transform,
            27,
            new Color(1f, 0.88f, 0.57f),
            Vector2.zero,
            Vector2.one
        );

        // Restart button
        GameObject buttonObject = CreateImage(
            "RestartButton",
            card.transform,
            new Color(0.82f, 0.61f, 0.24f, 1f),
            new Vector2(0.22f, 0.09f),
            new Vector2(0.78f, 0.22f)
        );

        Button button = buttonObject.AddComponent<Button>();
        button.targetGraphic = buttonObject.GetComponent<Image>();
        button.onClick.AddListener(RestartGame);

        CreateText(
            "PLAY AGAIN",
            buttonObject.transform,
            34,
            new Color(0.10f, 0.16f, 0.09f),
            Vector2.zero,
            Vector2.one
        );

        // Footer
        CreateText(
            "RABBIT SURVIVAL  |  WOODLAND ADVENTURE",
            card.transform,
            18,
            new Color(0.65f, 0.76f, 0.64f),
            new Vector2(0.05f, 0.015f),
            new Vector2(0.95f, 0.075f)
        );
    }

    private GameObject CreateImage(
        string objectName,
        Transform parent,
        Color color,
        Vector2 anchorMin,
        Vector2 anchorMax)
    {
        GameObject obj = new GameObject(
            objectName,
            typeof(RectTransform),
            typeof(CanvasRenderer),
            typeof(Image)
        );

        obj.transform.SetParent(parent, false);

        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.anchorMin = anchorMin;
        rect.anchorMax = anchorMax;
        rect.anchoredPosition = Vector2.zero;
        rect.sizeDelta = Vector2.zero;

        obj.GetComponent<Image>().color = color;

        return obj;
    }

    private void CreateText(
        string content,
        Transform parent,
        int fontSize,
        Color color,
        Vector2 anchorMin,
        Vector2 anchorMax)
    {
        GameObject obj = new GameObject(
            "Text_" + content.Replace(" ", "_"),
            typeof(RectTransform),
            typeof(CanvasRenderer),
            typeof(Text)
        );

        obj.transform.SetParent(parent, false);

        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.anchorMin = anchorMin;
        rect.anchorMax = anchorMax;
        rect.anchoredPosition = Vector2.zero;
        rect.sizeDelta = Vector2.zero;

        Text text = obj.GetComponent<Text>();

        // Unity 6 compatible built-in font
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");

        text.text = content;
        text.fontSize = fontSize;
        text.fontStyle = FontStyle.Bold;
        text.color = color;
        text.alignment = TextAnchor.MiddleCenter;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.verticalOverflow = VerticalWrapMode.Overflow;
        text.resizeTextForBestFit = true;
        text.resizeTextMinSize = 14;
        text.resizeTextMaxSize = fontSize;
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}

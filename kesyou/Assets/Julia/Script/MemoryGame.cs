using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    public Image displayImage;
    public Button[] colorButtons;
    public Sprite[] colorSprites;
    public GameObject panel;
    public Button startButton;
    public Text startText;
    public Text resultText;
    public GameObject[] gameObjectsToActivate;

    private List<int> selectedColors = new List<int>();
    private List<int> playerInput = new List<int>();

   void Start()
{
    panel.SetActive(true);
    startButton.onClick.AddListener(() => StartCoroutine(ReadyStartSequence()));
    startText.gameObject.SetActive(false);  

    foreach (var obj in gameObjectsToActivate)
{
    obj.SetActive(false);
}
}
void Update()
{
    foreach (var obj in gameObjectsToActivate)
    {
        Debug.Log($"{obj.name} Active State: {obj.activeSelf}");
    }
}

    IEnumerator ReadyStartSequence()
{
    startButton.interactable = false;
    panel.SetActive(false);

    startText.gameObject.SetActive(true);
    startText.text = "Ready";
    yield return new WaitForSeconds(1.5f);

    startText.text = "Start!";
    yield return new WaitForSeconds(1.0f);

    startText.gameObject.SetActive(false);

    StartGame();

    startButton.interactable = true;
}

    void StartGame()
    {
        selectedColors.Clear();
        playerInput.Clear();
        SelectRandomColors();
        StartCoroutine(DisplayColorsSequence());
    }

    void SelectRandomColors()
    {
        while (selectedColors.Count < 4)
        {
            int randomIndex = Random.Range(0, colorSprites.Length);
            if (!selectedColors.Contains(randomIndex))
            {
                selectedColors.Add(randomIndex);
            }
        }
    }

    IEnumerator DisplayColorsSequence()
{
    EnableColorButtons(false);

    foreach (int colorIndex in selectedColors)
    {
        displayImage.sprite = colorSprites[colorIndex];
        yield return new WaitForSeconds(2f);
        displayImage.sprite = null;  
        yield return new WaitForSeconds(0.5f);
    }

    foreach (var obj in gameObjectsToActivate)
    {
        Debug.Log($"Before Activating: {obj.name}, Active: {obj.activeSelf}");
        obj.SetActive(true);
        Debug.Log($"After Activating: {obj.name}, Active: {obj.activeSelf}");
    }

    EnableColorButtons(true);
}

    public void OnColorButtonClick(int buttonIndex)
    {
        playerInput.Add(buttonIndex);

        if (playerInput.Count == selectedColors.Count)
        {
            CheckPlayerInput();
        }
    }

    void CheckPlayerInput()
    {
        for (int i = 0; i < selectedColors.Count; i++)
        {
            if (playerInput[i] != selectedColors[i])
            {
                resultText.text = "Lose";
                Debug.Log("Lose");

            }
        }
        resultText.text = "Win";

        Debug.Log("Win");

    }

    void EnableColorButtons(bool enable)
    {
        foreach (var button in colorButtons)
        {
            button.interactable = enable;
        }
    }

    void ManualActivateTest()
{
    foreach (var obj in gameObjectsToActivate)
    {
        obj.SetActive(true);
        Debug.Log($"Manual Activation: {obj.name}, Active: {obj.activeSelf}");
    }
}

}
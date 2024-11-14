using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    public Image displayImage;
    public Button[] colorButtons;
    public Sprite[] colorSprites;

    private List<int> selectedColors = new List<int>();
    private List<int> playerInput = new List<int>();

    void Start()
    {
        StartGame();
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
        foreach (int colorIndex in selectedColors)
        {
            displayImage.sprite = colorSprites[colorIndex];
            yield return new WaitForSeconds(1f);
            displayImage.sprite = null;  
            yield return new WaitForSeconds(0.5f);
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
                Debug.Log("lose");
                RestartGame();
                return;
            }
        }

        Debug.Log("win");
        RestartGame();
    }

    void RestartGame()
    {
        EnableColorButtons(false);
        StartGame();
    }

    void EnableColorButtons(bool enable)
    {
        foreach (var button in colorButtons)
        {
            button.interactable = enable;
        }
    }
}


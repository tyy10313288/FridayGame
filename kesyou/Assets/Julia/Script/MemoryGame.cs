using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    public Image displayImage;
    public Button[] colorButtons;
    public Sprite[] colorSprites;
    public Text showResult;
    private int stepNow=0;

    private List<int> selectedColors = new List<int>();
    private List<int> playerInput = new List<int>();

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {        
        selectedColors.Clear();
        showResult.text="";        
        playerInput.Clear();        
        SelectRandomColors();
        StartCoroutine(DisplayColorsSequence());
    }

    public void SelectRandomColors()
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
    
    displayImage.sprite = null;
    
    
    EnableColorButtons(false);
    
    
    yield return new WaitForSeconds(1f);
    
    
    foreach (int colorIndex in selectedColors)
    {
        
        if (colorIndex < 0 || colorIndex >= colorSprites.Length)
        {            
            continue;
        }
        
        
        displayImage.sprite = colorSprites[colorIndex];
        yield return new WaitForSeconds(1f);
                
        displayImage.sprite = null;
        yield return new WaitForSeconds(0.5f);
    }
    
    displayImage.sprite = null;
   
    yield return new WaitForSeconds(0.5f);
   
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
    bool isCorrect = true;
    
    
    for (int i = 0; i < selectedColors.Count; i++)
    {
        if (playerInput[i] != selectedColors[i])
        {
            isCorrect = false;
            break;
        }
    }
    
    
    if (isCorrect)
    {
        Debug.Log("win");
    }
    else
    {
        Debug.Log("lose");
    }
}
    

    void EnableColorButtons(bool enable)
    {
        foreach (var button in colorButtons)
        {
            button.interactable = enable;
        }
    }
}


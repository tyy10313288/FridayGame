using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryVer2 : MonoBehaviour
{
    public Text showResult; 
    public Image displayPlace;         
    public Button[] playerClick;      
    public Sprite[] colorSprite;      

    private List<int> showedColor = new List<int>(); 
    private int currentStep = 0;       

    void Start()
    {
        StartGame();
        
        
        for (int i = 0; i < playerClick.Length; i++)
        {
            int index = i; 
            playerClick[i].onClick.AddListener(() => OnColorButtonClick(index));
        }
    }

    public void StartGame()
    {
        showedColor.Clear();           
        GenerateRanColor();
        currentStep = 0;               
        showResult.text = "";          
        StartCoroutine(DisplayNextColor());
    }

    public void GenerateRanColor()
    {
        showedColor.Clear(); 
        
        while (showedColor.Count < 4)
        {
            int randomIndex = Random.Range(0, colorSprite.Length);
            if (!showedColor.Contains(randomIndex))
            {
                showedColor.Add(randomIndex);
            }
        }
    }

    IEnumerator DisplayNextColor()
    {
        showResult.text = ""; 
        EnableColorButtons(false);
        displayPlace.sprite = colorSprite[showedColor[currentStep]];
        yield return new WaitForSeconds(0.5f);
        displayPlace.sprite = null;
        EnableColorButtons(true);
    }

    public void OnColorButtonClick(int buttonIndex)
    {
        if (buttonIndex == showedColor[currentStep])
        {
            currentStep++;
            if (currentStep < showedColor.Count)
            {
                StartCoroutine(DisplayNextColor());
            }
            else
            {
                showResult.text = "Correct!";
                Debug.Log("Correct!");
                EnableColorButtons(false);
            }
        }
        else
        {
            showResult.text = "Wrong!";
            Debug.Log("Wrong!");
            
        }
    }

    void EnableColorButtons(bool enable)
    {
        foreach (var button in playerClick)
        {
            button.interactable = enable;
        }
    }
}
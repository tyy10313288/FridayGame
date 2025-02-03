using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sirone : MonoBehaviour
{
    public void _Sirone()
    {
        if (!GameObject.Find("branch").GetComponent<Branch>().eve)
        {
            PlayerPrefs.SetInt("EVENT", 0);
            SceneManager.LoadScene("PuzzleEvent");
        }
    }
}

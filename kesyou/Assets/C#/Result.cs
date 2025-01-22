using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    int result;
    void Start()
    {
        result = PlayerPrefs.GetInt("RESULT", 0);

        if (result == 1)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("•’Ê‚Ì—‚Ìq");
            GameObject ordinarybackground = (GameObject)Resources.Load("´‘^Œn@”wŒi@‚Ú‚©‚µ");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f,1), Quaternion.identity);
        }
        if (result == 4)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("ƒAƒ€ƒ‰[");
            GameObject ordinarybackground = (GameObject)Resources.Load("ƒAƒ€ƒ‰[@”wŒi@‚Ú‚©‚µ");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        if (result == 2)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("”’ƒMƒƒƒ‹");
            GameObject ordinarybackground = (GameObject)Resources.Load("ƒMƒƒƒ‹Œn@”wŒi@‚Ú‚©‚µ");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 3)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("•½–ìƒmƒ‰");
            GameObject ordinarybackground = (GameObject)Resources.Load("•½–ìƒmƒ‰@”wŒi@‚Ú‚©‚µ");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 4)
        {
            GameObject amra = (GameObject)Resources.Load("ƒAƒ€ƒ‰[");
            GameObject amrabackground = (GameObject)Resources.Load("ƒAƒ€ƒ‰[@”wŒi@‚Ú‚©‚µ");

            Instantiate(amra, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(amrabackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if(result == 9)
        {
            GameObject shrek = (GameObject)Resources.Load("ƒVƒ…ƒŒƒbƒN");
            GameObject shrekbackground = (GameObject)Resources.Load("ƒVƒ…ƒŒƒbƒN@”wŒi@‚Ú‚©‚µ");

            Instantiate(shrek, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(shrekbackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if(result == 10)
        {
            GameObject piccolo = (GameObject)Resources.Load("ƒsƒbƒRƒ");
            GameObject piccolobackground = (GameObject)Resources.Load("ƒsƒbƒRƒ@”wŒi@‚Ú‚©‚µ");

            Instantiate(piccolo, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(piccolobackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
    }
}

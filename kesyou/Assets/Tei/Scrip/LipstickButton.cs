using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LipstickButton : MonoBehaviour
{
   
    private bool isPressed = false;
    private int currentValue = 0;
    private float timer = 0f;
    public float speed = 0.001f;
    public Image lipImage;
    public TextMeshProUGUI clear;
    public TextMeshProUGUI fail;
    public int Chance = 3;
    public GameObject live3;
    public GameObject live2;
    private void Start()
    {
        SetLipstickAlpha(0);

        clear.gameObject.SetActive(false);
        fail.gameObject.SetActive(false);
        
    }
    void Update()
    {
        
        if (isPressed)
        {
            timer += Time.deltaTime;

            if (timer >= speed)
            {
                currentValue += 1;
                if (currentValue > 100)
                {
                    currentValue = 100;
                }

                Debug.Log("当前数字: " + currentValue);
                SetLipstickAlpha(currentValue);
                timer = 0f;
            }
        }
        
        
    }

    public void StartPress()
    {
        currentValue = 0;
        isPressed = true;
    }

    public void StopPress()
    {
        isPressed = false;
        SetLipstickAlpha(currentValue);
        Debug.Log("最终数字: " + currentValue);
        if (currentValue > 80&&currentValue<91)
        {
            clear.gameObject.SetActive(true);

        }
        else
        {
            clear.gameObject.SetActive(false);

        }

        if (currentValue < 80 || (currentValue >= 91 && currentValue <= 100))
        {
            fail.gameObject.SetActive(true);

            Chance -= 1;
            if( Chance == 2 )
            {
                Destroy(live3);
            }
            if (Chance == 1)
            {
                Destroy(live2);
            }
            if (Chance <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }



        }
        else
        {
            fail.gameObject.SetActive(false);
            

        }
    }
    void SetLipstickAlpha(int percent)
    {
        // 将百分比转换为0到1之间的值，透明度范围为0到1
        float alphaValue = percent / 100f;  // 0% -> 0, 100% -> 1

        // 获取当前口红图片的颜色
        Color currentColor = lipImage.color;
        currentColor.a = alphaValue;  // 设置Alpha值（透明度）
        lipImage.color = currentColor;  // 更新口红图像的颜色
    }
    
        
       
        

    
}

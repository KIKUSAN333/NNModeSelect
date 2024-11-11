using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed = 3; //光る速度
    [SerializeField] int num = 0;
    private Renderer rend;
    private float alfa = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!(rend.material.color.a <= 0))
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alfa);
        }

        if (num == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                colorChange();
            }
        }
        else if (num == 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                colorChange();
            }
        }
        else if (num == 3)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                colorChange();
            }
        }
        else if (num == 4)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                colorChange();
            }
        }

        alfa -= Speed * Time.deltaTime;
    }

    /// <summary>
    /// 入力を受けてレーンを光らせるメソッド．どのレーンが入力されたかを分かりやすくする．
    /// </summary>
    public void colorChange()
    {
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b,alfa);

    }

}

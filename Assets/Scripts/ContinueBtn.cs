using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueBtn : MonoBehaviour
{
    Button btn;

    public GameObject Player;
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => {
            OnBtnClick();
        });

    }
    void OnBtnClick()
    {
        if(Player.GetComponent<Player>().isCanMove)
        {
            GameManager._instance.TimeScaleOne();
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        PausePanel.SetActive(false);
    }
}

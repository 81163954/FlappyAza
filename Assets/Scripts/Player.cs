using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    AudioSource coin;

    public float jumpForce;
    public float maxAngle;
    public float rotateScale;
    public float MaxRange=3;
    public float MaxRangeItem=6;

    public bool isCanMove = false;
    public bool isItemSpeed = true;

    public GameObject producePoint;
    public GameObject enemyPrefab;
    public GameObject itemPrefab, itemPrefab2, itemPrefab3;
    public GameObject restartButton;
    public GameObject startBtn;

    //设置死亡得分相关
    public int eatyaling = 0;
    public int eatmilk = 0;
    public int flyshuiguan = 0;
    public Text diedPanelyaling;
    public Text diedPanelmilk;
    public Text diedPanelshuiguan;
    public GameObject diedPanel;
    public Image Image;
    public GameObject alpha;
    

    private IEnumerator coroutine;
    private AudioSource audioSource;
    bool a;
    private void Awake()
    {
        
    }
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coin = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
        if (GameManager._instance.score == 0&&!a)
        {
            a = true;
            StartCoroutine(WaitForAudio(1f));
            SetScore();
            GameManager._instance.setSpeedToZero();
            isCanMove = false;
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
            StartCoroutine(WaitForRestartButton(1));
            isItemSpeed = false;
            
            

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("hose"))
        {
            AudioSourceController.PlaySnd("Audio", "救！");
            GameManager._instance.setSpeedToZero();
            collision.collider.enabled = false;
            anim.SetTrigger("death");
            isCanMove = false;
            //restartButton.SetActive(true);
            isItemSpeed = false;
        }
        if (collision.gameObject.CompareTag("ground"))
        {

            StartCoroutine(WaitForReload(1));

            AudioSourceController.PlaySnd("Audio", "救！");
            GameManager._instance.setSpeedToZero();
            anim.SetTrigger("death");
            isCanMove = false;
            //restartButton.SetActive(true);
            isItemSpeed = false;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            AudioSourceController.PlaySnd("Audio", "救！");
            GameManager._instance.setSpeedToZero();
            collision.collider.enabled = false;
            anim.SetTrigger("death");
            isCanMove = false;
            isItemSpeed = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("score"))
        {
            //coin.Play();
            AudioSourceController.PlaySnd("Audio", "coin");

            if (GameManager._instance.score >= 1)
                GameManager._instance.score -= 1f;
            else
                GameManager._instance.score = 0f;

            GameManager._instance.setScoreText();
            flyshuiguan++;
            if(Random.Range(0f,3)<1)
            {
                GameObject EnemyList = GameObject.Find("EnemyList");
                Vector3 a = producePoint.transform.position;
                a.y = Random.Range(-5f, 3f);
                Instantiate(enemyPrefab, producePoint.transform.position, producePoint.transform.rotation).transform.parent = EnemyList.transform;
                    
            }
            else if (Random.Range(0f, 3)<2)
            {
                GameObject EnemyList = GameObject.Find("EnemyList");
                Vector3 a = producePoint.transform.position;
                a.y = Random.Range(-5f, 3f);
                Instantiate(itemPrefab3, a, producePoint.transform.rotation).transform.parent = EnemyList.transform;

            }else if (Random.Range(0f, 3) < 1)
            {
                if (Random.Range(0f, 2) < 1)
                {
                    GameObject EnemyList = GameObject.Find("EnemyList");
                    Vector3 a = producePoint.transform.position;
                    a.y = Random.Range(-5f, 3f);
                    Instantiate(itemPrefab2, a, producePoint.transform.rotation).transform.parent = EnemyList.transform;
                }
                else
                {
                    GameObject EnemyList = GameObject.Find("EnemyList");
                    Vector3 a = producePoint.transform.position;
                    a.y = Random.Range(-5f, 3f);
                    Instantiate(itemPrefab, a, producePoint.transform.rotation).transform.parent = EnemyList.transform;
                }
            }
                
        }
        else if(collision.gameObject.CompareTag("item"))
        {
            //coin.Play();
            AudioSourceController.PlaySnd("Audio", "coin");
            Destroy(collision.gameObject);

            if(collision.gameObject.transform.lossyScale.x ==0.77f)
            {//牛奶
                if(GameManager._instance.score>=2)
                    GameManager._instance.score -= 2f;
                else
                    GameManager._instance.score = 0f;
                GameManager._instance.setScoreText();
                eatmilk++;
            }
            else
            {//哑铃
                if (GameManager._instance.score >= 5)
                    GameManager._instance.score -= 5f;
                else
                    GameManager._instance.score = 0f;
                GameManager._instance.setScoreText();
                eatyaling++;
            }
        }
    }

    public void loadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void canMoveTrue()
    {
        isCanMove = true;
    }

    void Move()
    {
        if (isCanMove)
        {
            //if (Input.GetKeyDown("space"))
            if (Input.GetMouseButtonDown(0)||Input.GetKeyDown("space"))
            {
                rb.velocity = new Vector2(0, jumpForce);
                anim.SetTrigger("jump");
                AudioSourceController.PlaySnd("Audio", "jump");
            }

        }

        Vector3 angle = transform.eulerAngles;

        angle.z += (rb.velocity.y * rotateScale);

        angle.z = angle.z - 180;
        if (angle.z > 0)
        {
            angle.z -= 180;
        }
        else
        {
            angle.z += 180;
        }
        angle.z = Mathf.Clamp(angle.z, -maxAngle, maxAngle);
        transform.eulerAngles = angle;
    }

    public void Pause()
    {
        if (isCanMove)
        {
            Time.timeScale = 0;
            isCanMove = false;
        }
        else
        {
            Time.timeScale = 1;
            isCanMove = true;

        }
    }

    //角色死亡后设置死亡界面分数
    void SetScore()
    {
        var a = GameManager._instance.score;
        if(a == 0)
        {
            diedPanel.GetComponent<Image>().sprite = Resources.Load("9", typeof(Sprite)) as Sprite;
        }
        else if(a<20)
        {
            diedPanel.GetComponent<Image>().sprite = Resources.Load("4", typeof(Sprite)) as Sprite;
            Image.sprite = Resources.Load("6", typeof(Sprite)) as Sprite;
        }
        else if(a<40)
        {
            diedPanel.GetComponent<Image>().sprite = Resources.Load("5", typeof(Sprite)) as Sprite;
            Image.sprite = Resources.Load("6", typeof(Sprite)) as Sprite;
        }
        else if(a < 60)
        {
            diedPanel.GetComponent<Image>().sprite = Resources.Load("1", typeof(Sprite)) as Sprite;
            Image.sprite = Resources.Load("8", typeof(Sprite)) as Sprite;
        }
        else if(a < 80)
        {
            diedPanel.GetComponent<Image>().sprite = Resources.Load("3", typeof(Sprite)) as Sprite;
            Image.sprite = Resources.Load("8", typeof(Sprite)) as Sprite;
        }
        else
        {
            diedPanel.GetComponent<Image>().sprite = Resources.Load("2", typeof(Sprite)) as Sprite;
            Image.sprite = Resources.Load("7", typeof(Sprite)) as Sprite;
        }
        diedPanelyaling.text = eatyaling.ToString();
        diedPanelmilk.text = eatmilk.ToString();
        diedPanelshuiguan.text = flyshuiguan.ToString();
        //eatyaling = 0;
        //eatmilk = 0;
        //flyshuiguan = 0;
        diedPanel.SetActive(true);
        alpha.SetActive(true);
    }

    IEnumerator WaitForReload(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetScore();//设置死亡后界面分数
        restartButton.SetActive(true);
    }
    IEnumerator WaitForAudio(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        AudioSourceController.PlaySnd("Audio", "wm");
    }
    IEnumerator WaitForRestartButton(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        restartButton.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    int scoreA;
    int scoreB;
    public int force;
    Text score_a;
    Text score_b;
    Rigidbody2D rigid;
    GameObject panelSelesai;
    Text pemenang;
    AudioSource audio;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        scoreA = 0;
        scoreB = 0;
        score_a = GameObject.Find("scoreA").GetComponent<Text>();
        score_b = GameObject.Find("scoreB").GetComponent<Text>();

        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RisetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }
    void ShowScore()
    {
        Debug.Log("score A : " + scoreA + "score B : " + scoreB);
        score_a.text = scoreA + "";
        score_b.text = scoreB + "";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(hitSound);
        if(collision.gameObject.name  == "TepiKanan"){
            RisetBall();
            if (scoreA == 10)
            {
                panelSelesai.SetActive(true);
                pemenang = GameObject.Find("pemenang").GetComponent<Text>();
                pemenang.text = ("Player A menang!");
                Destroy(gameObject);
                return;
            }
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
            scoreA += 1;
            ShowScore();
            
        }
        if(collision.gameObject.name == "TepiKiri")
        {
            RisetBall();
            if (scoreB == 10)
            {
                panelSelesai.SetActive(true);
                pemenang = GameObject.Find("pemenang").GetComponent<Text>();
                pemenang.text = ("Player B menang!");
                Destroy(gameObject);
                return;
            }
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
            scoreB += 1;
            ShowScore();
            

        }
        if(collision.gameObject.name == "pentung1" || collision.gameObject.name == "pentung2")
        {
            float sudut = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
    }

}

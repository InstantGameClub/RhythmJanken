using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{

    public GameController game_controller;
    public EnemyNotesView enemy_notes_view;
    public OrderView order_view;

    public Button[] PlayerNotes;


    public Slider TimerGage;
    public int TimerValMax;
    public int timeDamageRate;
    public int missDamageRate;
    public int hitRecoveryRate;

    public int score;
    public int incScoreBase = 1000;

    public Text scoreText;

    public int combo;
    public Text ComboText;

    // 勝ち＝1、負け＝2、引き分け＝0
    public int NowOrder;
    public int playCount;
    public Text Count;
    public Text Judge;

    public int resetOrderCount = 10;

    // グー＝0、チョキ＝1、パー＝2
    public List<int> EnemyNotes = new List<int>();

    // 行：プレイヤー、列：エネミーにおける勝敗行列(orderResult[PlayerNote,EnemyNote])
    private int[,] orderResult = new int[3, 3]
    {
        {0,1,2},
        {2,0,1},
        {1,2,0}
    };


    // 初期化
    public void initialize()
    {
        gageInitialize();
        destroyAllNotes();
        resetScore();
        resetCombo();
        InputOff();
        order_view.allDisable();
        playCount = 0;
    }

    public void initializeGameStart()
    {
        for (int loop = 0; loop < 7; loop++)
        {
            createNotes();
        }
        setOrder();
        InputOn();
    }

    public void initializeGameOver()
    {
        InputOff();
    }

    //　エネミーノーツ関連
    public void createNotes()
    {
        int note = Random.Range(0,3);
        EnemyNotes.Add(note);
        enemy_notes_view.createNotes(note);
    }

    public void destroyAllNotes()
    {
        EnemyNotes.Clear();
        EnemyNotes = new List<int>();
        enemy_notes_view.destroyAllNotes();
    }

    public void destroyFirstNotes()
    {
        EnemyNotes.RemoveAt(0);
        enemy_notes_view.destroyFirstNotes();
        enemy_notes_view.sortPositionNotes();
    }

    // タイマーゲージ関連
    public void gageInitialize()
    {
        TimerGage.value = TimerValMax;
    }

    public void gageInc(int inc)
    {
        TimerGage.value += inc;
        if (TimerGage.value > TimerValMax) TimerGage.value = TimerValMax;
    }
    public void gageDec(int dec)
    {
        TimerGage.value -= dec;
        checkGage();
    }
    public void gageDec()
    {
        TimerGage.value -= timeDamageRate;
        checkGage();
    }

    public void checkGage()
    {
        if (TimerGage.value <= 0)
        {
            game_controller.GameOver();
        }
    }

    // プレイヤーノーツ関連
    public void InputOff()
    {
        foreach (Button Note in PlayerNotes)
        {
            Note.enabled = false;
        }
    }

    public void InputOn()
    {
        foreach (Button Note in PlayerNotes)
        {
            Note.enabled = true;
        }
    }

    // スコアとタイマーゲージ減少処理　todo
    public void inputPlayerNotes(int noteNum)
    {
        playCount++;
        Count.text = playCount.ToString();
        Debug.Log("noteNum" + noteNum);
        Debug.Log("EnemyNotes[0]" + EnemyNotes[0]);
        Debug.Log("orderResult" + orderResult[noteNum, EnemyNotes[0]]);
        Debug.Log("NowOrder" + NowOrder);

        if (orderResult[noteNum, EnemyNotes[0]] == NowOrder)
        {
            gageInc(hitRecoveryRate);

            incScore();

            // コンボ
            incCombo();

            // debag
            Debug.Log("OK");
            Judge.text = ("あたり");
            Judge.color = new Color(0,1,0);
        }
        else
        {
            gageDec(missDamageRate);

            // コンボ
            resetCombo();

            // debag
            Debug.Log("NG");
            Judge.text = ("ちげぇ");
            Judge.color = new Color(1, 0, 0);
        }

        destroyFirstNotes();
        createNotes();
        if(playCount % resetOrderCount == 0) {
            setOrder();
        }
    }

    // オーダー関連
    public void setOrder() {
        int order = Random.Range(0, 3);
        NowOrder = order;
        order_view.changeOrderImage(order);
    }

    // コンボ関連
    public void incCombo() {
        combo++;
        ComboText.text = combo + "Combo!";
    }

    public void resetCombo()
    {
        combo = 0;
        ComboText.text = combo + "Combo!";
    }

    // スコア関連
    public void incScore()
    {
        score += incScoreBase + (int)(incScoreBase * 0.25f * combo);
        scoreText.text = score.ToString("0000000");
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = score.ToString("0000000");
    }

}

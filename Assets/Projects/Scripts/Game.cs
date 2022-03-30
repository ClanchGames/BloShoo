using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    public GameObject BossHPBarScreen;
    public BannerAd bannerAd;
    [SerializeField]
    private RectTransform blocks_;

    [SerializeField]
    private GameObject blockPrefab_;

    [SerializeField]
    private Text scoreText_;

    [SerializeField]
    private GameObject[] itemPrefabs_;

    [SerializeField]
    private RectTransform items_;

    public GameObject[] Beamprefab;
    bool isAddBeam;
    public GameObject[] SideBeamprefab;


    public RectTransform Beams_;

    [SerializeField]
    private GameObject Bar;

    [SerializeField]
    private GameObject BossPrefab;

    private float beamtime = 0.4f;
    private float sidebeamtime = 0.5f;
    private float BlockGenerateTime = 0.45f;
    private float BossTime = 88f;
    private float ItemTime = 22f;
    public int ItemGenerateTimes = 3;
    private float timeElapsed1;
    private float timeElapsed2;
    private float timeElapsed_sidebeam;
    private float timeElapsed_Boss;
    private float timeElapsed_Item;
    public GameObject ClearScreen;
    public SE sE;

    public RectTransform SuperItem;
    public List<GameObject> SuperItemList;
    int ItemChooseTimes;
    public GameObject GameOver_;
    public RectTransform Balls;
    public RectTransform BarRect;
    public GameObject[] HPBars;

    public int life_ = 3;
    public int score_;
    bool isBoss = true;
    bool issidebeam = false;
    public bool BossAppear = false;

    public bool ItemAppear = false;
    public bool isBossDown = false;
    public bool isContinue = false;
    public bool setbosshpbar = false;

    //  public bool isBallReset = false;
    public int ContinueTimes = 0;

    bool se = true;
    bool ads = true;
    public GameObject ScoreScreen;
    public GameObject[] SuperItemPrefab;
    public GameObject ContinueScreen;
    int scoreItemcount;
    int oneupItemcount;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(UnityEngine.Application.persistentDataPath);
        isContinue = false;
        Time.timeScale = 1.0f;
        ContinueTimes = 0;
        life_ = 3;
        score_ = 0;
        scoreText_.text = "Score:" + score_.ToString();


    }
    void OnEnable()
    {
        bannerAd.hide = true;
    }

    private void FixedUpdate()
    {
        /* if (setbosshpbar)
         {
             SetBossHPBar();
             setbosshpbar = false;
             GameObject.Find("Core").GetComponent<Core>().sethpbar = true;
         }*/
        if (!isBossDown)
        {
            // Debug.Log(timeElapsed_Boss);
            if (issidebeam)
            {
                timeElapsed_sidebeam += Time.deltaTime;
            }
            timeElapsed1 += Time.deltaTime;
            timeElapsed2 += Time.deltaTime;

            if (!ItemAppear)
                timeElapsed_Item += Time.deltaTime;
            //  Debug.Log(timeElapsed2);
            if (isBoss && !ItemAppear)
                timeElapsed_Boss += Time.deltaTime;

            if (timeElapsed1 >= beamtime)
            {
                if (!BossAppear)
                {
                    BeamGenerator(Bar.transform.position);
                    timeElapsed1 = 0.0f;
                }
            }
            if (timeElapsed_sidebeam >= sidebeamtime)
            {
                if (!BossAppear)
                {
                    SideBeamGenerator();
                    timeElapsed_sidebeam = 0.0f;
                }
            }
            if (ItemAppear)
            {
                timeElapsed2 = 0.0f;
            }
            if (timeElapsed2 >= BlockGenerateTime)
            {
                if (isBoss)
                {
                    BlockGenerator();
                    timeElapsed2 = 0.0f;
                }
            }

            if (timeElapsed_Boss >= BossTime)
            {
                BossGenerator();
                DestroyBlocks();
                timeElapsed_Boss = 0.0f;
                isBoss = false;
                BossAppear = true;

            }

            if (timeElapsed_Item >= ItemTime && ItemGenerateTimes != 0)
            {

                if (isBoss)
                {
                    ItemGenerator();
                    ItemGenerateTimes--;
                    // ItemTime += 10f;
                    ItemAppear = true;
                    timeElapsed_Item = 0.0f;
                    BlockGenerateTime -= 0.1f;
                    DestroyBlocks();

                }
                else
                {
                    timeElapsed_Item = 0.0f;
                }

            }
        }
        if (isBossDown)
        {
            if (se)
            {
                Invoke("GameClear", 3f);
                se = false;
            }
        }
    }
    public void SetBossHPBar()
    {
        BossHPBarScreen.SetActive(true);
    }
    void ItemGenerator()
    {
        for (int i = 0; i < 2; i++)
        {
            int choosenum = Random.Range(0, SuperItemList.Count);
            GameObject superitem = Instantiate(SuperItemList[choosenum]);

            RectTransform transform = superitem.GetComponent<RectTransform>();
            superitem.transform.SetParent(SuperItem, false);

            if (i == 0)
            {
                superitem.name = "SuperItem1";
                transform.anchoredPosition = new Vector2(-370, 100);

            }
            else
            {
                superitem.name = "SuperItem2";
                transform.anchoredPosition = new Vector2(370, 100);

            }

            SuperItemList.RemoveAt(choosenum);

        }

    }

    void GameClear()
    {
        ClearScreen.SetActive(true);
        // sE.GameClearSE();

        GameObject BGM_Boss = GameObject.Find("BGM_Boss");
        AudioSource bgmboss = BGM_Boss.GetComponent<AudioSource>();
        bgmboss.enabled = false;


    }
    void BlockGenerator()
    {

        GameObject block = Instantiate(blockPrefab_);

        RectTransform transform = block.GetComponent<RectTransform>();

        block.transform.SetParent(blocks_, false);
        //blockはblocks_を親にする　falseでローカル座標が維持される

        int[] xpos = { -200, -100, 0, 100, 200 };

        int choosexpos = Random.Range(0, 5); //int Randomは以上、未満

        transform.anchoredPosition = new Vector2(xpos[choosexpos], 365);

    }
    public void DestroyBlocks()
    {
        var clones = GameObject.FindGameObjectsWithTag("Block");

        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
    public void DestroyEnemyAttacks()
    {
        var clones = GameObject.FindGameObjectsWithTag("LastBossAttack");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
    void BossGenerator()
    {
        GameObject BossClone = Instantiate(BossPrefab);
        RectTransform BossTransform = BossClone.GetComponent<RectTransform>();
        RectTransform EnemyRect = GameObject.Find("Enemy").GetComponent<RectTransform>();
        BossTransform.SetParent(EnemyRect, false);
        BossTransform.localPosition = new Vector3(0, 550, 0);

    }
    public void BeamGenerator(Vector2 pos)
    {

        if (isAddBeam)
        {
            GameObject BeamClone = Instantiate(Beamprefab[1]);

            RectTransform BeamTransform = BeamClone.GetComponent<RectTransform>();
            BeamTransform.SetParent(Beams_, false);
            pos.y += 30; //位置を調整する

            BeamTransform.position = pos;
        }
        else
        {
            GameObject BeamClone = Instantiate(Beamprefab[0]);
            RectTransform BeamTransform = BeamClone.GetComponent<RectTransform>();
            BeamTransform.SetParent(Beams_, false);
            pos.y += 30; //位置を調整する

            BeamTransform.position = pos;
        }

    }
    public void StartSideBeam()
    {
        issidebeam = true;
    }
    /* public void SideBeamGenerator(Vector2 pos)
     {
         GameObject SideBeamClone = Instantiate(SideBeamprefab[0]);
         SideBeamClone.tag = "RightBeam";
         RectTransform BeamTransform = SideBeamClone.GetComponent<RectTransform>();
         BeamTransform.SetParent(Beams_, false);
         //位置を調整する
         pos.y += 30;
         pos.x += 100;
         BeamTransform.position = pos;
         pos.y -= 30;
         pos.x -= 100;


         GameObject SideBeamClone2 = Instantiate(SideBeamprefab[1]);
         SideBeamClone2.tag = "LeftBeam";
         RectTransform BeamTransform2 = SideBeamClone2.GetComponent<RectTransform>();
         BeamTransform2.SetParent(Beams_, false);
         //位置を調整する
         pos.y += 30;
         pos.x -= 100;
         BeamTransform2.position = pos;
         pos.y -= 30;
         pos.x += 100;

     }*/
    public void SideBeamGenerator()
    {
        GameObject RightSide = GameObject.Find("RightSide");
        GameObject LeftSide = GameObject.Find("LeftSide");

        Vector3 rpos = RightSide.transform.position;
        Vector3 lpos = LeftSide.transform.position;
        rpos.y += 40;
        lpos.y += 40;

        GameObject SideBeamClone = Instantiate(SideBeamprefab[0]);
        RectTransform RightBeamTransform = SideBeamClone.GetComponent<RectTransform>();
        RightBeamTransform.SetParent(Beams_, false);
        RightBeamTransform.position = rpos;

        GameObject SideBeamClone2 = Instantiate(SideBeamprefab[1]);
        RectTransform LeftBeamTransform = SideBeamClone2.GetComponent<RectTransform>();
        LeftBeamTransform.SetParent(Beams_, false);

        LeftBeamTransform.position = lpos;
    }

    public void CreateItemAtRandom(Vector2 position)
    {  /*
        int createornot = Random.Range(0, 100);
        if (createornot < 5) //5%の確率でアイテム発生*/


        scoreItemcount++;
        oneupItemcount++;


        if (oneupItemcount >= 50)
        {

            GameObject itemPrefab = itemPrefabs_[0];
            GameObject newItem = Instantiate(itemPrefab);

            RectTransform transform = newItem.GetComponent<RectTransform>();
            transform.SetParent(items_, false);

            transform.position = position;
            oneupItemcount = 0;
        }

        if (scoreItemcount >= 10)
        {

            GameObject itemPrefab = itemPrefabs_[1];
            GameObject newItem = Instantiate(itemPrefab);

            RectTransform transform = newItem.GetComponent<RectTransform>();
            transform.SetParent(items_, false);

            transform.position = position;
            scoreItemcount = 0;
        }

    }
    public void GameOver()
    {

        GameOver_.SetActive(true);
        gameObject.SetActive(false);
    }

    public void RecoverHPBar()
    {
        if (life_ < 3)
        {

            ++life_;

            if (life_ == 1)
            {
                HPBars[2].SetActive(true);
            }
            else if (life_ == 2)
            {
                HPBars[2].SetActive(true);
                HPBars[1].SetActive(true);
            }
            else if (life_ == 3)
            {
                HPBars[2].SetActive(true);
                HPBars[1].SetActive(true);
                HPBars[0].SetActive(true);
            }
        }
    }
    public void HPBarsFull()
    {
        HPBars[2].SetActive(true);
        HPBars[1].SetActive(true);
        HPBars[0].SetActive(true);
    }
    public void AddScore(int score)
    {
        score_ += score;
        scoreText_.text = "Score:" + score_.ToString();

    }
    public int Score
    {
        get { return score_; }
    }

    public void AddBall(int colornumber)
    {
        GameObject BallCopy = Instantiate(SuperItemPrefab[colornumber]);
        BallCopy.name = SuperItemPrefab[colornumber].name;
        RectTransform BallCopyTransform = BallCopy.GetComponent<RectTransform>();
        BallCopyTransform.SetParent(Balls, false);
        BallCopyTransform.localPosition = new Vector3(0, -250f, 0);
    }
    public void AddBar()
    {
        RectTransform barrect = Bar.GetComponent<RectTransform>();
        float barwidth = barrect.sizeDelta.x;
        Vector2 barsize = barrect.sizeDelta;
        barsize = new Vector2(240, 20);
        barrect.sizeDelta = barsize;

        BoxCollider2D barcollider = Bar.GetComponent<BoxCollider2D>();
        barcollider.size = barsize;

        Image barcolor = Bar.GetComponent<Image>();
        barcolor.color = Color.gray;

        BarManager barManager = Bar.GetComponent<BarManager>();
        barManager.isAddBar = true;
        /*GameObject BarCopy = Instantiate(SuperItemPrefab[3]);
        RectTransform BarCopyTransform = BarCopy.GetComponent<RectTransform>();
        BarCopyTransform.SetParent(BarRect, false);
        BarCopyTransform.localPosition = new Vector3(107f, 0f, 0);

        GameObject BarCopy2 = Instantiate(SuperItemPrefab[3]);
        RectTransform BarCopyTransform2 = BarCopy2.GetComponent<RectTransform>();
        BarCopyTransform2.SetParent(BarRect, false);
        BarCopyTransform2.localPosition = new Vector3(-107f, 0f, 0);
        BarMove barMove = Bar.GetComponent<BarMove>();
        barMove.isAddBar = true;*/
    }
    public void AddBeam()
    {
        isAddBeam = true;
        beamtime -= 0.15f;
    }

    public void AddOption(int num)
    {

        GameObject OptionArea = GameObject.Find("OptionArea");
        RectTransform OptionAreaRect = OptionArea.GetComponent<RectTransform>();

        GameObject Option = Instantiate(SuperItemPrefab[num]);
        RectTransform OptionRect = Option.GetComponent<RectTransform>();
        OptionRect.SetParent(OptionAreaRect, false);
        if (num == 4)
        {
            Option.name = "Option";
            OptionRect.localPosition = new Vector3(0, -380, 0);
        }
        if (num == 5)
        {
            Option.name = "RightOption";
            OptionRect.localPosition = new Vector3(230, -380, 0);
        }
        if (num == 6)
        {
            Option.name = "LeftOption";
            OptionRect.localPosition = new Vector3(-230, -380, 0);
        }

    }
    public void AddBallBeam()
    {

    }

    /* public void RewardContinue()
     {
         ContinueScreen.SetActive(false);
         HPBarsFull();
         DestroyBlocks();
         isContinue = true;
         life_ = 3;
         ContinueTimes = 1;
         Time.timeScale = 1.0f;
     }*/
    public void ContinueGame()
    {
        GameObject startbutton = GameObject.Find("StartButton");
        startbutton.GetComponent<Image>().enabled = true;
        startbutton.GetComponent<Button>().enabled = true;
        GameObject taptostart = GameObject.Find("taptostart");
        taptostart.GetComponent<Text>().enabled = true;
        GameObject.Find("ContinueScreen").SetActive(false);
        HPBarsFull();
        DestroyEnemyAttacks();
        DestroyBlocks();
        isContinue = true;
        life_ = 3;
        ContinueTimes = 1;
    }

}
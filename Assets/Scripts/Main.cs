using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;


public class Main : SingletonBase<Main>
{

    private Vector3 startPos = new Vector3(-2.18423247f,0.341821343f,0.0126060247f);
    private Vector3 startRo = new Vector3(0f, 63.4500618f, 0f);
    private Vector3 startCamRo = new Vector3(0.150053501f, 0f, 0f);

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private GameObject introScreen;

    [SerializeField]
    private GameObject startScreen;

    [SerializeField]
    private GameObject finishScreen;

    [SerializeField]
    private GameObject helpScreen;

    [SerializeField]
    private GameObject optionScreen;


    [SerializeField]
    private Button startBtn;

    [SerializeField]
    private Button reStartBtn;

    [SerializeField]
    private Button enterhelpBtn;

    [SerializeField]
    private Button enterOptionBtn;

    [SerializeField]
    private GameObject titleBar;

    [SerializeField]
    private GameObject tabIndex;

    [SerializeField]
    private SectionBase[] sections;

    [SerializeField]
    public AudioSource audioPlayer;

    [SerializeField]
    private AudioSource clickAudio;

    [SerializeField]
    private Texture2D moveCursorTexture;

    [SerializeField]
    private Texture2D linkCursorTexture;

    [SerializeField]
    private AudioClip introAudio;

    [SerializeField]
    private AudioClip infoAudio;

    [SerializeField]
    public GameObject repositionBtn;

    public MessageDialog alert;

    public LoginData loginData;

    public string LabName;

    public int initIndex = 0;


    private float audioLength = 0;


    private int sectionIndex = 0;


    public delegate void OnAudioFinish();

    private OnAudioFinish onAudioFinish = null;

    private bool isFullscreen = false;
    private bool keyPressed = false;

    private IEnumerator coAudio = null;

    private bool isFirst = true;

    private float helpPosY;

    

    void Awake()
    {
        String data = PlayerPrefs.GetString("loginData");
        loginData = JsonUtility.FromJson<LoginData>(data);
        LabName = PlayerPrefs.GetString("LabName");
        Debug.Log(JsonUtility.ToJson(loginData));

        if(LabName == "Lab2") 
        {
            if(loginData.data.a1 == "2")        initIndex = 1;
            if(loginData.data.a2 == "2")        initIndex = 2;
            if(loginData.data.a3 == "2")        initIndex = 3;
            if(loginData.data.a4 == "2")        initIndex = 4;
            if(loginData.data.a5 == "2")        initIndex = 5;
            if(loginData.data.a6 == "2")        initIndex = 6;
            if(loginData.data.a7 == "2")        initIndex = 7;
        }
        else if(LabName == "Lab")
        {
            if(loginData.data.b1 == "2")        initIndex = 1;
            if(loginData.data.b2 == "2")        initIndex = 2;
            if(loginData.data.b3 == "2")        initIndex = 3;
        }
        else if(LabName == "Lab3")
        {
            if(loginData.data.c1 == "2")        initIndex = 1;
            if(loginData.data.c2 == "2")        initIndex = 2;
            if(loginData.data.c3 == "2")        initIndex = 3;
            if(loginData.data.c4 == "2")        initIndex = 4;
            if(loginData.data.c5 == "2")        initIndex = 5;
            if(loginData.data.c6 == "2")        initIndex = 6;
        }
        
        SetCursor(false);

        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        foreach(SectionBase section in sections) 
        {
            section.onSectionEnd += SectionEnd;
            section.onSectionStart += SectionStart;
        }
    
        enterhelpBtn.onClick.AddListener(HideHelp);
        enterOptionBtn.onClick.AddListener(HideOption);
        repositionBtn.GetComponent<Button>().onClick.AddListener(OnSectionReposition);
        StartCoroutine(StartMain());
        // player.GetComponent<Player>().isActive = true;
        // StartCoroutine(StartContent());
    }


    private void Update() 
    {
        if(Input.GetKey("f11"))
        {
            if(keyPressed) return;
            if(!isFullscreen) 
            {
                Screen.fullScreen = true;
                isFullscreen = true;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
            } 
            else 
            {
                Screen.fullScreen = false;
                isFullscreen = false;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
            }
            
            keyPressed = true;
        } 
        else 
        {
            keyPressed = false;
        }
    }


    private IEnumerator StartMain () 
    {
        yield return new WaitForSeconds( 0.5f );
        player.transform.DOLocalMove(startPos, 2f);
        player.transform.DOLocalRotate(startRo, 2f);
        camera.transform.DOLocalRotate(startCamRo, 2f);
        StartCoroutine(showIntroScreen());
    }

    private IEnumerator showIntroScreen () 
    {
        yield return new WaitForSeconds( 1f );
        introScreen.SetActive(true);
        CanvasGroup introScreenCG = introScreen.GetComponent<CanvasGroup>();
        introScreenCG.alpha = 0;
        DOTween.To(() => introScreenCG.alpha, x => introScreenCG.alpha = x, 1f, 0.6f);
        StartCoroutine(hideIntroScreen());
    }

    private IEnumerator hideIntroScreen () 
    {
        yield return new WaitForSeconds( 5f );
        CanvasGroup introScreenCG = introScreen.GetComponent<CanvasGroup>();
        DOTween
        .To(() => introScreenCG.alpha, x => introScreenCG.alpha = x, 0f, 0.6f)
        .OnComplete(() => {
            introScreen.SetActive(false);
            StartCoroutine(ShowStartScreen());
        });
    }

    private IEnumerator ShowStartScreen () 
    {
        yield return new WaitForSeconds( 0.5f );
        PlayAudio(introAudio);
        startScreen.SetActive(true);
        CanvasGroup startScreenCG = startScreen.GetComponent<CanvasGroup>();
        startScreenCG.alpha = 0;
        DOTween
        .To(() => startScreenCG.alpha, x => startScreenCG.alpha = x, 1f, 0.6f)
        .OnComplete(() => {
            startBtn.onClick.AddListener(OnStartClick);
        });
        player.GetComponent<Collider>().isTrigger = false;
    }


    private void OnStartClick()
    {
        StopAudio();
        startBtn.onClick.RemoveListener(OnStartClick);
        startScreen.SetActive(false);
        player.GetComponent<Player>().isActive = true;
        ShowHelp();
    }

    private IEnumerator StartContent () 
    {
        yield return new WaitForSeconds( 0.3f );
        player.GetComponent<Player>().isActive = false;
        titleBar.SetActive(true);
        tabIndex.SetActive(true);
        sectionIndex = initIndex == sections.Length ? 0 : initIndex;
        tabIndex.GetComponent<TabMenu>().currentIndex = sectionIndex;
        tabIndex.GetComponent<TabMenu>().onTabChange += OnChangeTabmenu;
        sections[sectionIndex].StartSection(true);
        repositionBtn.SetActive(false);
    }

    private void OnChangeTabmenu( int idx )
    {
        foreach(SectionBase section in sections) 
        {
            section.ResetSection();
        }
        sectionIndex = idx;
        sections[sectionIndex].StartSection();
        repositionBtn.SetActive(false);
        Debug.Log("change tab: " + idx);
    }

    private void SectionStart () 
    {
        repositionBtn.SetActive(true);
    }


    private void SectionEnd () 
    {
        player.GetComponent<Player>().isActive = false;
        foreach(SectionBase section in sections) 
        {
            section.ResetSection();
        }

        sectionIndex++;
        if(sectionIndex < sections.Length) 
        {
            tabIndex.GetComponent<TabMenu>().currentIndex = sectionIndex;
            sections[sectionIndex].StartSection();
        } 
        else 
        {
            Debug.Log("flow finish");
            finishScreen.SetActive(true);
            CanvasGroup finishScreenCG = finishScreen.GetComponent<CanvasGroup>();
            finishScreenCG.alpha = 0;
            DOTween.To(() => finishScreenCG.alpha, x => finishScreenCG.alpha = x, 1f, 0.6f);
            player.GetComponent<Player>().isActive = false;
            reStartBtn.onClick.AddListener(ClickReStart);
        }
        repositionBtn.SetActive(false);
        
        Debug.Log("section end"+ sectionIndex +", "+sections.Length);
    }

    private void ClickReStart () 
    {
        finishScreen.SetActive(false);
        reStartBtn.onClick.RemoveListener(ClickReStart);
        foreach(SectionBase section in sections) 
        {
            section.ResetSection();
        }
        sectionIndex = 0;
        tabIndex.GetComponent<TabMenu>().currentIndex = sectionIndex;
        sections[sectionIndex].StartSection();
        repositionBtn.SetActive(false);
    }


    public void PlayAudio ( AudioClip clip, OnAudioFinish onFinish = null )
    {
        audioLength = clip.length;
        onAudioFinish = onFinish;
        audioPlayer.clip = clip;
        audioPlayer.time = 0;
        audioPlayer.Play();
        coAudio = AduioFinish();
        StartCoroutine(coAudio);
    }
    public void StopAudio ()
    {
        if(coAudio != null) StopCoroutine(coAudio);
        audioPlayer.Stop();
    }

    private IEnumerator AduioFinish () 
    {
        yield return new WaitWhile(() => audioPlayer.isPlaying);
        if(onAudioFinish != null) onAudioFinish();
    }

    private void OnSectionReposition () 
    {
        sections[sectionIndex].RepositionSection();
    }
    
    public void SkipAudio () 
    {
        Debug.Log("audioLength : " + audioLength);
        audioPlayer.time = audioLength - 1f;
    }

    public void SetAudioVolume( float volume ) 
    {
        audioPlayer.volume = volume;
        clickAudio.volume = volume;
    }

    public void PlayClickAudio ()
    {
        clickAudio.time = 0f;
        clickAudio.Play();
    }

    public void SetCursor ( bool isCursor ) 
    {
        if(isCursor) 
        {
            Cursor.SetCursor(linkCursorTexture, new Vector2(15, 0), CursorMode.ForceSoftware);
        } 
        else 
        {
            Cursor.SetCursor(moveCursorTexture, new Vector2(15, 0), CursorMode.ForceSoftware);
        }
    }

    public void ShowHelp () 
    {
        helpScreen.SetActive(true);
        RectTransform rect = helpScreen.GetComponent<RectTransform>() as RectTransform;
        helpPosY = rect.localPosition.y;

        rect.localPosition = new Vector3(0, helpPosY - 30f, 0);
        rect.DOLocalMoveY(helpPosY, 0.6f).SetEase(Ease.OutCubic);
        if(isFirst) 
        {
            PlayAudio(infoAudio);
        }
    }

    public void HideHelp () 
    {
        RectTransform rect = helpScreen.GetComponent<RectTransform>() as RectTransform;
        helpPosY = rect.localPosition.y;
        rect.DOLocalMoveY(helpPosY - 30f, 0.6f).SetEase(Ease.OutCubic).OnComplete(() => {
            helpScreen.SetActive(false);
            rect.localPosition = new Vector3(0, helpPosY, 0);
        });
        if(isFirst) 
        {
            StopAudio();
            StartCoroutine(StartContent());
            isFirst = false;
        }
    }

    public void ShowOption () 
    {
        CanvasGroup cg = optionScreen.GetComponent<CanvasGroup>();
        cg.alpha = 1;
        cg.interactable = cg.blocksRaycasts = true;
        RectTransform rect = optionScreen.GetComponent<RectTransform>() as RectTransform;
        rect.DOScale(0, 0);
        rect.DOScale(1, 0.6f).SetEase(Ease.OutBack);
    }

    public void HideOption () 
    {
        CanvasGroup cg = optionScreen.GetComponent<CanvasGroup>();
        cg.alpha = 0;
        cg.interactable = cg.blocksRaycasts = false;
        Debug.Log("volume : " + PlayerPrefs.GetInt("volume"));
    }

    
}

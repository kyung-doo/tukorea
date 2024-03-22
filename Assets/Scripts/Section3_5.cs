using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section3_5 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public TabMenu tabMenu;


    [SerializeField]
    public GameObject touch1;
    [SerializeField]
    public GameObject touch2;
    [SerializeField]
    public GameObject touch3;
    [SerializeField]
    public GameObject touch4;
    [SerializeField]
    public GameObject touch5;
    [SerializeField]
    public GameObject touch6;
    [SerializeField]
    public GameObject touch7;
    [SerializeField]
    public GameObject touch8;
    [SerializeField]
    public GameObject touch9;
    [SerializeField]
    public GameObject touch10;
    [SerializeField]
    public GameObject touch11;
    [SerializeField]
    public GameObject touch12;
    [SerializeField]
    public GameObject touch13;
    [SerializeField]
    public GameObject touch14;
    [SerializeField]
    public GameObject touch15;
    [SerializeField]
    public GameObject touch16;
    [SerializeField]
    public GameObject touch17;
    [SerializeField]
    public GameObject touch18;
    [SerializeField]
    public GameObject touch19;
    [SerializeField]
    public GameObject touch20;
    [SerializeField]
    public GameObject touch21;
    [SerializeField]
    public GameObject touch22;
    


    
    [SerializeField]
    public GameObject screen1;
    [SerializeField]
    public GameObject screen2;
    [SerializeField]
    public GameObject screen3;
    [SerializeField]
    public GameObject screen4;
    [SerializeField]
    public GameObject screen5;
    [SerializeField]
    public GameObject screen6;
    [SerializeField]
    public GameObject screen7;
    [SerializeField]
    public GameObject screen8;
    [SerializeField]
    public GameObject screen9;
    [SerializeField]
    public GameObject screen10;
    [SerializeField]
    public GameObject screen11;

    [SerializeField]
    public GameObject toggle;

    [SerializeField]
    public GameObject text1;
    [SerializeField]
    public GameObject text2;
    [SerializeField]
    public GameObject text3;
    [SerializeField]
    public GameObject text4;
    [SerializeField]
    public GameObject text5;
    [SerializeField]
    public GameObject text6;
    [SerializeField]
    public GameObject text7;
    [SerializeField]
    public GameObject text8;
    [SerializeField]
    public GameObject text9;
    [SerializeField]
    public GameObject text10;
    [SerializeField]
    public GameObject text11;
    [SerializeField]
    public GameObject text12;
    [SerializeField]
    public GameObject text13;
    [SerializeField]
    public GameObject text14;
    [SerializeField]
    public GameObject text15;
    [SerializeField]
    public GameObject text16;
    [SerializeField]
    public GameObject text17;
    [SerializeField]
    public GameObject text18;
    [SerializeField]
    public GameObject text19;
    [SerializeField]
    public GameObject text20;
    

    [SerializeField]
    public GameObject jumpOver;
    [SerializeField]
    public GameObject scanOver;
    [SerializeField]
    public GameObject lowCamOver;
    [SerializeField]
    public GameObject hiCamOver;

    [SerializeField]
    public GameObject jogNum1;
    [SerializeField]
    public GameObject jogNum2;


    private IEnumerator coTimer = null;

    private Vector3 zoomPlayerPos = new Vector3(-2.024493f, 0.2285329f, 4.831224f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -89.8f, 0f);
    private Vector3 zoomCameraRo = new Vector3(0.35f, 0f, 0f);

    private bool isZoom = false;



    public override void StartSection ( bool isFirst = false ) 
    {
        screen1.SetActive(true);
        screen2.SetActive(true);
        screen3.SetActive(false);
        screen4.SetActive(true);
        screen5.SetActive(true);
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            touch1.SetActive(true);
            touch1.GetComponent<Animator>().Play("touch");
            touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1;
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickTouch1 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.GetComponent<Animator>().Rebind();
        screen6.SetActive(true);
        coTimer = Start2();
        
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[1], () => {
            touch2.SetActive(true);
            touch2.GetComponent<Animator>().Play("touch");
            touch2.GetComponent<Clickable>().onMouseClick += ClickTouch2;
        });
    }

    private void ClickTouch2 ( GameObject target, Vector3 mousePos ) 
    {
        touch2.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.GetComponent<Animator>().Rebind();
        toggle.SetActive(true);
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[2], () => {
            screen7.SetActive(true);
            touch3.SetActive(true);
            touch3.GetComponent<Animator>().Play("touch");
            coTimer = Start4();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 3f );
        touch3.SetActive(false);
        Main.Instance.PlayAudio(audioClips[3], () => {
            touch4.SetActive(true);
            touch4.GetComponent<Animator>().Play("touch");
            touch4.GetComponent<Clickable>().onMouseClick += ClickTouch4;
        });
    }

    private void ClickTouch4 ( GameObject target, Vector3 mousePos ) 
    {
        touch4.SetActive(false);
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch4.GetComponent<Animator>().Rebind();
        
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[4], () => {
            touch5.SetActive(true);
            touch5.GetComponent<Animator>().Play("touch");
            touch5.GetComponent<Clickable>().onMouseClick += ClickTouch5;
        });
    }

    private void ClickTouch5 ( GameObject target, Vector3 mousePos ) 
    {
        touch5.SetActive(false);
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch5;
        touch5.GetComponent<Animator>().Rebind();
        screen8.SetActive(true);
        
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 1f );
        touch6.SetActive(true);
        touch6.GetComponent<Animator>().Play("touch");
        touch6.GetComponent<Clickable>().onMouseClick += ClickTouch6;
    }

    private void ClickTouch6 ( GameObject target, Vector3 mousePos ) 
    {
        touch6.SetActive(false);
        touch6.GetComponent<Clickable>().onMouseClick -= ClickTouch6;
        touch6.GetComponent<Animator>().Rebind();
        screen8.SetActive(false);
        
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 1f );
        touch7.SetActive(true);
        touch7.GetComponent<Animator>().Play("touch");
        touch7.GetComponent<Clickable>().onMouseClick += ClickTouch7;
    }

    private void ClickTouch7 ( GameObject target, Vector3 mousePos ) 
    {
        touch7.SetActive(false);
        touch7.GetComponent<Clickable>().onMouseClick -= ClickTouch7;
        touch7.GetComponent<Animator>().Rebind();
        coTimer = Start8();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds( 1f );
        isZoom = true;
        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(1f)
        .OnComplete(() => {
            tabMenu.CloseMenu();
            screen9.SetActive(true);
            screen9.GetComponent<Animator>().Play("picture1");
            screen9.GetComponent<Animator>().speed = 0;
            text1.SetActive(true);
            Main.Instance.PlayAudio(audioClips[5], () => {
                touch8.SetActive(true);
                touch8.GetComponent<Animator>().Play("touch");
                touch8.GetComponent<Clickable>().onMouseClick += ClickTouch8;
            });
        });
    }

    private void ClickTouch8 ( GameObject target, Vector3 mousePos ) 
    {
        touch8.SetActive(false);
        touch8.GetComponent<Clickable>().onMouseClick -= ClickTouch8;
        touch8.GetComponent<Animator>().Rebind();
        text1.SetActive(false);
        screen10.SetActive(true);
        screen10.GetComponent<Animator>().Play("jump");
        screen10.GetComponent<Animator>().speed = 0;
        screen9.GetComponent<Animator>().speed = 1;
        coTimer = Start9();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start9() 
    {
        yield return new WaitForSeconds( 1f );
        text2.SetActive(true);
        Main.Instance.PlayAudio(audioClips[6], () => {
            touch9.SetActive(true);
            touch9.GetComponent<Animator>().Play("touch");
            coTimer = Start10();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start10() 
    {
        yield return new WaitForSeconds( 3f );
        text2.SetActive(false);
        touch9.SetActive(false);
        touch9.GetComponent<Animator>().Rebind();
        text3.SetActive(true);
        Main.Instance.PlayAudio(audioClips[7], () => {
            touch10.SetActive(true);
            touch10.GetComponent<Animator>().Play("touch");
            touch10.GetComponent<Clickable>().onMouseClick += ClickTouch10;
        });
    }

    private void ClickTouch10 ( GameObject target, Vector3 mousePos ) 
    {
        touch10.SetActive(false);
        touch10.GetComponent<Clickable>().onMouseClick -= ClickTouch10;
        touch10.GetComponent<Animator>().Rebind();
        jumpOver.SetActive(true);
        scanOver.SetActive(false);
        
        coTimer = Start11();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start11() 
    {
        yield return new WaitForSeconds( 1f );
        touch11.SetActive(true);
        touch11.GetComponent<Animator>().Play("touch");
        touch11.GetComponent<Clickable>().onMouseClick += ClickTouch11;
    }

    private void ClickTouch11 ( GameObject target, Vector3 mousePos ) 
    {
        touch11.SetActive(false);
        touch11.GetComponent<Clickable>().onMouseClick -= ClickTouch11;
        touch11.GetComponent<Animator>().Rebind();
        screen10.GetComponent<Animator>().speed = 1;
        screen9.GetComponent<Animator>().Play("picture2");
        text3.SetActive(false);
        coTimer = Start12();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start12() 
    {
        yield return new WaitForSeconds( 2f );
        text4.SetActive(true);
        Main.Instance.PlayAudio(audioClips[8], () => {
            touch12.SetActive(true);
            touch12.GetComponent<Animator>().Play("touch");
            touch12.GetComponent<Clickable>().onMouseClick += ClickTouch12;
        });
        
    }

    private void ClickTouch12 ( GameObject target, Vector3 mousePos ) 
    {
        touch12.SetActive(false);
        touch12.GetComponent<Clickable>().onMouseClick -= ClickTouch12;
        touch12.GetComponent<Animator>().Rebind();
        screen9.GetComponent<Animator>().Play("picture3");
        text4.SetActive(false);
        hiCamOver.SetActive(false);
        lowCamOver.SetActive(true);
        coTimer = Start13();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start13() 
    {
        yield return new WaitForSeconds( 2f );
        text5.SetActive(true);
        Main.Instance.PlayAudio(audioClips[9], () => {
            touch13.SetActive(true);
            touch13.GetComponent<Animator>().Play("touch");
            coTimer = Start14();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start14() 
    {
        yield return new WaitForSeconds( 3f );
        touch13.SetActive(false);
        touch13.GetComponent<Animator>().Rebind();
        Main.Instance.PlayAudio(audioClips[10], () => {
            text5.SetActive(false);
            coTimer = Start15();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start15() 
    {
        yield return new WaitForSeconds( 2f );
        text6.SetActive(true);
        Main.Instance.PlayAudio(audioClips[11], () => {
            touch14.SetActive(true);
            touch14.GetComponent<Animator>().Play("touch");
            touch14.GetComponent<Clickable>().onMouseClick += ClickTouch14;
        });
    }

    private void ClickTouch14 ( GameObject target, Vector3 mousePos ) 
    {
        touch14.SetActive(false);
        touch14.GetComponent<Clickable>().onMouseClick -= ClickTouch14;
        touch14.GetComponent<Animator>().Rebind();
        scanOver.SetActive(true);
        jumpOver.SetActive(false);
        coTimer = Start16();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start16() 
    {
        yield return new WaitForSeconds( 2f );
        touch15.SetActive(true);
        touch15.GetComponent<Animator>().Play("touch");
        touch15.GetComponent<Clickable>().onMouseClick += ClickTouch15;
    }

    private void ClickTouch15 ( GameObject target, Vector3 mousePos ) 
    {
        touch15.SetActive(false);
        touch15.GetComponent<Clickable>().onMouseClick -= ClickTouch15;
        touch15.GetComponent<Animator>().Rebind();
        text6.SetActive(false);
        text7.SetActive(true);
        Main.Instance.PlayAudio(audioClips[12], () => {
            screen9.GetComponent<Animator>().Play("picture4");
            coTimer = Start17();
            StartCoroutine(coTimer);
        });
        
    }

    private IEnumerator Start17() 
    {
        yield return new WaitForSeconds( 2f );
        text7.SetActive(false);
        text8.SetActive(true);
        Main.Instance.PlayAudio(audioClips[13], () => {
            touch16.SetActive(true);
            touch16.GetComponent<Animator>().Play("touch");
            touch16.GetComponent<Clickable>().onMouseClick += ClickTouch16;
        });
    }

    private void ClickTouch16 ( GameObject target, Vector3 mousePos ) 
    {
        touch16.SetActive(false);
        touch16.GetComponent<Clickable>().onMouseClick -= ClickTouch16;
        touch16.GetComponent<Animator>().Rebind();
        text8.SetActive(false);
        hiCamOver.SetActive(true);
        lowCamOver.SetActive(false);
        screen9.GetComponent<Animator>().Play("picture5");
        coTimer = Start18();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start18() 
    {
        yield return new WaitForSeconds( 2f );
        text9.SetActive(true);
        Main.Instance.PlayAudio(audioClips[14], () => {
            touch17.SetActive(true);
            touch17.GetComponent<Clickable>().onMouseClick += ClickTouch17;
            text10.GetComponent<Animator>().Play("touch_image");
        });
    }

    private void ClickTouch17 ( GameObject target, Vector3 mousePos ) 
    {
        touch17.SetActive(false);
        touch17.GetComponent<Clickable>().onMouseClick -= ClickTouch17;
        screen9.GetComponent<Animator>().Play("g");
        text10.GetComponent<Animator>().Rebind();
        coTimer = Start19();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start19() 
    {
        yield return new WaitForSeconds( 2f );
        text9.SetActive(false);
        text11.SetActive(true);
        Main.Instance.PlayAudio(audioClips[15], () => {
            touch13.SetActive(true);
            text12.GetComponent<Animator>().Play("touch_image");
            touch18.SetActive(true);
            touch18.GetComponent<Clickable>().onMouseClick += ClickTouch18;
        });
    }

    private void ClickTouch18 ( GameObject target, Vector3 mousePos ) 
    {
        touch18.SetActive(false);
        touch18.GetComponent<Clickable>().onMouseClick -= ClickTouch18;
        text12.GetComponent<Animator>().Rebind();
        jogNum1.SetActive(false);
        jogNum2.SetActive(true);
        coTimer = Start20();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start20() 
    {
        yield return new WaitForSeconds( 1f );
        touch19.SetActive(true);
        touch19.SetActive(true);
        touch19.GetComponent<Clickable>().onMouseClick += ClickTouch19;
        text13.GetComponent<Animator>().Play("touch_image");
        
    }

    private void ClickTouch19 ( GameObject target, Vector3 mousePos ) 
    {
        touch19.SetActive(false);
        touch19.GetComponent<Clickable>().onMouseClick -= ClickTouch19;
        text11.SetActive(false);
        text13.GetComponent<Animator>().Rebind();
        screen9.GetComponent<Animator>().Play("picture6");
        touch13.SetActive(false);
        coTimer = Start21();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start21() 
    {
        yield return new WaitForSeconds( 2f );
        text14.SetActive(true);
        Main.Instance.PlayAudio(audioClips[16], () => {
            touch20.SetActive(true);
            touch20.GetComponent<Clickable>().onMouseClick += ClickTouch20;
            text15.GetComponent<Animator>().Play("touch_image");
        });
    }

    private void ClickTouch20 ( GameObject target, Vector3 mousePos ) 
    {
        touch20.SetActive(false);
        touch20.GetComponent<Clickable>().onMouseClick -= ClickTouch20;
        text15.GetComponent<Animator>().Rebind();
        // 애니추가
        coTimer = Start22();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start22() 
    {
        yield return new WaitForSeconds( 2f );
        
        text14.SetActive(false);
        text16.SetActive(true);
        Main.Instance.PlayAudio(audioClips[17], () => {
            touch21.SetActive(true);
            touch21.GetComponent<Clickable>().onMouseClick += ClickTouch21;
            // 마우스휠 애니
            // text17.GetComponent<Animator>().Play("touch_image");
        });
    }

    private void ClickTouch21 ( GameObject target, Vector3 mousePos ) 
    {
        touch21.SetActive(false);
        touch21.GetComponent<Clickable>().onMouseClick -= ClickTouch21;
        // text17.GetComponent<Animator>().Rebind();
        // 애니추가
        coTimer = Start23();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start23() 
    {
        yield return new WaitForSeconds( 1f );
        text16.SetActive(false);
        text18.SetActive(true);
        Main.Instance.PlayAudio(audioClips[18], () => {
            touch22.SetActive(true);
            touch22.GetComponent<Clickable>().onMouseClick += ClickTouch22;
            text19.GetComponent<Animator>().Play("touch_image");
        });
    }

    private void ClickTouch22 ( GameObject target, Vector3 mousePos ) 
    {
        touch22.SetActive(false);
        touch22.GetComponent<Clickable>().onMouseClick -= ClickTouch22;
        text19.GetComponent<Animator>().Rebind();
        coTimer = Start24();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start24() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[19], () => {
            coTimer = Start25();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start25() 
    {
        yield return new WaitForSeconds( 2f );
        text18.SetActive(false);
        text20.SetActive(true);
        Main.Instance.PlayAudio(audioClips[20], () => {
            
        });
    }

    

    


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 4.0f );
        this.EndSection();
    }

    public override void RepositionSection ()
    {
        if(!isZoom) 
        {
            base.RepositionSection();
        } 
        else 
        {
            player.transform.DOLocalMove(zoomPlayerPos, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo, 3f).SetEase(Ease.OutCubic);
        }
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();

        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.SetActive(false);
        touch3.SetActive(false);
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch4.SetActive(false);
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch5;
        touch5.SetActive(false);
        touch6.GetComponent<Clickable>().onMouseClick -= ClickTouch6;
        touch6.SetActive(false);
        touch7.GetComponent<Clickable>().onMouseClick -= ClickTouch7;
        touch7.SetActive(false);
        touch8.GetComponent<Clickable>().onMouseClick -= ClickTouch8;
        touch8.SetActive(false);
        touch9.SetActive(false);
        touch10.GetComponent<Clickable>().onMouseClick -= ClickTouch10;
        touch10.SetActive(false);
        touch11.GetComponent<Clickable>().onMouseClick -= ClickTouch11;
        touch11.SetActive(false);
        touch12.GetComponent<Clickable>().onMouseClick -= ClickTouch12;
        touch12.SetActive(false);
        touch13.SetActive(false);
        touch14.GetComponent<Clickable>().onMouseClick -= ClickTouch14;
        touch14.SetActive(false);
        touch15.GetComponent<Clickable>().onMouseClick -= ClickTouch15;
        touch15.SetActive(false);
        touch16.GetComponent<Clickable>().onMouseClick -= ClickTouch16;
        touch16.SetActive(false);
        touch17.GetComponent<Clickable>().onMouseClick -= ClickTouch17;
        touch17.SetActive(false);
        touch18.GetComponent<Clickable>().onMouseClick -= ClickTouch18;
        touch18.SetActive(false);
        touch19.GetComponent<Clickable>().onMouseClick -= ClickTouch19;
        touch19.SetActive(false);
        touch20.GetComponent<Clickable>().onMouseClick -= ClickTouch20;
        touch20.SetActive(false);
        touch21.GetComponent<Clickable>().onMouseClick -= ClickTouch21;
        touch21.SetActive(false);
        touch22.GetComponent<Clickable>().onMouseClick -= ClickTouch22;
        touch22.SetActive(false);
        
        
        
        
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        screen5.SetActive(false);
        screen6.SetActive(false);
        screen7.SetActive(false);
        screen8.SetActive(false);
        screen9.SetActive(false);
        screen9.GetComponent<Animator>().Rebind();
        screen9.GetComponent<Animator>().speed = 1;
        screen10.GetComponent<Animator>().Rebind();
        screen10.GetComponent<Animator>().speed = 1;
        
        

        toggle.SetActive(false);

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);
        text7.SetActive(false);
        text8.SetActive(false);
        text9.SetActive(false);
        text10.GetComponent<Animator>().Rebind();
        text11.SetActive(false);
        text12.GetComponent<Animator>().Rebind();
        text13.GetComponent<Animator>().Rebind();
        text14.SetActive(false);
        text15.GetComponent<Animator>().Rebind();
        text16.SetActive(false);
        text17.GetComponent<Animator>().Rebind();
        text18.SetActive(false);
        text19.GetComponent<Animator>().Rebind();
        text20.SetActive(false);
        
        
        

        scanOver.SetActive(true);
        jumpOver.SetActive(false);
        hiCamOver.SetActive(true);
        lowCamOver.SetActive(false);
        jogNum1.SetActive(true);
        jogNum2.SetActive(false);
        
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}

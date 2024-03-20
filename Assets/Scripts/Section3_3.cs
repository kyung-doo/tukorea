using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section3_3 : SectionBase
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
    public GameObject screen0;

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
    public GameObject alert1;


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
    public GameObject scanOver;
    [SerializeField]
    public GameObject jumpOver;

    [SerializeField]
    public GameObject hicamOver;
    [SerializeField]
    public GameObject lowcamOver;

    [SerializeField]
    public GameObject plusBox;

    


    private IEnumerator coTimer = null;



    public override void StartSection ( bool isFirst = false ) 
    {
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        screen0.SetActive(true);
        screen2.SetActive(true);
        text1.SetActive(true);
        yield return new WaitForSeconds( 3.5f );
        tabMenu.CloseMenu();
        Main.Instance.PlayAudio(audioClips[0], () => {
            touch1.SetActive(true);
            touch1.GetComponent<Animator>().Play("touch");
            touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1;
        });
        Main.Instance.repositionBtn.SetActive(false);
        
    }

    private void ClickTouch1 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.GetComponent<Animator>().Rebind();
        screen1.SetActive(true);
        text1.SetActive(false);
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 2f );
        text2.SetActive(true);
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
        screen3.SetActive(true);
        text2.SetActive(false);
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 2f );
        text3.SetActive(true);
        Main.Instance.PlayAudio(audioClips[2], () => {
            touch3.SetActive(true);
            touch3.GetComponent<Animator>().Play("touch");
            touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3;
        });
    }

    private void ClickTouch3 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch3.GetComponent<Animator>().Rebind();
        screen4.SetActive(true);
        text3.SetActive(false);
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 2f );
        text4.SetActive(true);
        alert1.SetActive(true);
        Main.Instance.PlayAudio(audioClips[3], () => {
            coTimer = Start5();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 2f );
        alert1.SetActive(false);
        text4.SetActive(false);
        yield return new WaitForSeconds( 1f );
        text5.SetActive(true);
        Main.Instance.PlayAudio(audioClips[4], () => {
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
        text5.SetActive(false);
        scanOver.SetActive(false);
        jumpOver.SetActive(true);
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 1f );
        touch5.SetActive(true);
        touch5.GetComponent<Animator>().Play("touch");
        touch5.GetComponent<Clickable>().onMouseClick += ClickTouch5;
    }

    private void ClickTouch5 ( GameObject target, Vector3 mousePos ) 
    {
        touch5.SetActive(false);
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch5.GetComponent<Animator>().Rebind();
        screen4.GetComponent<Animator>().Play("PLUS");
        screen5.SetActive(true);
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 2f );
        text6.SetActive(true);
        Main.Instance.PlayAudio(audioClips[5], () => {
            touch6.SetActive(true);
            touch6.GetComponent<Animator>().Play("touch");
            touch6.GetComponent<Clickable>().onMouseClick += ClickTouch6;
        });
    }

    private void ClickTouch6 ( GameObject target, Vector3 mousePos ) 
    {
        touch6.SetActive(false);
        touch6.GetComponent<Clickable>().onMouseClick -= ClickTouch6;
        touch6.GetComponent<Animator>().Rebind();
        text6.SetActive(false);
        screen4.GetComponent<Animator>().Play("lowcam_ani");
        hicamOver.SetActive(false);
        lowcamOver.SetActive(true);
        coTimer = Start8();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds( 2f );
        text7.SetActive(true);
        Main.Instance.PlayAudio(audioClips[6], () => {
            plusBox.SetActive(true);
            coTimer = Start9();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start9() 
    {
        yield return new WaitForSeconds( 3f );
        plusBox.SetActive(false);
        Main.Instance.PlayAudio(audioClips[7], () => {
            touch7.SetActive(true);
            touch7.GetComponent<Animator>().Play("touch");
            touch7.GetComponent<Clickable>().onMouseClick += ClickTouch7;
        });
    }

    private void ClickTouch7 ( GameObject target, Vector3 mousePos ) 
    {
        touch7.SetActive(false);
        touch7.GetComponent<Clickable>().onMouseClick -= ClickTouch7;
        touch7.GetComponent<Animator>().Rebind();
        screen4.GetComponent<Animator>().Play("ILUM1");
        coTimer = Start10();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start10() 
    {
        yield return new WaitForSeconds( 1f );
        touch8.SetActive(true);
        touch8.GetComponent<Animator>().Play("touch");
        touch8.GetComponent<Clickable>().onMouseClick += ClickTouch8;
    }

    private void ClickTouch8 ( GameObject target, Vector3 mousePos ) 
    {
        touch8.SetActive(false);
        touch8.GetComponent<Clickable>().onMouseClick -= ClickTouch8;
        touch8.GetComponent<Animator>().Rebind();
        screen4.GetComponent<Animator>().Play("ZAXIS1");
        text7.SetActive(false);
        coTimer = Start11();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start11() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[8], () => {
            touch9.SetActive(true);
            touch9.GetComponent<Animator>().Play("touch");
            touch9.GetComponent<Clickable>().onMouseClick += ClickTouch9;
        });
    }

    private void ClickTouch9 ( GameObject target, Vector3 mousePos ) 
    {
        touch9.SetActive(false);
        touch9.GetComponent<Clickable>().onMouseClick -= ClickTouch9;
        touch9.GetComponent<Animator>().Rebind();
        lowcamOver.SetActive(false);
        hicamOver.SetActive(true);
        screen4.GetComponent<Animator>().Play("ZAXIS2");
        screen4.GetComponent<Animator>().speed = 0f;
        // coTimer = Start11();
        // StartCoroutine(coTimer);
    }

    


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 3.0f );
        this.EndSection();
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();

        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
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
        touch9.GetComponent<Clickable>().onMouseClick -= ClickTouch9;
        touch9.SetActive(false);

        screen0.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        screen4.GetComponent<Animator>().Rebind();
        screen4.GetComponent<Animator>().Update(0f);
        alert1.SetActive(false);
        screen5.SetActive(false);

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);
        text7.SetActive(false);

        scanOver.SetActive(true);
        jumpOver.SetActive(false);

        hicamOver.SetActive(true);
        lowcamOver.SetActive(false);

        plusBox.SetActive(false);

        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}

using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section3_4 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;


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
    public GameObject tool1;
    [SerializeField]
    public GameObject tool2;
    [SerializeField]
    public GameObject tool3;
    [SerializeField]
    public GameObject tool4;
    [SerializeField]
    public GameObject tool5;

    

    [SerializeField]
    public GameObject toolTouch2;

    [SerializeField]
    public GameObject toolTouch3;

    [SerializeField]
    public GameObject toolLine1;

    [SerializeField]
    public GameObject toolLine2;

    [SerializeField]
    public GameObject toolLine3;

    [SerializeField]
    public GameObject toolBtnOver1;

    [SerializeField]
    public GameObject toolBtnOver2;

    [SerializeField]
    public GameObject toolBtnOver3;
    
    
    private int toolClickCount = 0;


    private IEnumerator coTimer = null;



    public override void StartSection ( bool isFirst = false ) 
    {
        screen1.SetActive(true);
        screen2.SetActive(true);
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
        screen3.SetActive(true);
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
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 1f );
        touch3.SetActive(true);
        touch3.GetComponent<Animator>().Play("touch");
        touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3;
    }

    private void ClickTouch3 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch3.GetComponent<Animator>().Rebind();
        tool1.SetActive(false);
        tool2.SetActive(true);
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 1f );
        touch4.SetActive(true);
        touch4.GetComponent<Animator>().Play("touch");
        touch4.GetComponent<Clickable>().onMouseClick += ClickTouch4;
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
        yield return new WaitForSeconds( 1f );
        touch3.SetActive(true);
        touch3.GetComponent<Animator>().Play("touch");
        touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3_2;
    }

    private void ClickTouch3_2 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3_2;
        touch3.GetComponent<Animator>().Rebind();
        tool2.SetActive(false);
        tool3.SetActive(true);
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
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch5;
        touch5.GetComponent<Animator>().Rebind();
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 1f );
        touch3.SetActive(true);
        touch3.GetComponent<Animator>().Play("touch");
        touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3_3;
    }

    private void ClickTouch3_3 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3_3;
        touch3.GetComponent<Animator>().Rebind();
        tool3.SetActive(false);
        tool4.SetActive(true);
        coTimer = Start8();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[2], () => {
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

        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(true);
        screen5.SetActive(true);

        toolLine1.SetActive(true);
        toolLine2.SetActive(true);
        toolLine3.SetActive(true);
        toolBtnOver1.SetActive(true);
        toolBtnOver2.SetActive(true);
        toolBtnOver3.SetActive(true);

        coTimer = Start9();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start9() 
    {
        yield return new WaitForSeconds( 1f );
        toolClickCount = 0;
        Main.Instance.PlayAudio(audioClips[3], () => {
            toolTouch2.SetActive(true);
            toolTouch2.GetComponent<Animator>().Play("touch");
            toolTouch2.GetComponent<Clickable>().onMouseClick += ClickTool;

            toolTouch3.SetActive(true);
            toolTouch3.GetComponent<Animator>().Play("touch");
            toolTouch3.GetComponent<Clickable>().onMouseClick += ClickTool;
        });
    }

    private void ClickTool ( GameObject target, Vector3 mousePos ) 
    {
        target.SetActive(false);
        target.GetComponent<Clickable>().onMouseClick -= ClickTool;
        target.GetComponent<Animator>().Rebind();
        if(target.name == "touch02") 
        {
            toolLine2.SetActive(false);
            toolBtnOver2.SetActive(false);
        } 
        else 
        {
            toolLine3.SetActive(false);
            toolBtnOver3.SetActive(false);
            screen5.SetActive(false);
        }

        toolClickCount++;

        if(toolClickCount == 2) {
            coTimer = Start10();
            StartCoroutine(coTimer);
        }
    }

    private IEnumerator Start10() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[4], () => {
            touch1.SetActive(true);
            touch1.GetComponent<Animator>().Play("touch");
            touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1_2;
        });
    }

    private void ClickTouch1_2 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1_2;
        touch1.GetComponent<Animator>().Rebind();
        screen2.SetActive(true);
        screen3.SetActive(true);
        screen4.SetActive(false);
        screen5.SetActive(false);
        tool4.SetActive(false);
        tool5.SetActive(true);
        coTimer = Start11();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start11() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[5], () => {
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
        screen6.SetActive(true);
        coTimer = Start12();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start12() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[6], () => {
            screen7.SetActive(true);
            touch8.SetActive(true);
            touch8.GetComponent<Animator>().Play("touch");
            touch9.SetActive(true);
            touch9.GetComponent<Animator>().Play("touch");
            coTimer = Ended();
            StartCoroutine(coTimer);
        });
    }

    


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 4.0f );
        touch8.SetActive(false);
        touch8.GetComponent<Animator>().Rebind();
        touch9.SetActive(false);
        touch9.GetComponent<Animator>().Rebind();
        this.EndSection();
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();

        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1_2;
        touch1.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3_2;
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3_3;
        touch3.SetActive(false);
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch4.SetActive(false);
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch5;
        touch5.SetActive(false);
        touch6.GetComponent<Clickable>().onMouseClick -= ClickTouch6;
        touch6.SetActive(false);
        touch7.GetComponent<Clickable>().onMouseClick -= ClickTouch7;
        touch7.SetActive(false);
        touch8.SetActive(false);
        touch9.SetActive(false);
        
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        screen5.SetActive(false);
        screen6.SetActive(false);
        screen7.SetActive(false);

        tool1.SetActive(true);
        tool2.SetActive(false);
        tool3.SetActive(false);
        tool4.SetActive(false);
        tool5.SetActive(false);

        toolTouch2.GetComponent<Clickable>().onMouseClick += ClickTool;
        toolTouch2.SetActive(false);
        toolTouch3.GetComponent<Clickable>().onMouseClick += ClickTool;
        toolTouch3.SetActive(false);
        toolLine1.SetActive(false);
        toolLine2.SetActive(false);
        toolLine3.SetActive(false);
        toolBtnOver1.SetActive(false);
        toolBtnOver2.SetActive(false);
        toolBtnOver3.SetActive(false);
        
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}

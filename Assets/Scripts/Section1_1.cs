using System.Collections;
using UnityEngine;


public class Section1_1 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject target1;

    [SerializeField]
    public GameObject target2;

    [SerializeField]
    public Animator animator1;

    [SerializeField]
    public Animator animator2;

    [SerializeField]
    public GameObject glove;

    [SerializeField]
    public GameObject gloveUi;

    [SerializeField]
    public GameObject swiper;

    [SerializeField]
    public GameObject holder;

    [SerializeField]
    public GameObject powder;

    [SerializeField]
    public GameObject glass;

    [SerializeField]
    public GameObject goodBadUi;

    private IEnumerator coTimer = null;




    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection1");
        target1.SetActive(true);
        target2.SetActive(true);
        glove.GetComponent<BoxCollider>().enabled = false;
        swiper.GetComponent<BoxCollider>().enabled = false;
        holder.GetComponent<BoxCollider>().enabled = false;
        powder.GetComponent<BoxCollider>().enabled = false;
        glass.GetComponent<BoxCollider>().enabled = false;
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            Main.Instance.PlayAudio(audioClips[1], () => {
                animator1.Play("glove_outline_on");
                glove.GetComponent<BoxCollider>().enabled = true;
                glove.GetComponent<Clickable>().onMouseClick += ClickGlove;
            });
        });

        player.GetComponent<Player>().isActive = true;
    }
    
    private void ClickGlove ( GameObject target, Vector3 mousePos ) 
    {
        glove.GetComponent<BoxCollider>().enabled = false;
        glove.GetComponent<Clickable>().onMouseClick -= ClickGlove;
        animator1.Play("glove_disappear");
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds(0.5f );
        gloveUi.SetActive(true);
        Main.Instance.PlayAudio(audioClips[2], () => {
            animator2.Play("swiper_outline_on");
            swiper.GetComponent<BoxCollider>().enabled = true;
            swiper.GetComponent<Clickable>().onMouseClick += ClickSwiper;
        });
    }

    private void ClickSwiper ( GameObject target, Vector3 mousePos ) 
    {
        swiper.GetComponent<BoxCollider>().enabled = false;
        swiper.GetComponent<Clickable>().onMouseClick -= ClickSwiper;
        animator2.Play("swiper_move");
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds(1f);
        Main.Instance.PlayAudio(audioClips[3], () => {
            animator2.Play("holder_outline_on");
            holder.GetComponent<BoxCollider>().enabled = true;
            holder.GetComponent<Clickable>().onMouseClick += ClickHolder;
        });
    }

    private void ClickHolder ( GameObject target, Vector3 mousePos ) 
    {
        holder.GetComponent<BoxCollider>().enabled = false;
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        animator2.Play("holder_move");
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() {
        yield return new WaitForSeconds(1f);
        animator2.Play("powder_outline_on");
        powder.GetComponent<BoxCollider>().enabled = true;
        powder.GetComponent<Clickable>().onMouseClick += ClickPowder;
    }


    private void ClickPowder ( GameObject target, Vector3 mousePos ) 
    {
        powder.GetComponent<BoxCollider>().enabled = false;
        powder.GetComponent<Clickable>().onMouseClick -= ClickPowder;
        animator2.Play("powder_move");
        coTimer = OpenPowder();
        StartCoroutine(coTimer);
    }

    private IEnumerator OpenPowder() 
    {
        yield return new WaitForSeconds(1f);
        animator2.Play("powder_opener_move");
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds(2f);
        Main.Instance.PlayAudio(audioClips[4], () => {
            animator2.Play("glass_outline_on");
            glass.GetComponent<BoxCollider>().enabled = true;
            glass.GetComponent<Clickable>().onMouseClick += ClickGlass;
        });
    }

    private void ClickGlass ( GameObject target, Vector3 mousePos ) 
    {
        glass.GetComponent<BoxCollider>().enabled = false;
        glass.GetComponent<Clickable>().onMouseClick -= ClickGlass;
        animator2.Play("glass_move");
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds(4f);
        Main.Instance.PlayAudio(audioClips[5], () => {
            coTimer = Start7();
            StartCoroutine(coTimer);
        });
        goodBadUi.SetActive(true);
    }


    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds(3f);
        goodBadUi.SetActive(false);
        Main.Instance.PlayAudio(audioClips[6], () => {
            animator2.Play("glass_move_outline_on");
            glass.GetComponent<BoxCollider>().enabled = true;
            glass.GetComponent<Clickable>().onMouseClick += ClickGlass2;
        });
    }

    private void ClickGlass2 ( GameObject target, Vector3 mousePos ) 
    {
        glass.GetComponent<BoxCollider>().enabled = false;
        glass.GetComponent<Clickable>().onMouseClick -= ClickGlass2;
        animator2.Play("glass_move2");
        coTimer = Ended();
        StartCoroutine(coTimer);
    }



    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 7.0f );
        this.EndSection();
    }


    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        gloveUi.SetActive(false);
        goodBadUi.SetActive(false);
        animator1.Rebind();
        animator2.Rebind();
        target1.SetActive(false);
        target2.SetActive(false);
        glove.GetComponent<Clickable>().onMouseClick -= ClickGlove;
        swiper.GetComponent<Clickable>().onMouseClick -= ClickSwiper;
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        powder.GetComponent<Clickable>().onMouseClick -= ClickPowder;
        glass.GetComponent<Clickable>().onMouseClick -= ClickGlass;
        glass.GetComponent<Clickable>().onMouseClick -= ClickGlass2;
        if(coTimer != null) StopCoroutine(coTimer);
    }


    public override void EndSection () 
    {
        base.EndSection();
    }

}

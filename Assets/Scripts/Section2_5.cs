using System.Collections;
using UnityEngine;

public class Section2_5 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject target;

    [SerializeField]
    public GameObject holder;

    [SerializeField]
    public GameObject nickelCarbonTape;

    [SerializeField]
    public GameObject mounting;

    // [SerializeField]
    public GameObject carbonTape;


    [SerializeField]
    public Animator animator;


    private IEnumerator coTimer = null;
    



    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        target.SetActive(true);
        holder.GetComponent<BoxCollider>().enabled = false;
        nickelCarbonTape.GetComponent<BoxCollider>().enabled = false;
        mounting.GetComponent<BoxCollider>().enabled = false;
        carbonTape.GetComponent<BoxCollider>().enabled = false;
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            animator.Play("Holder03_outline_on");
            holder.GetComponent<BoxCollider>().enabled = true;
            holder.GetComponent<Clickable>().onMouseClick += ClickHolder;
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickHolder ( GameObject target, Vector3 mousePos ) 
    {
        holder.GetComponent<BoxCollider>().enabled = false;
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        animator.Play("Holder03_move");
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[1], () => {
            animator.Play("NickelCarbonTape_outline_on");
            nickelCarbonTape.GetComponent<BoxCollider>().enabled = true;
            nickelCarbonTape.GetComponent<Clickable>().onMouseClick += ClickNickelCarbonTape;
        });
    }

    private void ClickNickelCarbonTape ( GameObject target, Vector3 mousePos ) 
    {
        nickelCarbonTape.GetComponent<BoxCollider>().enabled = false;
        nickelCarbonTape.GetComponent<Clickable>().onMouseClick -= ClickNickelCarbonTape;
        animator.Play("NickelCarbonTape_move");
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 14f );
        Main.Instance.PlayAudio(audioClips[2], () => {
            animator.Play("Holder04_outline_on");
            mounting.GetComponent<BoxCollider>().enabled = true;
            mounting.GetComponent<Clickable>().onMouseClick += ClickMounting;
        });
    }

    private void ClickMounting ( GameObject target, Vector3 mousePos ) 
    {
        mounting.GetComponent<BoxCollider>().enabled = false;
        mounting.GetComponent<Clickable>().onMouseClick -= ClickMounting;
        animator.Play("Holder04_move");
        coTimer = Start4();
        StartCoroutine(coTimer);
    }


    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[3], () => {
            animator.Play("CarbonTape_outline_on");
            carbonTape.GetComponent<BoxCollider>().enabled = true;
            carbonTape.GetComponent<Clickable>().onMouseClick += ClickCarbonTape;
        });
    }

    private void ClickCarbonTape ( GameObject target, Vector3 mousePos ) 
    {
        carbonTape.GetComponent<BoxCollider>().enabled = false;
        carbonTape.GetComponent<Clickable>().onMouseClick -= ClickCarbonTape;
        animator.Play("CarbonTape_move");
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 10f );
        Main.Instance.PlayAudio(audioClips[4], () => {
            animator.Play("mount_outline_on");
            mounting.GetComponent<BoxCollider>().enabled = true;
            mounting.GetComponent<Clickable>().onMouseClick += ClickMounting2;
        });
    }



    private void ClickMounting2 ( GameObject target, Vector3 mousePos ) 
    {
        mounting.GetComponent<BoxCollider>().enabled = false;
        mounting.GetComponent<Clickable>().onMouseClick -= ClickMounting2;
        animator.Play("mount_move");
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 4f );
        Main.Instance.PlayAudio(audioClips[5], () => {
            coTimer = Ended();
            StartCoroutine(coTimer);
        });
    }


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 3.0f );
        this.EndSection();
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        animator.Rebind();
        target.SetActive(false);
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        nickelCarbonTape.GetComponent<Clickable>().onMouseClick -= ClickNickelCarbonTape;
        mounting.GetComponent<Clickable>().onMouseClick -= ClickMounting;
        carbonTape.GetComponent<Clickable>().onMouseClick -= ClickCarbonTape;
        
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}

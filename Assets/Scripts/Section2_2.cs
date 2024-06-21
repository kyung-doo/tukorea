using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Section2_2 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject target;

    [SerializeField]
    public Animator animator;

    [SerializeField]
    public GameObject holder;

    [SerializeField]
    public GameObject nickelCarbonTape;

    [SerializeField]
    public GameObject carbonTape;

    [SerializeField]
    public GameObject powder;

    [SerializeField]
    public GameObject pincette;

    [SerializeField]
    public GameObject airblo;

    [SerializeField]
    public GameObject sampling;


    private IEnumerator coTimer = null;
    



    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        target.SetActive(true);
        holder.GetComponent<BoxCollider>().enabled = false;
        nickelCarbonTape.GetComponent<BoxCollider>().enabled = false;
        carbonTape.GetComponent<BoxCollider>().enabled = false;
        powder.GetComponent<BoxCollider>().enabled = false;
        pincette.GetComponent<BoxCollider>().enabled = false;
        sampling.GetComponent<BoxCollider>().enabled = false;
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
        if(Main.Instance.initIndex == 1 && Main.Instance.loginData.data.a2 == "0")
        {
            StartCoroutine(base.SaveContent("a2", "1", () => Main.Instance.loginData.data.a2 = "1"));
        }
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
        yield return new WaitForSeconds( 2.5f );
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
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 8f );
        Main.Instance.PlayAudio(audioClips[3], () => {
            animator.Play("powder_outline_on");
            powder.GetComponent<BoxCollider>().enabled = true;
            powder.GetComponent<Clickable>().onMouseClick += ClickPowder;
        });
    }

    private void ClickPowder ( GameObject target, Vector3 mousePos ) 
    {
        powder.GetComponent<BoxCollider>().enabled = false;
        powder.GetComponent<Clickable>().onMouseClick -= ClickPowder;
        animator.Play("powder_move");
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 3.5f );
        animator.Play("Pincette_outline_on");
        pincette.GetComponent<BoxCollider>().enabled = true;
        pincette.GetComponent<Clickable>().onMouseClick += ClickPincette;
    }

    private void ClickPincette ( GameObject target, Vector3 mousePos ) 
    {
        pincette.GetComponent<BoxCollider>().enabled = false;
        pincette.GetComponent<Clickable>().onMouseClick -= ClickPincette;
        animator.Play("Pincette_move");
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 7f );
        Main.Instance.PlayAudio(audioClips[4], () => {
            animator.Play("Airblo_outline_on");
            airblo.GetComponent<BoxCollider>().enabled = true;
            airblo.GetComponent<Clickable>().onMouseClick += ClickAirblo;
        });
    }

    private void ClickAirblo ( GameObject target, Vector3 mousePos ) 
    {
        airblo.GetComponent<BoxCollider>().enabled = false;
        airblo.GetComponent<Clickable>().onMouseClick -= ClickAirblo;
        animator.Play("Airblo_move");
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 4.5f );
        Main.Instance.PlayAudio(audioClips[5], () => {
            coTimer = Start8();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[6], () => {
            animator.Play("sampling_outline_on");
            sampling.GetComponent<BoxCollider>().enabled = true;
            sampling.GetComponent<Clickable>().onMouseClick += ClickSampling;
        });
    }

    private void ClickSampling ( GameObject target, Vector3 mousePos ) 
    {
        sampling.GetComponent<BoxCollider>().enabled = false;
        sampling.GetComponent<Clickable>().onMouseClick -= ClickSampling;
        animator.Play("sampling_move");
        coTimer = Ended();
        StartCoroutine(coTimer);
    }

    

    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 10.0f );
        this.EndSection();
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        animator.Rebind();
        target.SetActive(false);
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        nickelCarbonTape.GetComponent<Clickable>().onMouseClick -= ClickNickelCarbonTape;
        carbonTape.GetComponent<Clickable>().onMouseClick -= ClickCarbonTape;
        powder.GetComponent<Clickable>().onMouseClick -= ClickPowder;
        pincette.GetComponent<Clickable>().onMouseClick -= ClickPincette;
        airblo.GetComponent<Clickable>().onMouseClick -= ClickAirblo;
        sampling.GetComponent<Clickable>().onMouseClick -= ClickSampling;
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        if(Main.Instance.initIndex == 1 && Main.Instance.loginData.data.a2 == "1")
        {
            Main.Instance.initIndex = 2;
            StartCoroutine(base.SaveContent("a2", "2", () => Main.Instance.loginData.data.a2 = "2"));
        }
        base.EndSection();
    }

}

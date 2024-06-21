using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Section1_2 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject target;

    [SerializeField]
    public Animator animator;

    [SerializeField]
    public GameObject tongs;

    [SerializeField]
    public GameObject vernierCalipers;

    [SerializeField]
    public GameObject measureUi;


    private IEnumerator coTimer = null;
    



    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        target.SetActive(true);
        tongs.GetComponent<BoxCollider>().enabled = false;
        vernierCalipers.GetComponent<BoxCollider>().enabled = false;
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
        if(Main.Instance.initIndex == 1 && Main.Instance.loginData.data.b2 == "0")
        {
            StartCoroutine(base.SaveContent("b2", "1", () => Main.Instance.loginData.data.b2 = "1"));
        }
    }
    

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            Main.Instance.PlayAudio(audioClips[1], () => {
                animator.Play("Tongs_outline_on");
                tongs.GetComponent<BoxCollider>().enabled = true;
                tongs.GetComponent<Clickable>().onMouseClick += ClickTongs;
            });
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickTongs ( GameObject target, Vector3 mousePos ) 
    {
        tongs.GetComponent<BoxCollider>().enabled = false;
        tongs.GetComponent<Clickable>().onMouseClick -= ClickTongs;
        animator.Play("Tongs_move");
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds(4f);
        Main.Instance.PlayAudio(audioClips[2], () => {
            animator.Play("Vernier_Calipers_outline_on");
            vernierCalipers.GetComponent<BoxCollider>().enabled = true;
            vernierCalipers.GetComponent<Clickable>().onMouseClick += ClickVernierCalipers;
        });
    }

    private void ClickVernierCalipers ( GameObject target, Vector3 mousePos ) 
    {
        vernierCalipers.GetComponent<BoxCollider>().enabled = false;
        vernierCalipers.GetComponent<Clickable>().onMouseClick -= ClickVernierCalipers;
        animator.Play("Vernier_Calipers_move");
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds(2f);
        measureUi.SetActive(true);
        Main.Instance.PlayAudio(audioClips[3], () => {
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
        measureUi.SetActive(false);
        tongs.GetComponent<Clickable>().onMouseClick -= ClickTongs;
        vernierCalipers.GetComponent<Clickable>().onMouseClick -= ClickVernierCalipers;
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        if(Main.Instance.initIndex == 1 && Main.Instance.loginData.data.b2 == "1")
        {
            Main.Instance.initIndex = 2;
            StartCoroutine(base.SaveContent("b2", "2", () => Main.Instance.loginData.data.b2 = "2"));
        }
        base.EndSection();
    }

}

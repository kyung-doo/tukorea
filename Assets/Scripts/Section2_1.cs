using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Section2_1 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject guide1;

    [SerializeField]
    public GameObject guide2;

    [SerializeField]
    public GameObject guide3;


    private IEnumerator coTimer = null;
    



    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        guide1.SetActive(true);
        guide2.SetActive(true);
        guide3.SetActive(true);
        guide1.GetComponent<CanvasGroup>().alpha = 0;
        guide2.GetComponent<CanvasGroup>().alpha = 0;
        guide3.GetComponent<CanvasGroup>().alpha = 0;
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 1f );
        CanvasGroup cg = guide1.GetComponent<CanvasGroup>();
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 1f, 0.6f);
        Main.Instance.PlayAudio(audioClips[0], () => {
            DOTween.To(() => cg.alpha, x => cg.alpha = x, 0f, 0.6f);
            coTimer = Start2();
            StartCoroutine(coTimer);
        });
        player.GetComponent<Player>().isActive = true;
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 1f );
        CanvasGroup cg = guide2.GetComponent<CanvasGroup>();
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 1f, 0.6f);
        Main.Instance.PlayAudio(audioClips[1], () => {
            DOTween.To(() => cg.alpha, x => cg.alpha = x, 0f, 0.6f);
            coTimer = Start3();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 1f );
        CanvasGroup cg = guide3.GetComponent<CanvasGroup>();
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 1f, 0.6f);
        Main.Instance.PlayAudio(audioClips[2], () => {
            DOTween.To(() => cg.alpha, x => cg.alpha = x, 0f, 0.6f);
            coTimer = Ended();
            StartCoroutine(coTimer);
        });
    }


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 1.0f );
        this.EndSection();
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        guide1.SetActive(false);
        guide2.SetActive(false);
        guide3.SetActive(false);
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}

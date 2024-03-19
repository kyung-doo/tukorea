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
    public GameObject screen0;

    [SerializeField]
    public GameObject screen1;
    [SerializeField]
    public GameObject screen2;

    [SerializeField]
    public GameObject text1;


    private IEnumerator coTimer = null;



    public override void StartSection ( bool isFirst = false ) 
    {
        touch1.SetActive(false);
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
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickTouch1 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.GetComponent<Animator>().Rebind();
        screen1.SetActive(true);
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[1], () => {
            // touch1.SetActive(true);
            // touch1.GetComponent<Animator>().Play("touch");
            // touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1;
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
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        screen0.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
        text1.SetActive(false);
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}

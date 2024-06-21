using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.Networking;
using System;

public abstract class SectionBase : MonoBehaviour
{
    [SerializeField]
    protected Vector3 startPlayerPos;

    [SerializeField]
    protected Vector3 startPlayerRo;

    [SerializeField]
    protected Vector3 startCameraRo;

    [SerializeField]
    public bool isBackMotion = false;

    
    protected GameObject player;

    protected GameObject camera;


    public delegate void OnSectionEnd();

    public event OnSectionEnd onSectionEnd;

    public delegate void OnSectionStart();

    public event OnSectionEnd onSectionStart;

    public delegate void SaveCallback();

    private SaveCallback saveCallback = null;

    


    void Awake()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Camera");
    }

    public virtual void StartSection ( bool isFirst = false ) 
    {
        Ease ease = Ease.OutCubic;
        if(isFirst) 
        {
            ease = Ease.InOutCubic;
        }

        if(startPlayerPos != Vector3.zero) 
        {
            player.transform.DOLocalMove(startPlayerPos, 3f).SetEase(ease);
            player.transform.DOLocalRotate(startPlayerRo, 3f).SetEase(ease);
            camera.transform.DOLocalRotate(startCameraRo, 3f)
            .SetEase(ease)
            .OnComplete(() => {
                if(onSectionStart != null) onSectionStart();
            });
        } 
        
    }

    public virtual void RepositionSection ()
    {
        player.transform.DOLocalMove(startPlayerPos, 3f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 3f).SetEase(Ease.OutCubic);
        camera.transform.DOLocalRotate(startCameraRo, 3f).SetEase(Ease.OutCubic);
    }

    public abstract void ResetSection();


    public virtual void EndSection () 
    {
        if(onSectionEnd != null) onSectionEnd();
    }

    public virtual IEnumerator SaveContent( string type, string status, SaveCallback callback ) {
        saveCallback = callback;
        UnityWebRequest request;
        Debug.Log(String.Format(StringVars.STATUS_API, Main.Instance.loginData.data.memberSeq, type, status));
        using (request = UnityWebRequest.Get(String.Format(StringVars.STATUS_API, Main.Instance.loginData.data.memberSeq, type, status)))
        {            
            yield return request.SendWebRequest();
            saveCallback();
            saveCallback = null;
        }
    }
}

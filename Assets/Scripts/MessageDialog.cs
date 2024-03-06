using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MessageDialog : SingletonBase<MessageDialog>
{
    

    [SerializeField]
    public Text messageText;

    [SerializeField]
    public Button confirmBtn;

    [SerializeField]
    public Button cancelBtn;

    [SerializeField]
    public RectTransform container;


    public delegate void ConfirmCallback();
    public delegate void CancelCallback();

    private ConfirmCallback confirmCall = null;
    private CancelCallback cancelCall = null; 

    private bool _noCloseAni = false;


    private bool _visible = true;
    public bool visible 
    {
        get {
            return _visible;
        }
        set{
            CanvasGroup cg = this.GetComponent<CanvasGroup>();
            cg.alpha = value ? 1 : 0;
            cg.interactable = value;
            cg.blocksRaycasts = value;
            _visible = value;
        }
    } 

    private void Awake()
    {
        confirmBtn.onClick.AddListener(OnClickConfirm);
        cancelBtn.onClick.AddListener(OnClickCancel);
    }


    public static void Show ( string message, ConfirmCallback confirmCallback = null, CancelCallback cancelCallback = null, bool noCloseAni = false )
    {
        Instance.ShowMessage(message, confirmCallback, cancelCallback, noCloseAni);
    }

    public static void Hide()
    {
        Instance.HideMessage();
    }


    private void ShowMessage ( string message, ConfirmCallback confirmCallback = null, CancelCallback cancelCallback = null, bool noCloseAni = false)
    {
        messageText.text = message;
        confirmCall = confirmCallback;
        cancelCall = cancelCallback;
        _noCloseAni = noCloseAni;
        ShowAnimation();
    }


    private void ShowAnimation() 
    {
        CanvasGroup cg = this.GetComponent<CanvasGroup>() as CanvasGroup;

        container.localScale = new Vector3(0f, 0f, 0.2f);
        cg.alpha = 0;

        DOTween.Kill(container);
        DOTween.Kill(cg);

        DOTween.To(() => container.localScale, x => container.localScale = x, new Vector3(0.2f, 0.2f, 0.2f), 0.5f).SetDelay(0.2f).SetEase(Ease.OutBack);
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 1f, 0.6f).SetDelay(0.2f);

        visible = true;
    }


    private void HideMessage() 
    {
        confirmCall = null;
        cancelCall = null;
        if(!_noCloseAni)
        {
            HideAnimation();
        }
        else 
        {
            visible = false;
        }
    }

    private void HideAnimation() 
    {
        CanvasGroup cg = this.GetComponent<CanvasGroup>() as CanvasGroup;
        DOTween.To(() => container.localScale, x => container.localScale = x, new Vector3(0f, 0f, 0.2f), 0.5f).SetEase(Ease.InOutBack);
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 0, 0.4f).OnComplete(() => visible = false);
    }

    private void OnClickConfirm ()
    {
        if(confirmCall != null)
        {
            confirmCall();
        }
        HideMessage();
    }

    private void OnClickCancel ()
    {
        if(cancelCall != null)
        {
            cancelCall();
        }
        _noCloseAni = false;
        HideMessage();
    }


}

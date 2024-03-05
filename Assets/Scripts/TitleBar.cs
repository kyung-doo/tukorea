using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TitleBar : MonoBehaviour
{
    [SerializeField]
    private Button helpBtn;

    [SerializeField]
    private Button confiBtn;

    [SerializeField]
    private Button quitBtn;


    


    private void Awake()
    {
        RectTransform rect = this.GetComponent<RectTransform>() as RectTransform;
        Vector3 targetPosition = rect.localPosition;
        rect.localPosition = new Vector3(0, targetPosition.y + 7.5f, 0);
        rect.DOLocalMoveY(targetPosition.y, 0.6f).SetEase(Ease.OutCubic);

        helpBtn.onClick.AddListener(ClickHelp);
        confiBtn.onClick.AddListener(ClickConfig);
        quitBtn.onClick.AddListener(ClickQuit);
    }

    

    private void ClickHelp () 
    {
        Main.Instance.ShowHelp();
    }

    private void ClickConfig () 
    {
        Main.Instance.ShowOption();
    }

    private void ClickQuit () 
    {
        MessageDialog.Show( "실습을 종료하시겠습니까?", () => Application.Quit());
    }

    
}

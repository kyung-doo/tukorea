using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    [SerializeField]
    private InputField idInput;

    [SerializeField]
    private InputField passInput;

    [SerializeField]
    private Button enterBtn;

    [SerializeField]
    private MessageDialog alert;

    [SerializeField]
    private string loadScene;



    private void Awake()
    {
        
        enterBtn.onClick.AddListener(OnClickEnter);
    }

    private void OnClickEnter () 
    {
        if(idInput.text == "") {
            alert.ShowMessage("아이디를 입력해 주세요.", () => {
                idInput.Select();
            });
            return;
        } 

        if(passInput.text == "") {
            alert.ShowMessage("패스워드를 입력해 주세요.");
            passInput.Select();
            return;
        } 

        SceneManager.LoadScene(loadScene, LoadSceneMode.Single);
    }

}

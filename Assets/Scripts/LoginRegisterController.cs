using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class LoginRegisterController : MonoBehaviour
{
    [SerializeField]
    private GameObject painelLogin, painelRegister;

    [SerializeField]
    private TMP_InputField userNameEmailLogin, senhaLogin;

    //register inputs
    [SerializeField]
    private TMP_InputField name, age, userName, Email, senha, confirmeSenha;

    void Start()
    {
        painelRegister.SetActive(false);
    }

    public void Login()
    {
        Debug.Log("Login: " + userNameEmailLogin.text + " Senha: " + senhaLogin.text);

        Debug.Log("realizando login . . .");

        StartCoroutine(Login_Coroutine());
       
        Debug.Log("tentativa finalizada");
    }

     IEnumerator Login_Coroutine()
    {
        string uriBase = "https://game-server-ifrit.herokuapp.com";
        string loginUri = uriBase + "/player/login";
        WWWForm form = new WWWForm();
        form.AddField("login", userNameEmailLogin.text);
        form.AddField("senha", senhaLogin.text);

        using (UnityWebRequest request = UnityWebRequest.Post(loginUri, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Debug.Log("Erro na requisição: " + request.error);
            else
                Debug.Log("Usuário Logado com sucesso");
            Debug.Log("Dados da requisição: ");
            Debug.Log(request.downloadHandler.text);
        }

    }

    public void Register()
    {
        Debug.Log("Name");
        Debug.Log(name.text);
        Debug.Log("Age");
        Debug.Log(age.text);

        Debug.Log("Username");
        Debug.Log(userName.text);
        Debug.Log("Email");
        Debug.Log(Email.text);

        Debug.Log("Senha");
        Debug.Log(senha.text);
        Debug.Log("ConfirmeSenha");
        Debug.Log(confirmeSenha.text);
    }

    public void MoveToRegisterScreen()
    {
        painelLogin.SetActive(false);
        painelRegister.SetActive(true);
    }

    public void MoveToLoginScreen()
    {
        painelLogin.SetActive(true);
        painelRegister.SetActive(false);
    }

}

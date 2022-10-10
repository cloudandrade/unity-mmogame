using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log("Login");
        Debug.Log(userNameEmailLogin.text);
        Debug.Log("Senha");
        Debug.Log(senhaLogin.text);
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

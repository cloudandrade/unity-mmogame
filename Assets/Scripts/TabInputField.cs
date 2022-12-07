using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabInputField : MonoBehaviour
{
    //Login Fields
    [SerializeField]
    public TMP_InputField usernameEmail;

    [SerializeField]
    public TMP_InputField passwordInput;

    [SerializeField]
    private Button goToRegisterScreen;

    [SerializeField]
    private Button loginButton;

    //Register Fields
    [SerializeField]
    public TMP_InputField nameRegisterField;

    [SerializeField]
    public TMP_InputField ageRegisterField;

    [SerializeField]
    public TMP_InputField usernameRegisterField;

    [SerializeField]
    public TMP_InputField emailRegisterField;

    [SerializeField]
    public TMP_InputField passwordRegisterField;

    [SerializeField]
    public TMP_InputField confirmPasswordRegisterField;

    [SerializeField]
    private Button registerButton;

    [SerializeField]
    private Button goToLoginScreenButton;

    //screens
    [SerializeField]
    private GameObject LoginScreen;

    [SerializeField]
    private GameObject RegisterScreen;
 
    public int InputSelectedOnLogin;
    public int InputSelectedOnRegister;

   public KeyCode _Key = KeyCode.KeypadEnter;


    // Update is called once per frame
    private void Update()
    {
        //Debug.Log("login input: " + InputSelectedOnLogin + " / register input: " + InputSelectedOnRegister);
        string active = checkActiveScreen();

        if (active == "Login")
        {
            SwipeInputFieldOnLoginScreen();
        }

        if (active == "Register")
        {
            SwipeInputFieldOnRegisterScreen();
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, loginButton.colors.fadeDuration, true, true);
    }

    public string checkActiveScreen()
    {
        //Debug.Log("Login / Register is Active? " + LoginScreen.activeSelf + " / " + RegisterScreen.activeSelf);
        //Debug.Log("Register Active? " + RegisterScreen.activeSelf);
        string screenName = "nenhum";

        if (LoginScreen.activeSelf == true)
        {
            screenName = "Login";
        }

        if (RegisterScreen.activeSelf == true)
        {
            screenName = "Register";
        }
        return screenName;
    }

    //alterna entre os inputs e botões da tela de login com tab e também realiza enter caso esteja no botão
    public void SwipeInputFieldOnLoginScreen()
    {

        //navegar no sentido oposto com tab, ou seja, subindo
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            InputSelectedOnLogin--;
            //caso seja o primeiro input ele volta para o último
            if (InputSelectedOnLogin < 0) InputSelectedOnLogin = 3;
            SelectInputFieldOnLogin();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelectedOnLogin++;
            if (InputSelectedOnLogin > 3) InputSelectedOnLogin = 0;
            SelectInputFieldOnLogin();
        }

        if (InputSelectedOnLogin == 2 && Input.GetKeyDown(_Key))
        {
             FadeToColor(loginButton.colors.pressedColor);
            loginButton.onClick.Invoke();
        }
        else if (InputSelectedOnLogin == 2 && Input.GetKeyUp(_Key))
        {
            FadeToColor(loginButton.colors.normalColor);
        }

        if (InputSelectedOnLogin == 3 && Input.GetKeyDown(_Key))
        {
             FadeToColor(loginButton.colors.pressedColor);
            // informa ao handler que a tela mudou->register screen
            goToRegisterScreen.onClick.Invoke();
        }
    }

    //alterna entre os inputs e botões da tela de registro com tab e também realiza enter caso esteja no botão
    public void SwipeInputFieldOnRegisterScreen()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            InputSelectedOnRegister--;
            if (InputSelectedOnRegister < 0) InputSelectedOnRegister = 7;
            SelectInputFieldOnRegister();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelectedOnRegister++;
            if (InputSelectedOnRegister > 7) InputSelectedOnRegister = 0;
            SelectInputFieldOnRegister();
        }

        if (InputSelectedOnRegister == 6 && Input.GetKeyDown(_Key))
        {
            registerButton.onClick.Invoke();
        }

        if (InputSelectedOnRegister == 7 && Input.GetKeyDown(_Key))
        {
            // informa ao handler que a tela mudou -> login screen
            goToLoginScreenButton.onClick.Invoke();
        }
    }

    //seleciona qual campo deveria estar no foco na tela de login
    void SelectInputFieldOnLogin()
    {
            switch (InputSelectedOnLogin)
            {
                case 0:
                    usernameEmail.Select();
                    break;
                case 1:
                    passwordInput.Select();
                    break;
                case 2:
                    loginButton.Select();
                    break;
                case 3:
                    goToRegisterScreen.Select();
                    break;
            }
    }

    //seleciona qual campo deveria estar no foco na tela de registro
    void SelectInputFieldOnRegister()
    {
        switch (InputSelectedOnRegister)
        {
            case 0:
                nameRegisterField.Select();
                break;
            case 1:
                ageRegisterField.Select();
                break;
            case 2:
                usernameRegisterField.Select();
                break;
            case 3:
                emailRegisterField.Select();
                break;
            case 4:
                passwordRegisterField.Select();
                break;
            case 5:
                confirmPasswordRegisterField.Select();
                break;
            case 6:
                registerButton.Select();
                break;
            case 7:
                goToLoginScreenButton.Select();
                break;
        }
    }

    //campos equivalentes na tela de login
    public void UsernameSelected() => InputSelectedOnLogin = 0;
    public void PasswordSelected() => InputSelectedOnLogin = 1;
    public void LoginButtonSelected() => InputSelectedOnLogin = 2;
    //campos equivalentes na tela de registro
    public void NameRegisterSelected() => InputSelectedOnRegister = 0;
    public void AgeRegisterSelected() => InputSelectedOnRegister = 1;
    public void UsernameRegisterSelected() => InputSelectedOnRegister = 2;
    public void EmailRegisterSelected() => InputSelectedOnRegister = 3;
    public void passwordRegisterSelected() => InputSelectedOnRegister = 4;
    public void confirmPasswordRegisterSelected() => InputSelectedOnRegister = 5;
  
}

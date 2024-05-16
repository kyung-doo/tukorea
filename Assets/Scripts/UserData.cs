using System;

[Serializable]
public class UserData
{
    public string memberSeq;

    public string aday;
    public string bday;
    public string cday;

    public string a1;
    public string a2;
    public string a3;
    public string a4;
    public string a5;
    public string a6;
    public string a7;

    public string b1;
    public string b2;
    public string b3;

    public string c1;
    public string c2;
    public string c3;
    public string c4;
    public string c5;
    public string c6;
}

[Serializable]
public class LoginData
{
    public string result;

    public UserData data; 
    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPopup_Nickname : UIPopup
{

    #region Enums
    private enum Objects
    {
        PopupNicknameScale,
        InputField,
    }
    private enum Buttons
    {
        OKButton,
    }

    #endregion

    #region Fields

    [SerializeField] private TMP_InputField _inputField;
    private string _nickname;

    #endregion
    private void Start()
    {
        Init();
    }
    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons),true);
        BindObject(typeof(Objects),true);

        _inputField = GetObject((int)Objects.InputField).GetComponent<TMP_InputField>();
        AddUIEvent(GetButton((int)Buttons.OKButton).gameObject, OnButtonOK);

        return true;
    }
    private void OnButtonOK(PointerEventData data)
    {
        _nickname = _inputField.text;
        print($"닉네임 : {_nickname}");
        Main.UIManager.Hide(GetObject((int)Objects.PopupNicknameScale).gameObject);
        //TODO : 로비씬으로 넘기기
    }

}

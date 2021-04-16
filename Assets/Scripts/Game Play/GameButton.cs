using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class GameButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text buttonText;

    [SerializeField] PlayerTurn palyerSOturn;
    private GameManger gameManger;

    [SerializeField] UnityEvent ChangeButton;
 


    public void SetButtonLetter()
    {
        buttonText.text = palyerSOturn.turn;
        button.interactable = false;
        ChangeButton.Invoke();
        FindObjectOfType<AudioManager>().playAudio("click");
    }


}

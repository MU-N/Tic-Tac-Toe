using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{

    [SerializeField] private TMP_Text[] buttonList;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text player1;
    [SerializeField] private TMP_Text player2;
    [SerializeField] private TMP_Text playerTurn;

    [SerializeField] GameScore gameSore;
    [SerializeField] PlayerTurn palyerSOTurn;


    private int moveCount;
    private string playerSide;

    void Awake()
    {
        
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        setDfultText();

        palyerSOTurn.turn = GetPlayerSide();

    }

    void setDfultText()
    {
        gameSore.gameScore[0].score = 0;
        gameSore.gameScore[1].score = 0;

        player1.text = $"X Score { gameSore.gameScore[0].score}";
        player2.text = $"O Score { gameSore.gameScore[1].score}";
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;
        if (moveCount >= 9)
        {
            SetGameOverText("GAME\nDRAW!");
            FindObjectOfType<AudioManager>().playAudio("draw"); 
        }
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide ||
            buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide ||
            buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide ||
            buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide ||
            buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide ||
            buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide ||
            buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide ||
            buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        ChangeSides();
        palyerSOTurn.turn = GetPlayerSide();
        playerTurn.text = $"{playerSide} Turn";
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        
    }

    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText(playerSide + "\nWins!");
        updateScore();
        FindObjectOfType<AudioManager>().playAudio("victory");
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }
    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
        palyerSOTurn.turn = GetPlayerSide();
        playerTurn.text = $"{playerSide} Turn";
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void updateScore()
    {
        if (playerSide == "X")
            gameSore.gameScore[0].score += 1;
        else
            gameSore.gameScore[1].score += 1;

        player1.text = $"X Score { gameSore.gameScore[0].score}";
        player2.text = $"O Score { gameSore.gameScore[1].score}";
    }
}

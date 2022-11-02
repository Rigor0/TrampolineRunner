using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    public Player player;
     public TMP_Text coinText;
    public Button restartButton;
    public TMP_Text awesomeText;
    public TMP_Text greatText;
    public TMP_Text perfectText;
    public TMP_Text verywellText;
    public GameObject playerDeadPanel;

    
    void Start()
    {
        DOTween.SetTweensCapacity(1000,1000);  
    }

    
    void Update()
    {
        TextAnimations();
        PlayerDeadPanelActive();
        RestartButtonActive();  
    }

    public void TextAnimations()
    {
        Sequence sequence = DOTween.Sequence();
        switch(player.counter)
        {
            case 2 :
                sequence.Append(awesomeText.transform.DOScale(3, 2).SetEase(Ease.InBounce));
                sequence.Append(awesomeText.transform.DOScale(0, 2)).OnComplete(() => awesomeText.gameObject.SetActive(false));
                break;

            case 9 :
                sequence.Append(greatText.transform.DOScale(3, 2).SetEase(Ease.InBounce));
                sequence.Append(greatText.transform.DOScale(0, 2)).OnComplete(() => greatText.gameObject.SetActive(false));
                break;

            case 13 :
                sequence.Append(perfectText.transform.DOScale(3, 2).SetEase(Ease.InBounce));
                sequence.Append(perfectText.transform.DOScale(0, 2));
                break;

            case 18 :
                sequence.Append(verywellText.transform.DOScale(3, 2).SetEase(Ease.InBounce));
                sequence.Append(verywellText.transform.DOScale(0, 2)).OnComplete(() => verywellText.gameObject.SetActive(false));
                break;

        }
    }

    public void RestartButtonActive()
    {
         
        if(player.isPlayerDead || player.isPlayerBlocked)
        {
            restartButton.gameObject.SetActive(true);
            
        }
    }

    public void PlayerDeadPanelActive()
    {
        if(player.isPlayerDead)
        {
            playerDeadPanel.gameObject.SetActive(true);
        }
    }

    public void DeactiveAnimatedTexts()
    {
        if(player.isPlayerDead || player.isPlayerBlocked)
        {
            awesomeText.gameObject.SetActive(false);
            greatText.gameObject.SetActive(false);
            verywellText.gameObject.SetActive(false);
            perfectText.gameObject.SetActive(false);

        }
    }  
}

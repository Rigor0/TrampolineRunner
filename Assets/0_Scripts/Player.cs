using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    public Transform cameraTrans;

    private bool isStylish;
    public bool isJumping;
    public bool isPlayerDead;
    private bool jumpUp;
    public bool isPlayerBlocked;

    [Header("Portal")]
    public Material mat1;
    public Material mat2;
    [Space(20f)]


    Animator myAnim;
    Rigidbody myRigidbody;
    
    public int counter = 0;
    private int coinCounter = 0;
   
    [Header ("Movement")]
    public float leftRightSpeed;
    public float extraForce;
    public float extraForward;
    public float upSpeedy;
    public float upSpeedz;
    [Space(20f)]

    [Header ("Sounds")]
    public AudioSource jumpAudio;
    public AudioSource waterAudio;
    public AudioSource blockAudio;

    void Start()
    {
        DOTween.Init();
        myRigidbody = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();

    }

    void Update()
    {
        Jump();
        StylishFlip();
        Movement();
        PlayerDead();	
	}

    public void FixedUpdate()
    {
        Reset();
    }


    public void PlayerDead()
	{
		if (this.transform.position.y <= -3.4f)
		{
            isPlayerDead = true;
            Time.timeScale = 0;
            waterAudio.Play(); 
        }
	}

   
    void Movement()
	{
		if (MobileInput.Instance.SwipeLeft)
		{
            this.transform.DOMoveX(-2, 1);
            
        }
		if (MobileInput.Instance.SwipeRight)
		{
            this.transform.DOMoveX(8, 1);
        }	
	}

    public void OnTriggerEnter(Collider collider)
	{
        if (collider.gameObject.CompareTag("Coin"))
        {
            

            Destroy(collider.gameObject);
            coinCounter = coinCounter + 1;
            //coinText.text = coinCounter.ToString();
            GameDataManager.AddCoins(1);
        }
        else if (collider.gameObject.CompareTag("Portal"))
        {
            RenderSettings.skybox = mat2;
        }

		else if (collider.gameObject.CompareTag("Portal2"))
		{
            RenderSettings.skybox = mat1;
        }

		else if (collider.gameObject.CompareTag("Tramp"))
		{
            isJumping = true;
            myRigidbody.velocity = new Vector3(0, upSpeedy, upSpeedz);
            jumpAudio.Play();
            myAnim.SetBool("stylishFlip", false);
        }

		else if (collider.gameObject.CompareTag("TrampUp"))
		{
            isStylish = true;
            myRigidbody.velocity = new Vector3(0, extraForce, extraForward);
            jumpAudio.Play();
        }
        if(collider.gameObject.CompareTag("Block"))
        {
            isPlayerBlocked = true;
            Time.timeScale = 1;
            myAnim.SetTrigger("block");
            myRigidbody.AddForce(0, 0, -100);
            

        }
       
    }

	void Jump()
	{
		if (isJumping)
		{
            
            myAnim.SetBool("jump", true);
            
            
            counter += 1;
            isJumping = false;

        }
    }

    void StylishFlip()
	{
		if (isStylish)
		{
            
            myAnim.SetBool("stylishFlip", true);
            Sequence mySeq = DOTween.Sequence();
            mySeq.Append(cameraTrans.DOMoveY(13, 1));
            mySeq.Join(cameraTrans.DOMoveX(13, 1));
            mySeq.Join(cameraTrans.DORotate(new Vector3(0, -50, 0), 1, RotateMode.Fast)).OnComplete(() => DOTween.RewindAll());
            isStylish = false;
        }
	}

	void Reset()
	{
		isJumping = false;
        
		myAnim.SetBool("jump", false);
		
	}
}

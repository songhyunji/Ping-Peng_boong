﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class UiController : UIScript
{
    public GameObject inGame;
    public GameObject pausePopup;

    int order = 0;
    public GameObject[] parfaitOrder;
    public GameObject[] parfaitOrder_done;

    public GameObject mission_default;
    public GameObject mission_parfait;

    public StageSceneResultPopup stageSceneResultPopup;
    public CustomsSceneResultPopup customSceneResultPopup;
    public EditorSceneResultPopup editorSceneResultPopup;

	public Button nextLevelBtn;
    
    public Text devtext;
    public Text remainText;
    public Text moveText;

    bool mini = false;

    public Button player1;
    public Button player2;

    public Sprite player1_off_image;
    public Sprite player2_off_image;
    public Sprite player1_on_image;
    public Sprite player2_on_image;


    private void Awake()
    {
        devtext.text = "platform : " + Application.platform + "\n" + "level : " + PlayerPrefs.GetInt("level", 0);
       
    }

    public void GameEnd(int moveCount,bool custom , bool editor)
    {
        inGame.SetActive(false);
        //SetMoveCountText(moveCount);

        //infinite --> 종료 팝업 선택 버튼 : 다음 맵 / 로비로?
        //editor --> 종료 팝업 선택 버튼 : 생성할지 말지
        //Default --> 종료 팝업 선택 버튼 : 다음 스테이지 / 로비로
        if (custom)
        {
            customSceneResultPopup.ShowResultPopup(moveCount);
        }
        else if(editor)
        {
            int level = (moveCount / 5) + 1;
            if (level > 5) level = 5;

            

            editorSceneResultPopup.ShowResultPopup(moveCount, level);
        }
        else
        {
            stageSceneResultPopup.ShowResultPopup(moveCount);
        }
       
    }

    #region 인게임 UI
    public void SetRemainText(int remain, int total)//inGame UI
    {
        remainText.text = remain + "/" + total;
    }
    public void ParfaitDone()
    {
        parfaitOrder[order].SetActive(false);
        parfaitOrder_done[order].SetActive(true);
        order++;
    }
    
    #endregion

    #region 결과 창 UI
    public void SetMoveCountText(int count)//Result UI
    {
        moveText.text = count.ToString();
    }
    public void Pause()
    {
        GameController.instance.SetPlaying(false);
        pausePopup.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoLobby()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Resume()
    {
        GameController.instance.SetPlaying(true);
        pausePopup.SetActive(false);
    }
    #endregion


    public void MiniMapButton()
    {
        mini = GameController.instance.cameraController.MiniMapView(mini);
        GameController.instance.SetPlaying(!mini);
    }

    public void ReturnButton()
    {
		GameController.instance.moveCommand.Undo();
    }


    public void ChangeCharacter(Player player)
    {
        GameController instance = GameController.instance;

        Player now = instance.nowPlayer;

        if(!now.Moving())
        {
            now.isActive = false;
            instance.nowPlayer = player;
            player.isActive = true;

            if(player == GameController.instance.player1)
            {
                player1.interactable = false;
                player1.image.sprite = player1_on_image;

                player2.interactable = true;
                player2.image.sprite = player2_off_image;
            }
            else
            {
                player1.interactable = true;
                player1.image.sprite = player1_off_image;

                player2.interactable = false;
                player2.image.sprite = player2_on_image;
            }
            
        }

		if (!now.Moving())
		{
//			Debug.Log("change Character");
			now.isActive = false;

            instance.nowPlayer = (now == instance.player1) ? instance.player2 : instance.player1;
			instance.nowPlayer.isActive = true;

			if (!instance.nowPlayer.GetComponent<AudioSource>().isPlaying)
			{
				instance.nowPlayer.GetComponent<AudioSource>().loop = false;
				instance.nowPlayer.GetComponent<AudioSource>().clip = instance.nowPlayer.GetComponent<Player>().departureSound;

				instance.nowPlayer.GetComponent<AudioSource>().Play();
			}

			
		}
		else
		{
			Debug.Log("Can't change!");
		}
        
    }
    public void MasterFocus(Player master)
    {
        GameController.instance.nowPlayer = master;
        GameController.instance.nowPlayer.isActive = true;
        Debug.Log("master : " + master.name);
    }
    public void NextLevel()
    {
        //GameController googleinstance level++....
        if(GameController.instance.customMode)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            Load_Island(GameManager.instance.nowLevel);
        
    }

   


    
}

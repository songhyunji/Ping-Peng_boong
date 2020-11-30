﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedBlock : Block
{
    public int count;
    public int x;
    public int z;

    public Material transparentMaterial;
    

    public MeshRenderer[] crackerRenderer;
    public MeshFilter[] crackerMesh;
    public Mesh cracker2;
    public Mesh cracker3;


    public override void Init(int block_num, bool snow)
    {
        base.Init(block_num, snow);
        x = (int)transform.position.x;
        z = (int)transform.position.z;
        count = 0;

        if(block_num == BlockNumber.broken)
        {
            count = 3;
            //is not cracker block
            for (int i = 0; i < crackerRenderer.Length; i++)
            {
                crackerRenderer[i].material = transparentMaterial;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Debug.Log("stay");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            count++;
            Debug.Log("through the cracked block :" + count);
            if(count == 1)
            {
                for(int i = 0; i < crackerMesh.Length; i++)
                {
                    
                        crackerMesh[i].mesh = cracker2;
                }
                //crackerMesh[4].mesh = cracker2;
            }
            else if(count == 2)
            {
                /*for (int i = 0; i < crackerMesh.Length; i++)
                {
                    
                        crackerMesh[i].mesh = cracker3;
                }*/
                crackerMesh[4].mesh = cracker3;
            }
            else if(count == 3)
            {
                Debug.Log(Data);
                if(BlockNumber.cracked == Data)
                {
                    Data = BlockNumber.broken;    
                }
                else if(BlockNumber.upperCracked == Data)
                {
                    Data = BlockNumber.upperBroken;
                }

                for(int i = 0; i < crackerRenderer.Length; i++)
                {
                    crackerRenderer[i].material = transparentMaterial;
                }
            }
            
        }
    }

}
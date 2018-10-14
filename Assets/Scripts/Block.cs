using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] Sprite[] hitSprites;

    // cache level
    Level level;
    GameSession gameStatus;

    // state params
    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks();

        gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from the array. Game object missing: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayDestroySFX();
        Destroy(gameObject);
        gameStatus.AddToScore();
        level.BlockDestroyed();
        TriggerSparkleVFX();
        
    }

    private void PlayDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

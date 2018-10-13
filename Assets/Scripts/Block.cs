using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;
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
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            int spriteIndex = timesHit - 1;
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakClip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession gameStatus;
    int maxHits;

    //state variables
    [SerializeField] int timesHit; //TODO only serialized for debug purposes

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        maxHits = hitSprites.Length + 1;
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
            level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
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
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
        {
            Debug.LogError("error: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakClip, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        gameStatus.IncreaseScore();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkle = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkle, 2f);
    }
}

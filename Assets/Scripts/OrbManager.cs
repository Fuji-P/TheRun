using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrbManager : MonoBehaviour
{
    private const int ORB_POINT = 100;      // オーブの特典
    private GameObject gameManager;         // ゲームマネージャー

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // オーブ入手処理
    public void GetOrb()
    {
        gameManager.GetComponent<GameManager>().AddScore(ORB_POINT);

        // コライダーを削除
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        Destroy(circleCollider);

        // 消失アニメーション
        transform.DOScale(2.5f, 0.3f);
        SpriteRenderer spriteRenderer = transform.GetComponent<SpriteRenderer>();
        DOTween.ToAlpha(() => spriteRenderer.color, a => spriteRenderer.color = a, 0.0f, 0.3f);

        Destroy(this.gameObject, 0.5f);
	}
}

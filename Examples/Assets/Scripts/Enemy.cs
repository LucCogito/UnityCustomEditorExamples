using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private float moveSpeed;

    public EnemyType EnemyType => enemyType;

    public void UpdateVisualsAccordingToType() => GetComponent<SpriteRenderer>().sprite = enemyData.EnemyVisuals.First(visual => visual.EnemyType == enemyType).Shape;
}

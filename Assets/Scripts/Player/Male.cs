using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male : Entity
{
    [SerializeField] private Player player;

    private Seeker seeker;
    private List<Vector3> pathPointList;
    private int currentIndex = 0;
    private float pathGenerateInterval = 0.5f;
    private float pathGenerateTimer = 0f;

    protected override void Awake()
    {
        base.Awake();
        seeker = GetComponentInChildren<Seeker>();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (player == null)
            return;

        float distance = Vector2.Distance(player.transform.position, transform.position);

        if(distance > 2)
        {
            AutoPath();

            if (pathPointList == null)
                return;

            Vector2 dir = (pathPointList[currentIndex] - transform.position).normalized;
            animator.SetBool("Move", true);
            animator.SetBool("Idle", false);
            SetVelocity(dir.x * moveSpeed, dir.y * moveSpeed);
        }
        else
        {
            animator.SetBool("Move", false);
            animator.SetBool("Idle", true);
            rb.velocity = Vector2.zero;
        }



    }

    //自动寻路
    private void AutoPath()
    {
        if (player == null)
            return;

        pathGenerateTimer += Time.deltaTime;

        if(pathGenerateTimer >=  pathGenerateInterval)
        {
            GeneratePath(player.transform.position);
            pathGenerateTimer = 0f;
        }

        if(pathPointList == null || pathPointList.Count <=0 || pathPointList.Count <= currentIndex)
        {
            GeneratePath(player.transform.position);
        }
        else if(currentIndex < pathPointList.Count)
        {
            if (Vector2.Distance(transform.position, pathPointList[currentIndex]) <= 0.1f)
            {
                currentIndex++;
                if (currentIndex >= pathPointList.Count)
                {
                    GeneratePath(player.transform.position);
                }
            }
        }
    }


    //获取路径点
    private void GeneratePath(Vector3 target)
    {
        currentIndex = 0;

        seeker.StartPath(transform.position, target, Path =>
        {
            pathPointList = Path.vectorPath;
        });
    }

}

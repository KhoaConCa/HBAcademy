using Sirenix.OdinInspector;
using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

public class TestDOD : MonoBehaviour
{
    public int Amount = 1000;
    public int Loop = 1000;

    [Button]
    public void OOPTest()
    {
        var enemies = new Enemy[Amount];

        for (int i = 0; i < Amount; i++)
        {
            enemies[i] = new Enemy();
        }

        using (var timer = new TaskTimer("OOP Test"))
        {
            for (int i = 0; i < Loop; i++)
            {
                for (int j = 0; j < Amount; j++)
                {
                    enemies[j].Move();
                }
            }
        }
    }

    [Button]
    public void DODTest()
    {
        var enemies = new EnemyStack(Amount);

        using (var timer = new TaskTimer("DOD Test"))
        {
            for (int i = 0; i < Loop; i++)
            {
                for (int j = 0; j < Amount; j++)
                {
                    enemies.X[j] += enemies.Speed[j];
                    enemies.Y[j] += enemies.Speed[j];
                }
            }
        }
    }

    [Button]
    public void BurstTest()
    {
        var enemies = new NativeEnemyStack(Amount);

        using (var timer = new TaskTimer("Jobs/Burst Test"))
        {
            new EnemyJob()
            {
                Loop = Loop,
                Enemy = enemies
            }.ScheduleParallel(Amount, 256, default).Complete();
        }

        enemies.Dispose();
    }

    [Button]
    public void UnsafeTest()
    {
        var enemies = new NativeEnemyStack(Amount);

        using (var timer = new TaskTimer("Jobs/Burst + Unsafe Test"))
        {
            unsafe
            {
                new EnemyJobUnsafe()
                {
                    Loop = Loop,
                    X = (int*)enemies.X.GetUnsafePtr(),
                    Y = (int*)enemies.Y.GetUnsafePtr(),
                    Speed = (int*)enemies.Speed.GetUnsafePtr(),
                }.ScheduleParallel(Amount, 256, default).Complete();
            }
        }

        enemies.Dispose();
    }
}

public class Enemy
{
    public int X, Y, Speed;

    public void Move()
    {
        X += Speed;
        Y += Speed;
    }
}

public class EnemyStack
{
    public int[] X, Y, Speed;

    public EnemyStack(int amount)
    {
        X = new int[amount];
        Y = new int[amount];
        Speed = new int[amount];
    }
}

public struct NativeEnemyStack : IDisposable
{
    public NativeArray<int> X, Y, Speed;

    public NativeEnemyStack(int amount)
    {
        X = new NativeArray<int>(amount, Allocator.TempJob);
        Y = new NativeArray<int>(amount, Allocator.TempJob);
        Speed = new NativeArray<int>(amount, Allocator.TempJob);
    }

    public void Dispose()
    {
        X.Dispose();
        Y.Dispose();
        Speed.Dispose();
    }
}

[BurstCompile]
public struct EnemyJob : IJobFor
{
    public int Loop;
    public NativeEnemyStack Enemy;

    public void Execute(int j)
    {
        for (int i = 0; i < Loop; i++)
        {
            Enemy.X[j] += Enemy.Speed[j];
            Enemy.Y[j] += Enemy.Speed[j];
        }
    }
}

[BurstCompile]
public unsafe struct EnemyJobUnsafe : IJobFor
{
    public int Loop;

    [NativeDisableUnsafePtrRestriction] public int* X;
    [NativeDisableUnsafePtrRestriction] public int* Y;
    [NativeDisableUnsafePtrRestriction] public int* Speed;

    public void Execute(int j)
    {
        var x = X[j];
        var y = Y[j];
        var s = Speed[j];

        for (int i = 0; i < Loop; i++)
        {
            x += s;
            y += s;
        }

        X[j] = x;
        Y[j] = y;
    }
}
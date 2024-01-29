using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DifficultyObj : MonoBehaviour
{
    [SerializeField] private DifficultyComponents<GameObject> _difficultyComponents;
    protected DifficultyPartConfig<GameObject> _currentPart;
    private Action<DifficultyType> ChangeObjDifficulty;

    protected virtual void Awake()
    {
        _currentPart = _difficultyComponents.GetDifficultyPart(DifficultyType.Hard);
        ChangeObjDifficulty = _difficultyType => ChangeDifficulty(_difficultyType);
        DifficultyManager.Instance.ChangeDifficulty += ChangeObjDifficulty;
    }

    public virtual void ChangeDifficulty(DifficultyType _difficultyType)
    {
        _currentPart.difficultyPart.SetActive(false);
        _currentPart = _difficultyComponents.GetDifficultyPart(_difficultyType);
        _currentPart.difficultyPart.SetActive(true);
    }

    protected virtual void OnDestroy()
    {
        DifficultyManager.Instance.ChangeDifficulty -= ChangeObjDifficulty;
    }
}

[Serializable]
public class DifficultyComponents<T>
{
    public DifficultyPartConfig<T>[] difficultyParts;

    public DifficultyPartConfig<T> GetDifficultyPart(DifficultyType _difficultyType)
    {
        foreach (var _part in difficultyParts)
        {
            if (_part.difficultyType == _difficultyType) return _part;
        }
        throw new ArgumentNullException("DifficultyPartConfig with DifficultyType " + _difficultyType + " doesn't exist!");
    }
}


[Serializable]
public class DifficultyPartConfig<T>
{
    public T difficultyPart;
    public DifficultyType difficultyType;
}

public enum DifficultyType
{
    Hard,
    Medium,
    Easy
}

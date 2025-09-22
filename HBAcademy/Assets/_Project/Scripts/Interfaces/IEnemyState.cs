using Vox.Features.Enemy;


namespace Vox.Ultilities.StateMachine.HB
{
    /// <summary>
    /// IEnemyState - Interface for enemy states.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public interface IEnemyState
    {
        void OnEnter(EnemyController enemy);
        void OnExecute(EnemyController enemy);
        void OnExit(EnemyController enemy);
    }
}
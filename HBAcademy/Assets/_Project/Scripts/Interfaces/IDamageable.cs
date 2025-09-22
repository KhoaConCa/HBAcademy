namespace Vox.Features.Character
{
    /// <summary>
    /// IDamageable - Interface for entities that can take damage and die.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public interface IDamageable
    {
        void TakeDamage(float damage);
        void Die();
    }
}

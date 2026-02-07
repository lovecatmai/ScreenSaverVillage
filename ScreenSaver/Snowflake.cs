/// <summary>
/// Структура, представляющая собой одну снежинку.
/// </summary>
public struct Snowflake
{
    private const int minSpeed = 1;
    private const int maxSpeed = 2;
    private const int midSize = 20;

    /// <summary>
    /// Координата X снежинки на экране.
    /// </summary>
    public int X;

    /// <summary>
    /// Координата Y снежинки на экране.
    /// </summary>
    public int Y;

    /// <summary>
    /// Размер снежинки, влияющий на её физический масштаб и скорость падения.
    /// </summary>
    public int Size;

    /// <summary>
    /// Вычисляемое свойство, определяющее вертикальную скорость падения снежинки.
    /// Чем больше размер, тем быстрее падает (эффект параллакса).
    /// </summary>
    public int Speed => Size <= midSize ? minSpeed : maxSpeed;
}
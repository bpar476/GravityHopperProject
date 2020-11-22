public class MusicManager : Singleton<MusicManager>
{
    // Currently does nothing but should be singleton when introducing scene changes
    protected override MusicManager Init()
    {
        return this;
    }
}

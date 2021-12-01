public enum VisibilityLevel
{
    Hidden, Collapsed, Visible
}
public static class IVisibilityEnum
{
    public static string GetString(this VisibilityLevel me)
    {
        switch (me)
        {
            case VisibilityLevel.Hidden:
                return "Hidden";
            case VisibilityLevel.Collapsed:
                return "Collapsed";
            case VisibilityLevel.Visible:
                return "Visible";
            default:
                return "NO VALUE GIVEN";
        }
    }
}
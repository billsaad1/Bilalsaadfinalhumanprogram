using HumanitarianProjectManagement.Models; // Assuming User model is in this namespace

namespace HumanitarianProjectManagement
{
    public static class ApplicationState
    {
        public static User CurrentUser { get; set; }
    }
}

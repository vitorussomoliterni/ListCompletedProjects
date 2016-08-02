using System;

namespace ListCompletedProjects
{
    internal static class ConnectionDetails
    {
        public static string ConnectionString = "Server=squid;Uid=pm;Password=pm";
        public static string ProjectsTable = "intranet.projects_project";
        public static string UserProfilesTable = "intranet.users_userprofile";
        public static string UsersTable = "intranet.auth_user";
        public static string LogPath = @"F:\Programs\Vito\logs\Completed Projects On P Drive (" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now) + ").csv";
    }
}
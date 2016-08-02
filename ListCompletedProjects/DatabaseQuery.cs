using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ListCompletedProjects
{
    public class DatabaseQuery
    {
        public static string GetStatus(string projectNo)
        {
            string connStr = ConnectionDetails.ConnectionString;

            try
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var getStatus = "SELECT status_id FROM " + ConnectionDetails.ProjectsTable + " WHERE number = " + projectNo + ";";
                    MySqlCommand getStatusCmd = new MySqlCommand(getStatus, con);
                    var status = getStatusCmd.ExecuteScalar().ToString();

                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL error: {0}", ex.Message);
            }
            return null;
        }

        public static string GetTeamLeaderName(string projectNo)
        {
            string connStr = ConnectionDetails.ConnectionString;

            try
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var getLeaderId = "SELECT team_leader_id FROM " + ConnectionDetails.ProjectsTable + " WHERE number = " + projectNo + ";";
                    MySqlCommand getLeaderIdCmd = new MySqlCommand(getLeaderId, con);
                    var leaderId = getLeaderIdCmd.ExecuteScalar().ToString();

                    var getUserId = "SELECT user_id FROM " + ConnectionDetails.UserProfilesTable + " WHERE id = " + leaderId + ";";
                    MySqlCommand getUserIdCmd = new MySqlCommand(getUserId, con);
                    var userId = getUserIdCmd.ExecuteScalar().ToString();

                    var getLeaderLastName = "SELECT last_name FROM " + ConnectionDetails.UsersTable + " WHERE id = " + userId + ";";
                    MySqlCommand getLeaderLastNameCmd = new MySqlCommand(getLeaderLastName, con);
                    var leaderLastName = getLeaderLastNameCmd.ExecuteScalar().ToString();

                    var getLeaderPhoneNumber = "SELECT phone_number FROM " + ConnectionDetails.UserProfilesTable + " WHERE user_id = " + userId + ";";
                    MySqlCommand getLeaderPhoneNumberCmd = new MySqlCommand(getLeaderPhoneNumber, con);
                    var leaderPhoneNumber = getLeaderPhoneNumberCmd.ExecuteScalar().ToString();

                    return leaderLastName + "," + leaderPhoneNumber;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL error: {0}", ex.Message);
                return "None,None";
            }
        }

        public static string GetDirectorName(string projectNo)
        {
            string connStr = ConnectionDetails.ConnectionString;

            try
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var getDirectorId = "SELECT director_id FROM " + ConnectionDetails.ProjectsTable + " WHERE number = " + projectNo + ";";
                    MySqlCommand getDirectorIdCmd = new MySqlCommand(getDirectorId, con);
                    var directorId = getDirectorIdCmd.ExecuteScalar().ToString();

                    var getUserId = "SELECT user_id FROM " + ConnectionDetails.UserProfilesTable + " WHERE id = " + directorId + ";";
                    var getUserIdCmd = new MySqlCommand(getUserId, con);
                    var userId = getUserIdCmd.ExecuteScalar().ToString();

                    var getDirectorLastName = "SELECT last_name FROM " + ConnectionDetails.UsersTable + " WHERE id = " + userId + ";";
                    MySqlCommand getDirectorLastNameCmd = new MySqlCommand(getDirectorLastName, con);
                    var directorLastName = getDirectorLastNameCmd.ExecuteScalar().ToString();

                    var getDirectorPhoneNumber = "SELECT phone_number FROM " + ConnectionDetails.UserProfilesTable + " WHERE user_id = " + userId + ";";
                    MySqlCommand getDirectorPhoneNumberCmd = new MySqlCommand(getDirectorPhoneNumber, con);
                    var directorPhoneNumber = getDirectorPhoneNumberCmd.ExecuteScalar().ToString();

                    return directorLastName + "," + directorPhoneNumber;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL error: {0}", ex.Message);
                return "None,None";
            }
        }
    }
}
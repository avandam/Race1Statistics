using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Dal
{
    public static class ConnetionSettings
    {
        public static string SshServerName = "";
        public static string SshUsername = "";
        public static string sshPassword = "";

        public static string DatabaseServer = "";
        public static string DatabaseName = "";
        public static string DatabaseUser = "";
        public static string DatabasePassword = "";
        public static bool DatabaseAllowBatch = true;
    }
}

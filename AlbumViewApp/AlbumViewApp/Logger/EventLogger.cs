using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AlbumViewApp.Logger
{
    public class EventLogger
    {
        public static void LogError(string serviceName, string message, EventLogEntryType eventType)
        {
            if (!EventLog.SourceExists("AlbumViewApp"))
            {
                EventLog.CreateEventSource("AlbumViewApp", "AlbumViewApp");
            }

            EventLog.WriteEntry("AlbumViewApp", message, eventType);
        }
    }

}
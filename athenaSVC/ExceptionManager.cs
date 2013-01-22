using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace athena.AR.SVC
{
  public  class ExceptionManager
    {

      internal static void LoggerAsync(Exception ex)
      {
          //Record Error to file
          try
          {
              System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    using (System.IO.TextWriter writer = new StreamWriter(@"c:\athena\error.txt", true))
                    {
                        writer.WriteLine();
                        writer.WriteLine(DateTime.Now);
                        writer.WriteLine(ex);


                    }
                });
          }
          catch (Exception) { }

         //Write to Event Viewer
          try
          {
              if (!EventLog.SourceExists("athenSVC"))
                  EventLog.CreateEventSource("athenSVC", "athenSVCLog");

              EventLog.WriteEntry("athenSVC", ex.ToString(), EventLogEntryType.Error);
          }
          catch (Exception) { }
              
      }

    }
}

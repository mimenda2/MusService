using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MusWinService
{
    public class SizeTraceListener : TextWriterTraceListener
    {
        string logFileDefaultLocation = "";
        StreamWriter traceWriter;
        long curLogLen = 0; // selected log file length, in bytes
        const int maxNumberFileLogs = 5; //maximum number of log files
        const long maxSize = 262144; //Max log file size in bytes
        const long limitSize = maxSize - (maxSize / 10); // limit size to change log on startup maxSize

        #region Contructor & dispose
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">File name defined in config file</param>
        public SizeTraceListener(string fileName)
        {
            if (string.IsNullOrEmpty(Path.GetDirectoryName(fileName)))
                fileName = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), fileName);
            logFileDefaultLocation = fileName;

            string logFileName = GenerateFileName(limitSize);

            // if use an exist file read its length
            if (File.Exists(logFileName))
                curLogLen = new FileInfo(logFileName).Length;

            traceWriter = new StreamWriter(logFileName, true);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                traceWriter.Close();
        }

        #endregion

        #region Override methods
        public override void Write(string message)
        {
            if (message != null)
                curLogLen += message.Length;
            CheckLogSize();
            traceWriter.Write(message);
            traceWriter.Flush();
        }

        public override void Write(string message, string category)
        {
            string msg = $"{ category}: {message}";
            curLogLen += msg.Length;
            CheckLogSize();
            traceWriter.Write(msg);
            traceWriter.Flush();
        }


        public override void WriteLine(string message)
        {
            if (message != null)
                curLogLen += (message.Length + Environment.NewLine.Length);
            CheckLogSize();
            traceWriter.WriteLine(message);
            traceWriter.Flush();
        }

        public override void WriteLine(string message, string category)
        {
            string msg = $"{category}: {message}";
            curLogLen += (msg.Length + Environment.NewLine.Length);
            CheckLogSize();
            traceWriter.WriteLine(msg);
            traceWriter.Flush();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Get log file name
        /// Can have maxNumberFileLogs files, if all files are used, select the first file
        /// </summary>
        /// <param name="limit">limit used to check the file size</param>
        /// <returns>log file name (full path)</returns>
        private string GenerateFileName(long limit)
        {
            string logFileWithouExtension = Path.Combine(Path.GetDirectoryName(logFileDefaultLocation), Path.GetFileNameWithoutExtension(logFileDefaultLocation));
            string extension = Path.GetExtension(logFileDefaultLocation);
            string logFile = $"{logFileWithouExtension}{extension}";
            List<FileInfo> logFiles = new List<FileInfo>();
            if (File.Exists(logFile))
            {
                FileInfo f = new FileInfo(logFile);
                logFiles.Add(f);
                if (f.Length > limit)
                {
                    logFile = "";
                    for (int i = 1; i < maxNumberFileLogs; i++)
                    {
                        string file = $"{logFileWithouExtension}_{i}{extension}";
                        if (File.Exists(file))
                        {
                            f = new FileInfo(file);
                            if (f.Length > limit)
                            {
                                logFiles.Add(f);
                                continue;
                            }
                        }
                        logFile = file;
                        break;
                    }
                    if (string.IsNullOrEmpty(logFile))
                    {
                        // Select older file
                        logFile = logFiles.First(x => x.LastWriteTime == logFiles.Min(y => y.LastWriteTime)).FullName;
                    }
                }
            }
            return logFile;
        }
        /// <summary>
        /// Check log limit size
        /// </summary>
        private void CheckLogSize()
        {
            if (curLogLen > maxSize) // if it is greater, change the log file
            {
                curLogLen = 0;
                traceWriter.Close();
                string logFile = GenerateFileName(maxSize);
                traceWriter = new StreamWriter(logFile, false);
            }
        }
        #endregion
    }
}

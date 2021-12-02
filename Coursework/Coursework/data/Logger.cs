using Coursework.business;
using System;
using System.IO;
using System.Text;

namespace Coursework.data
{
    /// <summary>
    /// <para>Sealed class representing a logger</para>
    /// <para>Design pattern: Singleton and Observer</para>
    /// <para>Base class: Observer</para>
    /// </summary>
    public sealed class Logger : Observer
    {

        private static Logger _instance;    //Static object instance (Singleton)

        private Subject _subject;   //Subject to be observed (Observer)
            
        private StringBuilder _sessionActions; //Data structure for logging file

        private FileInfo _logPath;  //File path to logging file

        /// <summary>
        /// <para>Private base constructor (Singleton)</para>
        /// <para>Defines attributes</para>
        /// <para>Checks if log file texts otherwise creates it</para>
        /// <para>Loads previous logs</para>
        /// </summary>
        private Logger()
        {
            if (!File.Exists("log.txt"))
            {
                File.Create("log.txt").Close(); //Since FileCreate opens up a stream, it needs to be closed afterwards
            }

            _logPath = new FileInfo("log.txt");
            _sessionActions = new StringBuilder();
            Load();
        }

        /// <summary>
        /// <para>Private constructor (Observer) used for instantiating with a subject</para>
        /// </summary>
        /// <param name="subject"></param>
        private Logger(Subject subject) : this()
        {
            _subject = subject;
        }

        /// <summary>
        /// <para>GetInstance method (Singleton not thread safe)</para>
        /// <para>Controls instantiation</para>
        /// </summary>
        /// <param name="subject">Subject to be observed (Observer)</param>
        /// <returns>Single Logger instance</returns>
        public static Logger GetInstance(Subject subject)
        {
            if (_instance is null)
            {
                _instance = new Logger(subject);
            }
            return _instance;
        }

        /// <summary>
        /// <para>Adds an entry to the StringBuilder</para>
        /// </summary>
        /// <param name="action">String describing the action to be recorded</param>
        public void AddEntry(string action)
        {
            _sessionActions.AppendLine($"{DateTime.Now}: {action}");
        }

        /// <summary>
        /// <para>Writes all lines from StringBuilder into log file</para>
        /// </summary>
        private void Save()
        {
            File.WriteAllText(_logPath.FullName,_sessionActions.ToString());
        }

        /// <summary>
        /// <para>Method which handles notifications from the observered subject (Observer)</para>
        /// <para>Calls the Save method</para>
        /// </summary>
        public override void Update()
        {
            Save();
        }

        /// <summary>
        /// <para>Reads all log entries from log file and stores in StringBuilder</para>
        /// </summary>
        private void Load()
        {
            using (StreamReader reader = new StreamReader(_logPath.FullName))
            {
                while (!reader.EndOfStream)
                {
                    _sessionActions.AppendLine(reader.ReadLine());
                }
            }
        }
    }
}

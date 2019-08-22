﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonocleUI.lib
{
    class FileProcessor
    {
        FileWriter Writer;

        public Files files { get; set; } = new Files();

        /// <summary>
        /// Listener pair to track processing progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void FileEventHandler(Object sender, FileEventArgs e);
        public class FileEventArgs : EventArgs
        {
            public string FilePath;
            public FileEventArgs(string filePath) { FilePath = filePath; }
        }

        public FileProcessor()
        {
            Writer = new FileWriter();
        }

        public void Run(string newFile = "C:\\Users\\thom700\\Downloads\\g05432_tko_std_comet.mzXML")
        {
            List<Scan> scans = new List<Scan>();
            MZXML.ReadXml(newFile, ref scans);
            foreach(Scan scan in scans)
            {
                scan.Dispose();
            }
            scans.Clear();
            GC.Collect();
        }
    }
}

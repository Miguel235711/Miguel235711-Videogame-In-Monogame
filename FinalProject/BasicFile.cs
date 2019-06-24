using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    class BasicFile
    {
        string filename;
        public BasicFile (string filename){
            this.filename = filename;
            
        }
        public void SetLevel(int content)
        {
            File.WriteAllText(filename, content.ToString());
        }
        public int GetLevel()
        {
            string content = File.ReadAllText(filename, Encoding.UTF8);
            return Int32.Parse(content);
        }
    }
}

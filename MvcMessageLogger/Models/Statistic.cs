using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcMessageLogger.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public string Content { get; set; }
        

        public Statistic()
        {

            Content = string.Empty;
            
        }

        public Statistic(string content)
        {
            Content = content;
            ;
        }
    }
}
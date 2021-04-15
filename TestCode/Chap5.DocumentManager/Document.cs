using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.DocumentManager
{
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }
    public class Document:IDocument
    {
        public Document()
        {

        }
        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
    }
}

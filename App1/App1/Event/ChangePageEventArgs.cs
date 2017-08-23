using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Enums;
namespace App1.Event
{
    public class ChangePageEventArgs : EventArgs
    {
        public PageKind NextPage { get; set; }
        public ChangePageEventArgs(PageKind page)
        {
            NextPage = page;
        }
    }
}

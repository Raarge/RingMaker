using System;
using System.Collections.Generic;
using System.Text;

namespace RingMaker.Interfaces
{
    public interface IClipboardService
    {
        void CopyToClipboard(string text);
    }
}

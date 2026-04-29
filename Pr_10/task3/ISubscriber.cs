using System;
using System.Collections.Generic;
using System.Text;
interface ISubscriber
{
    void Update(string channelName, string videoTitle);
}
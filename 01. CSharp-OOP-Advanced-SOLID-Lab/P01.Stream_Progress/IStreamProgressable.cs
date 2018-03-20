using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface IStreamProgressable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}

using KataBankOCR.Models;
using System.Collections.Generic;

namespace KataBankOCR.RecordReaders
{
    public interface IRecordReader
    {
        List<Record> Read(string filePath);
    }
}
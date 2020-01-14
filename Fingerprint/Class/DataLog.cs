using System;

namespace Fingerprint.Class
{
    internal class DataLog
    {
        public string id { get; set; }
        public string nip { get; set; }
        public string nama { get; set; }
        public DateTime tanggal { get; set; }
        public TimeSpan waktu { get; set; }
        public string jenis { get; set; }
    }
}
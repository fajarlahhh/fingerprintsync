using System;

namespace Fingerprint.Class
{
    internal class RekapAbsen
    {
        public string id { get; set; }
        public DateTime tanggal { get; set; }
        public string izin { get; set; }
        public string hari { get; set; }
        public TimeSpan? telat { get; set; }
        public TimeSpan? masuk { get; set; }
        public TimeSpan? pulang { get; set; }
        public TimeSpan? istirahat { get; set; }
        public TimeSpan? kembali { get; set; }
        public TimeSpan? lembur { get; set; }
        public TimeSpan? lembur_pulang { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fingerprint
{
    using System;
    using System.Collections.Generic;
    
    public partial class pegawai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pegawai()
        {
            this.absens = new HashSet<absen>();
            this.izins = new HashSet<izin>();
            this.logs = new HashSet<log>();
        }
    
        public string pegawai_id { get; set; }
        public string pegawai_nip { get; set; }
        public string pegawai_nama { get; set; }
        public string pegawai_panggilan { get; set; }
        public string pegawai_golongan { get; set; }
        public string pegawai_jenis_kelamin { get; set; }
        public string pegawai_izin { get; set; }
        public string pegawai_sandi { get; set; }
        public bool upload { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absen> absens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<izin> izins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log> logs { get; set; }
    }
}
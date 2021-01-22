using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fınall.Models
{
    public class Musteri
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Soyad { get; set; }

        public virtual Forma Forma { get; set; }
    }

    public class MusteriMap : ClassMapping<Musteri>
    {
        public MusteriMap()
        {
            Table("Musteri");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Ad, c => c.Length(10));
            Property(x => x.Soyad, c => c.Length(10));
            ManyToOne(x => x.Forma);
        }
    }
}
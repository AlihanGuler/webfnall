using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace fınall.Models
{
    public class Forma
    {

        public virtual int Id { get; set; }
        public virtual string TakımAdı { get; set; }
        public virtual string Fiyat { get; set; }
        public virtual ICollection<Musteri> Musteriler { get; set; } = new List<Musteri>();
        
    }

    
    public class FormaMap : ClassMapping<Forma>
    {
        public FormaMap()
        {
            Table("Forma");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.TakımAdı, c => c.Length(20));
            Property(x => x.Fiyat);
            

            Set(e => e.Musteriler,
                mapper =>
                {
                    mapper.Key(k => k.Column("Forma"));
                    mapper.Inverse(true);
                    mapper.Cascade(Cascade.All);
                },
               relation => relation.OneToMany(mapping => mapping.Class(typeof(Musteri))));
        }
    }
};

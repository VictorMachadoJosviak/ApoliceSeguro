using Apolice.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Infra.Persistence.Map
{
    public class MapSeguro : EntityTypeConfiguration<Seguro>
    {
        public MapSeguro()
        {
            ToTable("Seguro");

            Property(p => p.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_SEGURO_ID") { IsUnique = true }));
            Property(p => p.Cpf).HasMaxLength(15).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_SEGURO_CPF") { IsUnique = true }));
            Property(p => p.Cnpj).HasMaxLength(19).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_SEGURO_CNPJ") { IsUnique = true }));
        }
    }
}
using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BrandSerial : Entity<Guid>
{
    public Guid ParentId { get; set; }//Eğer markaysa 0 olacak, seri ise markanın Id si olacak.
    public int? Depth { get; set; }// İleride bu tabloda marka - seri - model - motor hacmi tutmak istersek ağaç yapısında derinlik bilinmiş olacak.
    public CaseType CaseType { get; set; }// Kasa Tipi -- Enumda Tutuldu.
    public string Name { get; set; }

    #region VIRTUAL REFERENCES
    public virtual BrandSerial? Parent { get; set; }
    public virtual ICollection<Car> Cars { get; set; } = default!;//Bu marka modele sahip arabalar var.
    #endregion
}

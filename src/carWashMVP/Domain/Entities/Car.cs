using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Car : Entity<Guid>
{
    public Guid TenantId { get; set; }
    public Guid BrandSerialId { get; set; }// Aracın marka ve serisi.
    public int? BrandYear { get; set; }// Aracın model yılı.
    public string PlateCode { get; set; }// Aracın Plaka Numarası.
    public string ColorCode { get; set; }// Aracın Renginin kodu.

    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }//Arabanın müşteri grubu
    public virtual BrandSerial? BrandSerial { get; set; }//Arabanın marka ve modeli
    #endregion
}

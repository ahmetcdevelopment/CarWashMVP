using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AdvertSetting : Entity<Guid>
{
    public Guid AdvertId { get; set; } // ilgili ilanın şdsş
    public int DayOfWeek { get; set; } //haftanın kaçıncı günü olduğunun bilgisi - (int)DateTime.Now.DayOfWeek şeklinde elde edilebilir 
    public TimeSpan StartTime { get; set; } // ilanın o gün için aktiflik başlangıç saati
    public TimeSpan EndTime { get; set; } // ilanın o gün için aktiflik bitiş saati

    #region VIRTUAL REFERENCES
    public virtual Advert? Advert { get; set; }//Ayarın hangi ilana ait olduğu
    #endregion
}

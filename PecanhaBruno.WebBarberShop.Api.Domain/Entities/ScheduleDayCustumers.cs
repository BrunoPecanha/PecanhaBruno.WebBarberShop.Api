using System;

namespace PecanhaBruno.WebBarberShop.Domain.Entities {
    public class ScheduleDayXCustumers : To {       
        /// <summary>
        /// Id do Cliente.
        /// </summary>
        public virtual int CustumerId { get; set; }
        /// <summary>
        /// Propriedade que indica que é um relacionamento NxM
        /// </summary>
     //   public virtual Custumer Custumer { get; set; }
        /// <summary>
        /// Propriedade que indica que é um relacionamento NxM
        /// </summary>
      //  public virtual int ScheduleDayId { get; set; }
        ///// <summary>
        ///// Propriedade que indica que é um relacionamento NxM
        ///// </summary>
        public ScheduleDay ScheduleDay { get; set; }
    }
}

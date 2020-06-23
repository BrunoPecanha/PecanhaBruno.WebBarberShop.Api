using System;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Entities {
    /// <summary>
    /// Classe que cuida dos clientes agendados
    /// </summary>
    public class ScheduleDay : To {

        //private ScheduleDay() {
        //}

        public ScheduleDay() {
        }

        /// <summary>
        /// Horário inicial que a fila ficará disponível
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Horário que a fila não estará mais disponível
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Lista dos usuários da fila no momento
        /// </summary>
        public ICollection<Custumer> Custumers { get; set; }
        /// <summary>
        ///  Próximo da fila.
        /// </summary>
        public Custumer Next { get; set; }
        /// <summary>
        /// Atualmente na fila
        /// </summary>
        public Custumer Current { get; set; }
        /// <summary>
        /// Último da fila
        /// </summary>
        public Custumer Last { get; set; }
        /// <summary>
        /// Tempo estimado para o próximo da fila
        /// </summary>
        public DateTime EstimatedTimeToNext { get; set; }
        public int? DayBalanceId { get; private set; }
        public virtual DayBalance DayBalance { get; private set; }  
    }
}

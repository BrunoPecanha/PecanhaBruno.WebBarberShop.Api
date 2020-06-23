using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PecanhaBruno.WebBarberShop.Domain.Entities {
    public class To {
        /// <summary>
        /// Id Interno dos registros.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        /// <summary>
        /// Data de cadastro do registro.
        /// </summary>
        public DateTime RegisteringDate { get; private set; }
        /// <summary>
        /// Última atualização do registro.
        /// </summary>
        public DateTime LastUpdate { get; private set; }
    }
}

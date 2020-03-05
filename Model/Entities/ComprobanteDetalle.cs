namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComprobanteDetalle")]
    public partial class ComprobanteDetalle
    {
        public int id { get; set; }

        public int ComprobanteId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Monto { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Producto Producto { get; set; }
    }

    #region ViewModels
    public partial class ComprobanteDetalleViewModel
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Retirar { get; set; }
        public decimal Descuento { get; set; }
        public decimal Monto()
        {
            bool resultado = EsPrimo(Cantidad);
            decimal total = (Cantidad * PrecioUnitario);
            if (ProductoNombre == "Gelatina" && !resultado)
            {
                total =  total/ 2;
            }
            return total;
        }

        public bool EsPrimo(int numero)
        {
            int divisor = 2;
            int resto = 0;
            while (divisor < numero)
            {
                resto = numero % divisor;
                if (resto == 0)
                {
                    return false;
                }
                divisor = divisor + 1;
            }
            return true;
        }
    }
    #endregion
}
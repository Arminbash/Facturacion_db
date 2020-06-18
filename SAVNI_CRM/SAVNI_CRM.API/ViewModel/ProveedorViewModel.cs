namespace SAVNI_CRM.API.ViewModel
{
    public class ProveedorViewModel
    {
        public int IdProveedor { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; }
        public string Direccion { get; set; }
        public int? IdEmpresa { get; set; }
        public ulong? Estado { get; set; }
    }
}
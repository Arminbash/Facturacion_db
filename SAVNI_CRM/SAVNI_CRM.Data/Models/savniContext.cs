using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SAVNI_CRM.Data.Models
{
    public partial class savniContext : DbContext
    {
        public savniContext()
        {
        }

        public savniContext(DbContextOptions<savniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Bodega> Bodega { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<Detallecompra> Detallecompra { get; set; }
        public virtual DbSet<Detalledevolucioncompra> Detalledevolucioncompra { get; set; }
        public virtual DbSet<Detalledevolucionfactura> Detalledevolucionfactura { get; set; }
        public virtual DbSet<Detallefactura> Detallefactura { get; set; }
        public virtual DbSet<Detallepagofactura> Detallepagofactura { get; set; }
        public virtual DbSet<Devolucioncompra> Devolucioncompra { get; set; }
        public virtual DbSet<Devolucionfactura> Devolucionfactura { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Equivalenciaproducto> Equivalenciaproducto { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Kardex> Kardex { get; set; }
        public virtual DbSet<Listaaccesos> Listaaccesos { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<Lotekardex> Lotekardex { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Precioproducto> Precioproducto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Proveedorcontacto> Proveedorcontacto { get; set; }
        public virtual DbSet<RolLista> RolLista { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Sucursalempleado> Sucursalempleado { get; set; }
        public virtual DbSet<Talla> Talla { get; set; }
        public virtual DbSet<Tasacambio> Tasacambio { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Unidadmedida> Unidadmedida { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=savni;user id=sa;password=123", x => x.ServerVersion("10.4.6-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora)
                    .HasName("PRIMARY");

                entity.ToTable("bitacora");

                entity.HasIndex(e => e.IdBitacora)
                    .HasName("IdBitacora")
                    .IsUnique();

                entity.Property(e => e.IdBitacora).HasColumnType("int(11)");

                entity.Property(e => e.Accion)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HoraFecha).HasColumnType("date");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.IdRegistoAfectado).HasColumnType("int(11)");

                entity.Property(e => e.IdSucursal).HasColumnType("int(11)");

                entity.Property(e => e.TablaAfectada)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.IdBodega)
                    .HasName("PRIMARY");

                entity.ToTable("bodega");

                entity.HasIndex(e => e.IdBodega)
                    .HasName("IdBodega")
                    .IsUnique();

                entity.HasIndex(e => e.IdSucursal)
                    .HasName("IdSucursal");

                entity.Property(e => e.IdBodega).HasColumnType("int(11)");

                entity.Property(e => e.CodigoBodega)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdSucursal).HasColumnType("int(11)");

                entity.Property(e => e.NombreBodega)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Bodega)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("bodega_ibfk_1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("IdCliente")
                    .IsUnique();

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IdEmpresa");

                entity.Property(e => e.IdCliente).HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CedulaRuc)
                    .HasColumnName("Cedula_Ruc")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CodigoCliente)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("cliente_ibfk_1");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PRIMARY");

                entity.ToTable("compra");

                entity.HasIndex(e => e.IdCompra)
                    .HasName("IdCompra")
                    .IsUnique();

                entity.HasIndex(e => e.IdSucursal)
                    .HasName("IdSucursal");

                entity.HasIndex(e => e.SerieConsecutivo)
                    .HasName("SerieConsecutivo")
                    .IsUnique();

                entity.Property(e => e.IdCompra).HasColumnType("int(11)");

                entity.Property(e => e.Consecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.FechaCompra).HasColumnType("date");

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.IdBodega).HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor).HasColumnType("int(11)");

                entity.Property(e => e.IdSerie).HasColumnType("int(11)");

                entity.Property(e => e.IdSucursal).HasColumnType("int(11)");

                entity.Property(e => e.Moneda)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NumFactura)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerieConsecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Tasa).HasColumnType("decimal(18,4)");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("compra_ibfk_1");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracion)
                    .HasName("PRIMARY");

                entity.ToTable("configuracion");

                entity.HasIndex(e => e.IdConfiguracion)
                    .HasName("IdConfiguracion")
                    .IsUnique();

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IdEmpresa");

                entity.Property(e => e.IdConfiguracion).HasColumnType("int(11)");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.MonedaPrincipal)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Configuracion)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("configuracion_ibfk_1");
            });

            modelBuilder.Entity<Detallecompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PRIMARY");

                entity.ToTable("detallecompra");

                entity.HasIndex(e => e.IdCompra)
                    .HasName("IdCompra");

                entity.HasIndex(e => e.IdDetalleCompra)
                    .HasName("IdDetalleCompra")
                    .IsUnique();

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.Property(e => e.IdDetalleCompra).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18,4)");

                entity.Property(e => e.Costo).HasColumnType("decimal(18,4)");

                entity.Property(e => e.Descuento).HasColumnType("decimal(18,4)");

                entity.Property(e => e.IdCompra).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.Property(e => e.IdUnidadMedida).HasColumnType("int(11)");

                entity.Property(e => e.Importe).HasColumnType("decimal(18,4)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Detallecompra)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("detallecompra_ibfk_1");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detallecompra)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("detallecompra_ibfk_2");
            });

            modelBuilder.Entity<Detalledevolucioncompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleDevolucionCompra)
                    .HasName("PRIMARY");

                entity.ToTable("detalledevolucioncompra");

                entity.HasIndex(e => e.IdDetalleDevolucionCompra)
                    .HasName("IdDetalleDevolucionCompra")
                    .IsUnique();

                entity.HasIndex(e => e.IdDevolucionCompra)
                    .HasName("IdDevolucionCompra");

                entity.Property(e => e.IdDetalleDevolucionCompra).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18,4)");

                entity.Property(e => e.IdDevolucionCompra).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.HasOne(d => d.IdDevolucionCompraNavigation)
                    .WithMany(p => p.Detalledevolucioncompra)
                    .HasForeignKey(d => d.IdDevolucionCompra)
                    .HasConstraintName("detalledevolucioncompra_ibfk_1");
            });

            modelBuilder.Entity<Detalledevolucionfactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleDevolucion)
                    .HasName("PRIMARY");

                entity.ToTable("detalledevolucionfactura");

                entity.HasIndex(e => e.IdDetalleDevolucion)
                    .HasName("IdDetalleDevolucion")
                    .IsUnique();

                entity.Property(e => e.IdDetalleDevolucion)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18,4)");

                entity.Property(e => e.IdDevolucionFactura).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.HasOne(d => d.IdDetalleDevolucionNavigation)
                    .WithOne(p => p.Detalledevolucionfactura)
                    .HasForeignKey<Detalledevolucionfactura>(d => d.IdDetalleDevolucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalledevolucionfactura_ibfk_1");
            });

            modelBuilder.Entity<Detallefactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura)
                    .HasName("PRIMARY");

                entity.ToTable("detallefactura");

                entity.HasIndex(e => e.IdDetalleFactura)
                    .HasName("IdDetalleFactura")
                    .IsUnique();

                entity.HasIndex(e => e.IdFactura)
                    .HasName("IdFactura");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.Property(e => e.IdDetalleFactura).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18,4)");

                entity.Property(e => e.Costo).HasColumnType("decimal(18,4)");

                entity.Property(e => e.Descuento).HasColumnType("decimal(18,4)");

                entity.Property(e => e.IdFactura).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.Property(e => e.Impuesto).HasColumnType("decimal(18,4)");

                entity.Property(e => e.Precio).HasColumnType("decimal(18,4)");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Detallefactura)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("detallefactura_ibfk_1");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detallefactura)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("detallefactura_ibfk_2");
            });

            modelBuilder.Entity<Detallepagofactura>(entity =>
            {
                entity.HasKey(e => e.IdDetallePagoFactura)
                    .HasName("PRIMARY");

                entity.ToTable("detallepagofactura");

                entity.HasIndex(e => e.IdDetallePagoFactura)
                    .HasName("IdDetallePagoFactura")
                    .IsUnique();

                entity.HasIndex(e => e.IdFactura)
                    .HasName("IdFactura");

                entity.Property(e => e.IdDetallePagoFactura).HasColumnType("int(11)");

                entity.Property(e => e.IdFactura).HasColumnType("int(11)");

                entity.Property(e => e.Moneda)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Monto).HasColumnType("decimal(18,4)");

                entity.Property(e => e.TipoPago)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Detallepagofactura)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("detallepagofactura_ibfk_1");
            });

            modelBuilder.Entity<Devolucioncompra>(entity =>
            {
                entity.HasKey(e => e.IdDevolucionCompra)
                    .HasName("PRIMARY");

                entity.ToTable("devolucioncompra");

                entity.HasIndex(e => e.IdCompra)
                    .HasName("IdCompra");

                entity.HasIndex(e => e.IdDevolucionCompra)
                    .HasName("IdDevolucionCompra")
                    .IsUnique();

                entity.HasIndex(e => e.SerieConsecutivo)
                    .HasName("SerieConsecutivo")
                    .IsUnique();

                entity.Property(e => e.IdDevolucionCompra).HasColumnType("int(11)");

                entity.Property(e => e.Consecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdCompra).HasColumnType("int(11)");

                entity.Property(e => e.IdSerie).HasColumnType("int(11)");

                entity.Property(e => e.Motivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerieConsecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Tipo)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Devolucioncompra)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("devolucioncompra_ibfk_1");
            });

            modelBuilder.Entity<Devolucionfactura>(entity =>
            {
                entity.HasKey(e => e.IdDevolucionFactura)
                    .HasName("PRIMARY");

                entity.ToTable("devolucionfactura");

                entity.HasIndex(e => e.IdDevolucionFactura)
                    .HasName("IdDevolucionFactura")
                    .IsUnique();

                entity.HasIndex(e => e.IdFactura)
                    .HasName("IdFactura");

                entity.HasIndex(e => e.SerieConsecutivo)
                    .HasName("SerieConsecutivo")
                    .IsUnique();

                entity.Property(e => e.IdDevolucionFactura).HasColumnType("int(11)");

                entity.Property(e => e.Consecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdFactura).HasColumnType("int(11)");

                entity.Property(e => e.IdSerie).HasColumnType("int(11)");

                entity.Property(e => e.Motivo)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerieConsecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Tipo)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Devolucionfactura)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("devolucionfactura_ibfk_1");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleado");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("IdEmpleado")
                    .IsUnique();

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IdEmpresa");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cedula)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("empleado_ibfk_1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IdEmpresa")
                    .IsUnique();

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ruc)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Equivalenciaproducto>(entity =>
            {
                entity.HasKey(e => e.IdEquivalencia)
                    .HasName("PRIMARY");

                entity.ToTable("equivalenciaproducto");

                entity.HasIndex(e => e.IdEquivalencia)
                    .HasName("IdEquivalencia")
                    .IsUnique();

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.Property(e => e.IdEquivalencia).HasColumnType("int(11)");

                entity.Property(e => e.CantidadSecundaria).HasColumnType("decimal(18,4)");

                entity.Property(e => e.CantidadTercera).HasColumnType("decimal(18,4)");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdEquivalenciaPrimaria).HasColumnType("int(11)");

                entity.Property(e => e.IdEquivalenciaSecundaria).HasColumnType("int(11)");

                entity.Property(e => e.IdEquivalenciaTercera).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Equivalenciaproducto)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("equivalenciaproducto_ibfk_1");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("factura");

                entity.HasIndex(e => e.IdFactura)
                    .HasName("IdFactura")
                    .IsUnique();

                entity.HasIndex(e => e.IdSucursal)
                    .HasName("IdSucursal");

                entity.HasIndex(e => e.SerieConsecutivo)
                    .HasName("SerieConsecutivo")
                    .IsUnique();

                entity.Property(e => e.IdFactura).HasColumnType("int(11)");

                entity.Property(e => e.Consecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnType("int(11)");

                entity.Property(e => e.IdSerie).HasColumnType("int(11)");

                entity.Property(e => e.IdSucursal).HasColumnType("int(11)");

                entity.Property(e => e.IdVendedor).HasColumnType("int(11)");

                entity.Property(e => e.Moneda)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerieConsecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TipoPago)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("factura_ibfk_1");
            });

            modelBuilder.Entity<Kardex>(entity =>
            {
                entity.HasKey(e => e.IdKardex)
                    .HasName("PRIMARY");

                entity.ToTable("kardex");

                entity.HasIndex(e => e.IdKardex)
                    .HasName("IdKardex")
                    .IsUnique();

                entity.Property(e => e.IdKardex).HasColumnType("int(11)");

                entity.Property(e => e.CantidadDisponible).HasColumnType("decimal(18,4)");

                entity.Property(e => e.CantidadEntrada).HasColumnType("decimal(18,4)");

                entity.Property(e => e.CantidadSalida).HasColumnType("decimal(18,4)");

                entity.Property(e => e.CostoPonderado).HasColumnType("decimal(18,4)");

                entity.Property(e => e.CostoSimple).HasColumnType("decimal(18,4)");

                entity.Property(e => e.IdBodega).HasColumnType("int(11)");

                entity.Property(e => e.IdMovimiento).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.Property(e => e.IdUnidadMedida).HasColumnType("int(11)");

                entity.Property(e => e.Movimiento)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Listaaccesos>(entity =>
            {
                entity.HasKey(e => e.IdListaAcceso)
                    .HasName("PRIMARY");

                entity.ToTable("listaaccesos");

                entity.HasIndex(e => e.IdListaAcceso)
                    .HasName("IdListaAcceso")
                    .IsUnique();

                entity.Property(e => e.IdListaAcceso).HasColumnType("int(11)");

                entity.Property(e => e.NombreVista)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote)
                    .HasName("PRIMARY");

                entity.ToTable("lote");

                entity.HasIndex(e => e.IdLote)
                    .HasName("IdLote")
                    .IsUnique();

                entity.HasIndex(e => e.IdTalla)
                    .HasName("IdTalla");

                entity.Property(e => e.IdLote).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.Property(e => e.IdTalla).HasColumnType("int(11)");

                entity.HasOne(d => d.IdTallaNavigation)
                    .WithMany(p => p.Lote)
                    .HasForeignKey(d => d.IdTalla)
                    .HasConstraintName("lote_ibfk_1");
            });

            modelBuilder.Entity<Lotekardex>(entity =>
            {
                entity.HasKey(e => e.IdLoteKardex)
                    .HasName("PRIMARY");

                entity.ToTable("lotekardex");

                entity.HasIndex(e => e.IdKardex)
                    .HasName("IdKardex");

                entity.HasIndex(e => e.IdLote)
                    .HasName("IdLote");

                entity.HasIndex(e => e.IdLoteKardex)
                    .HasName("IdLoteKardex")
                    .IsUnique();

                entity.Property(e => e.IdLoteKardex).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18,4)");

                entity.Property(e => e.IdKardex).HasColumnType("int(11)");

                entity.Property(e => e.IdLote).HasColumnType("int(11)");

                entity.HasOne(d => d.IdKardexNavigation)
                    .WithMany(p => p.Lotekardex)
                    .HasForeignKey(d => d.IdKardex)
                    .HasConstraintName("lotekardex_ibfk_1");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.Lotekardex)
                    .HasForeignKey(d => d.IdLote)
                    .HasConstraintName("lotekardex_ibfk_2");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PRIMARY");

                entity.ToTable("marca");

                entity.HasIndex(e => e.IdMarca)
                    .HasName("IdMarca")
                    .IsUnique();

                entity.Property(e => e.IdMarca).HasColumnType("int(11)");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Precioproducto>(entity =>
            {
                entity.HasKey(e => e.IdPrecioProducto)
                    .HasName("PRIMARY");

                entity.ToTable("precioproducto");

                entity.HasIndex(e => e.IdPrecioProducto)
                    .HasName("IdPrecioProducto")
                    .IsUnique();

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.Property(e => e.IdPrecioProducto).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.Property(e => e.Moneda)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PrecioMaximo).HasColumnType("decimal(18,4)");

                entity.Property(e => e.PrecioMinimo).HasColumnType("decimal(18,4)");

                entity.Property(e => e.TipoValor)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Precioproducto)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("precioproducto_ibfk_1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.IdMarca)
                    .HasName("IdMarca");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto")
                    .IsUnique();

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdMarca).HasColumnType("int(11)");

                entity.Property(e => e.IdUnidadMedida).HasColumnType("int(11)");

                entity.Property(e => e.Iva).HasColumnType("decimal(18,4)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TrabajaLote).HasColumnType("bit(1)");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("producto_ibfk_1");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PRIMARY");

                entity.ToTable("proveedor");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IdEmpresa");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("IdProveedor")
                    .IsUnique();

                entity.Property(e => e.IdProveedor).HasColumnType("int(11)");

                entity.Property(e => e.Consecutivo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.IdSerie).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerieConsecutivo)
                    .HasColumnType("varchar(120)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TipoProducto)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("proveedor_ibfk_1");
            });

            modelBuilder.Entity<Proveedorcontacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto)
                    .HasName("PRIMARY");

                entity.ToTable("proveedorcontacto");

                entity.HasIndex(e => e.IdContacto)
                    .HasName("IdContacto")
                    .IsUnique();

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("IdProveedor");

                entity.Property(e => e.IdContacto).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdProveedor).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Proveedorcontacto)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("proveedorcontacto_ibfk_1");
            });

            modelBuilder.Entity<RolLista>(entity =>
            {
                entity.HasKey(e => e.IdRolLista)
                    .HasName("PRIMARY");

                entity.ToTable("rol_lista");

                entity.HasIndex(e => e.IdAcceso)
                    .HasName("IdAcceso");

                entity.HasIndex(e => e.IdRol)
                    .HasName("IdRol");

                entity.HasIndex(e => e.IdRolLista)
                    .HasName("IdRolLista")
                    .IsUnique();

                entity.Property(e => e.IdRolLista).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdAcceso).HasColumnType("int(11)");

                entity.Property(e => e.IdRol).HasColumnType("int(11)");

                entity.HasOne(d => d.IdAccesoNavigation)
                    .WithMany(p => p.RolLista)
                    .HasForeignKey(d => d.IdAcceso)
                    .HasConstraintName("rol_lista_ibfk_1");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolLista)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("rol_lista_ibfk_2");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IdEmpresa");

                entity.HasIndex(e => e.IdRol)
                    .HasName("IdRol")
                    .IsUnique();

                entity.Property(e => e.IdRol).HasColumnType("int(11)");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.NombreRol)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("roles_ibfk_1");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.HasKey(e => e.IdSerie)
                    .HasName("PRIMARY");

                entity.ToTable("serie");

                entity.HasIndex(e => e.IdSerie)
                    .HasName("IdSerie")
                    .IsUnique();

                entity.HasIndex(e => e.IdSucursal)
                    .HasName("IdSucursal");

                entity.Property(e => e.IdSerie).HasColumnType("int(11)");

                entity.Property(e => e.IdSucursal).HasColumnType("int(11)");

                entity.Property(e => e.NombreDocumento)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NumConsecutivo).HasColumnType("int(11)");

                entity.Property(e => e.Prefijo)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Serie)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("serie_ibfk_1");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PRIMARY");

                entity.ToTable("sucursal");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IdEmpresa");

                entity.HasIndex(e => e.IdSucursal)
                    .HasName("IdSucursal")
                    .IsUnique();

                entity.Property(e => e.IdSucursal).HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.IdEncargado).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Sucursal)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("sucursal_ibfk_1");
            });

            modelBuilder.Entity<Sucursalempleado>(entity =>
            {
                entity.HasKey(e => e.IdSucursalempleado)
                    .HasName("PRIMARY");

                entity.ToTable("sucursalempleado");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("IdEmpleado");

                entity.HasIndex(e => e.IdSucursal)
                    .HasName("IdSucursal");

                entity.HasIndex(e => e.IdSucursalempleado)
                    .HasName("IdSucursalempleado")
                    .IsUnique();

                entity.Property(e => e.IdSucursalempleado).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.IdSucursal).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Sucursalempleado)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("sucursalempleado_ibfk_1");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Sucursalempleado)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("sucursalempleado_ibfk_2");
            });

            modelBuilder.Entity<Talla>(entity =>
            {
                entity.HasKey(e => e.IdTalla)
                    .HasName("PRIMARY");

                entity.ToTable("talla");

                entity.HasIndex(e => e.IdTalla)
                    .HasName("IdTalla")
                    .IsUnique();

                entity.HasIndex(e => e.IdTipo)
                    .HasName("IdTipo");

                entity.Property(e => e.IdTalla).HasColumnType("int(11)");

                entity.Property(e => e.IdTipo).HasColumnType("int(11)");

                entity.Property(e => e.Tamanio)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Talla)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("talla_ibfk_1");
            });

            modelBuilder.Entity<Tasacambio>(entity =>
            {
                entity.HasKey(e => e.IdTasaCambio)
                    .HasName("PRIMARY");

                entity.ToTable("tasacambio");

                entity.HasIndex(e => e.IdTasaCambio)
                    .HasName("IdTasaCambio")
                    .IsUnique();

                entity.Property(e => e.IdTasaCambio).HasColumnType("int(11)");

                entity.Property(e => e.FechaTasa).HasColumnType("date");

                entity.Property(e => e.Moneda)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Monto).HasColumnType("decimal(18,4)");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PRIMARY");

                entity.ToTable("tipo");

                entity.HasIndex(e => e.IdTipo)
                    .HasName("IdTipo")
                    .IsUnique();

                entity.Property(e => e.IdTipo).HasColumnType("int(11)");

                entity.Property(e => e.NombreTipo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Unidadmedida>(entity =>
            {
                entity.HasKey(e => e.IdUnidadMedida)
                    .HasName("PRIMARY");

                entity.ToTable("unidadmedida");

                entity.HasIndex(e => e.IdUnidadMedida)
                    .HasName("IdUnidadMedida")
                    .IsUnique();

                entity.Property(e => e.IdUnidadMedida).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("IdEmpleado");

                entity.HasIndex(e => e.IdRol)
                    .HasName("IdRol");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IdUsuario")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Contrasenia)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.IdRol).HasColumnType("int(11)");

                entity.Property(e => e.NombreUsuario)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("usuario_ibfk_1");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("usuario_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

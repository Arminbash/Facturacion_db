

create table Bitacora(
IdBitacora int NOT NULL AUTO_INCREMENT,
Accion varchar(200),
HoraFecha date,
IdEmpleado int,
TablaAfectada varchar(200),
IdRegistoAfectado int,
IdSucursal int,
UNIQUE (IdBitacora),
primary key (IdBitacora)
);
create table UnidadMedida(
    IdUnidadMedida int NOT NULL AUTO_INCREMENT,
    Nombre varchar(200),
    UNIQUE(IdUnidadMedida),
    primary key (IdUnidadMedida)
);
create table kardex(
    IdKardex int NOT NULL AUTO_INCREMENT,
    IdProducto int,
    CantidadEntrada decimal(18,4),
    CantidadSalida decimal(18,4),
    CantidadDisponible decimal(18,4),
    IdMovimiento int,
    Movimiento varchar(200),
    IdUnidadMedida int,
    CostoPonderado decimal(18,4),
    CostoSimple decimal(18,4),
    IdBodega int,
    UNIQUE(IdKardex),
    primary key (IdKardex)
);
create table TasaCambio(
  IdTasaCambio int NOT NULL AUTO_INCREMENT,
  FechaTasa date,
  Moneda varchar(50),
  Monto decimal(18,4),
  UNIQUE(IdTasaCambio),
  primary key (IdTasaCambio)
);
create table Empresa(
    IdEmpresa int NOT NULL AUTO_INCREMENT,
    Nombre varchar(50),
    Ruc varchar(100),
    Direccion varchar(2000),
    Correo varchar(100),
    Telefono varchar(50),
    UNIQUE(IdEmpresa),
    primary key (IdEmpresa)
);
create table Cliente(
    IdCliente int NOT NULL AUTO_INCREMENT,
    CodigoCliente varchar(100),
    Nombres varchar(200),
    Apellidos varchar(200),
    Cedula_Ruc varchar(50),
    Direccion varchar(2000),
    Telefono varchar(50),
    Estado BIT,
    IdEmpresa int,
    UNIQUE(IdCliente),
    primary key (IdCliente),
    foreign key (IdEmpresa) references Empresa(IdEmpresa)
);
create table Configuracion(
    IdConfiguracion int NOT NULL AUTO_INCREMENT,
    IdEmpresa int,
    MonedaPrincipal varchar(50),
    Unique(IdConfiguracion),
    primary key (IdConfiguracion),
    foreign key (IdEmpresa) references Empresa(IdEmpresa)
);
create table Proveedor(
    IdProveedor int NOT NULL AUTO_INCREMENT,
    Consecutivo varchar(100),
    Nombre varchar(200),
    TipoProducto varchar(100),
    Direccion varchar(200),
    IdSerie int,
    IdEmpresa int,
    SerieConsecutivo varchar(120),
    Estado bit,
    UNIQUE(IdProveedor),
    primary key (IdProveedor),
    foreign key (IdEmpresa) references Empresa(IdEmpresa)
);
create table ProveedorContacto(
    IdContacto int NOT NULL AUTO_INCREMENT,
    IdProveedor int,
    Nombre VARCHAR(200),
    Descripcion VARCHAR(1000),
    Telefono VARCHAR(50),
    Estado bit,
    UNIQUE(IdContacto),
    primary key (IdContacto),
    foreign key (IdProveedor) REFERENCES Proveedor(IdProveedor)
);
create table Roles(
    IdRol int NOT NULL AUTO_INCREMENT,
    NombreRol VARCHAR(50),
    IdEmpresa int,
    UNIQUE(IdRol),
    primary key (IdRol),
    FOREIGN KEY (IdEmpresa) REFERENCES Empresa(IdEmpresa)
);
CREATE TABLE ListaAccesos(
    IdListaAcceso int NOT NULL AUTO_INCREMENT,
    NombreVista VARCHAR(200),
    UNIQUE(IdListaAcceso),
    primary key (IdListaAcceso)
);
create TABLE Rol_Lista(
    IdRolLista int NOT NULL AUTO_INCREMENT,
    IdAcceso int,
    IdRol int,
    Estado bit,
    UNIQUE(IdRolLista),
    PRIMARY KEY (IdRolLista),
    FOREIGN key (IdAcceso) REFERENCES ListaAccesos(IdListaAcceso),
    foreign key (IdRol) REFERENCES Roles(IdRol)
);
CREATE TABLE Sucursal(
    IdSucursal int NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(200),
    Telefono VARCHAR(50),
    Correo VARCHAR(100),
    Direccion VARCHAR(200),
    IdEncargado int,
    IdEmpresa int,
    Unique(IdSucursal),
    PRIMARY key (IdSucursal),
    FOREIGN key (IdEmpresa) REFERENCES Empresa(IdEmpresa)
);
create TABLE Serie(
    IdSerie int NOT NULL AUTO_INCREMENT,
    Prefijo VARCHAR(50),
    NumConsecutivo int,
    NombreDocumento VARCHAR(200),
    IdSucursal int,
    UNIQUE(IdSerie),
    primary key (IdSerie),
    FOREIGN key (IdSucursal) REFERENCES Sucursal(IdSucursal)
);
create TABLE Bodega(
    IdBodega int NOT NULL AUTO_INCREMENT,
    CodigoBodega VARCHAR(100),
    NombreBodega VARCHAR(200),
    IdSucursal int,
    Unique(IdBodega),
    PRIMARY KEY (IdBodega),
    FOREIGN KEY (IdSucursal) REFERENCES Sucursal(IdSucursal)
);
create TABLE Empleado(
    IdEmpleado int NOT NULL AUTO_INCREMENT,
    Nombres VARCHAR(200),
    Apellidos VARCHAR(200),
    Cedula VARCHAR(100),
    Direccion VARCHAR(200),
    Telefono VARCHAR(50),
    Correo VARCHAR(100),
    IdEmpresa int,
    Estado bit,
    Unique(IdEmpleado),
    primary KEY(IdEmpleado),
    FOREIGN key (IdEmpresa) REFERENCES Empresa(IdEmpresa)
);
create table Usuario(
    IdUsuario int NOT NULL AUTO_INCREMENT,
    IdEmpleado int,
    NombreUsuario VARCHAR(50),
    Contrasenia VARCHAR(50),
    Estado bit,
    IdRol int,
    UNIQUE(IdUsuario),
    primary KEY(IdUsuario),
    foreign key (IdEmpleado) REFERENCES Empleado(IdEmpleado),
    FOREIGN key(IdRol) REFERENCES Roles(IdRol)
);
create TABLE SucursalEmpleado(
    IdSucursalempleado int NOT NULL AUTO_INCREMENT,
    IdEmpleado int,
    IdSucursal int,
    Estado bit,
    UNIQUE(IdSucursalempleado),
    PRIMARY key (IdSucursalempleado),
    foreign KEY (IdEmpleado) REFERENCES Empleado(IdEmpleado),
    FOREIGN KEY (IdSucursal) REFERENCES Sucursal(IdSucursal)
);
create table Marca(
    IdMarca int NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(100),
    IdEmpresa int,
    UNIQUE(IdMarca),
    PRIMARY key (IdMarca)
);
create table Producto(
    IdProducto int NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(200),
    Descripcion VARCHAR(500),
    IdMarca int,
    IdUnidadMedida int,
    Iva DECIMAL(18,4),
    Estado Bit,
    TrabajaLote Bit,
    UNIQUE(IdProducto),
    primary key (IdProducto),
    FOREIGN key (IdMarca) REFERENCES Marca(IdMarca)
);
create table Tipo(
    IdTipo int NOT NULL AUTO_INCREMENT,
    NombreTipo VARCHAR(100),
    UNIQUE(IdTipo),
    primary key (IdTipo)
);
create table Talla(
    IdTalla int NOT NULL AUTO_INCREMENT,
    IdTipo int,
    Tamanio VARCHAR(20),
    UNIQUE(IdTalla),
    primary key (IdTalla),
    FOREIGN key (IdTipo) REFERENCES Tipo(IdTipo)
);
create table Lote(
    IdLote int NOT NULL AUTO_INCREMENT,
    IdProducto int,
    IdTalla int,
    UNIQUE(IdLote),
    primary key (IdLote),
    foreign key (IdTalla) REFERENCES Talla(IdTalla)
);
create table LoteKardex(
    IdLoteKardex int NOT NULL AUTO_INCREMENT,
    IdKardex int,
    IdLote int,
    Cantidad DECIMAL(18,4),
    UNIQUE(IdLoteKardex),
    primary key (IdLoteKardex),
    foreign key (IdKardex) REFERENCES kardex(IdKardex),
    foreign key (IdLote) REFERENCES Lote(IdLote)
);
create table EquivalenciaProducto(
    IdEquivalencia int NOT NULL AUTO_INCREMENT,
    IdEquivalenciaPrimaria int,
    IdEquivalenciaSecundaria int,
    CantidadSecundaria DECIMAL(18,4),
    IdEquivalenciaTercera int,
    CantidadTercera DECIMAL(18,4),
    IdProducto int,
    Estado bit,
    UNIQUE(IdEquivalencia),
    primary key (IdEquivalencia),
    FOREIGN key (IdProducto) REFERENCES Producto(IdProducto)
);
create table PrecioProducto(
    IdPrecioProducto int NOT NULL AUTO_INCREMENT,
    Moneda VARCHAR(20),
    Fecha date,
    TipoValor VARCHAR(20),
    PrecioMaximo DECIMAL(18,4),
    PrecioMinimo DECIMAL(18,4),
    IdProducto int,
    UNIQUE(IdPrecioProducto),
    primary key (IdPrecioProducto),
    FOREIGN key (IdProducto) REFERENCES Producto(IdProducto)
);
create table Compra(
    IdCompra int NOT NULL AUTO_INCREMENT,
    Consecutivo VARCHAR(100),
    NumFactura VARCHAR(50),
    FechaCompra DATE,
    FechaIngreso date,
    Tasa DECIMAL(18,4),
    Moneda VARCHAR(20),
    IdProveedor int,
    IdSerie int,
    SerieConsecutivo VARCHAR(100),
    Estado bit,
    IdSucursal int,
    IdBodega int,
    UNIQUE(IdCompra),
    Unique(SerieConsecutivo),
    primary key (IdCompra),
    FOREIGN key (IdSucursal) REFERENCES Sucursal(IdSucursal)
);
create table DetalleCompra(
    IdDetalleCompra int NOT NULL AUTO_INCREMENT,
    IdCompra int,
    IdProducto int,
    IdUnidadMedida int,
    Cantidad DECIMAL(18,4),
    Costo DECIMAL(18,4),
    Importe DECIMAL(18,4),
    Descuento DECIMAL(18,4),
    UNIQUE(IdDetalleCompra),
    PRIMARY key (IdDetalleCompra),
    foreign key (IdCompra) REFERENCES Compra(IdCompra),
    FOREIGN key (IdProducto) REFERENCES Producto(IdProducto)
);
create table DevolucionCompra(
    IdDevolucionCompra int NOT NULL AUTO_INCREMENT,
    Consecutivo VARCHAR(100),
    IdCompra int,
    Motivo VARCHAR(100),
    Fecha date,
    IdSerie int,
    SerieConsecutivo VARCHAR(100),
    Tipo VARCHAR(20),
    UNIQUE(IdDevolucionCompra),
     Unique(SerieConsecutivo),
    primary key (IdDevolucionCompra),
    foreign key (IdCompra) REFERENCES Compra(IdCompra)
);
create table DetalleDevolucionCompra(
    IdDetalleDevolucionCompra int NOT NULL AUTO_INCREMENT,
    IdDevolucionCompra int,
    IdProducto int,
    Cantidad DECIMAL(18,4),
    UNIQUE(IdDetalleDevolucionCompra),
    primary key (IdDetalleDevolucionCompra),
    foreign key (IdDevolucionCompra) REFERENCES DevolucionCompra(IdDevolucionCompra)
);
CREATE table Factura(
    IdFactura int NOT NULL AUTO_INCREMENT,
    Consecutivo VARCHAR(100),
    Fecha date,
    Moneda VARCHAR(20),
    IdCliente int,
    TipoPago varchar(20),
    IdVendedor int,
    IdSerie int,
    IdSucursal int,
    Estado bit,
    SerieConsecutivo VARCHAR(100),
    UNIQUE(IdFactura),
    Unique(SerieConsecutivo),
    PRIMARY key (IdFactura),
    FOREIGN key (IdSucursal) REFERENCES Sucursal(IdSucursal)
);
create TABLE DetalleFactura(
    IdDetalleFactura int NOT NULL AUTO_INCREMENT,
    IdProducto int,
    Cantidad DECIMAL(18,4),
    Costo DECIMAL(18,4),
    Precio DECIMAL(18,4),
    Descuento DECIMAL(18,4),
    Impuesto DECIMAL(18,4),
    IdFactura int,
    UNIQUE(IdDetalleFactura),
    PRIMARY key (IdDetalleFactura),
    FOREIGN key (IdFactura) REFERENCES Factura(IdFactura),
    foreign key (IdProducto) REFERENCES Producto(IdProducto)
);
create table DetallePagoFactura(
    IdDetallePagoFactura int NOT NULL AUTO_INCREMENT,
    IdFactura int,
    TipoPago VARCHAR(20),
    Monto DECIMAL(18,4),
    Moneda VARCHAR(20),
    UNIQUE(IdDetallePagoFactura),
    PRIMARY key (IdDetallePagoFactura),
    FOREIGN key (IdFactura) REFERENCES Factura(IdFactura)
);
create table DevolucionFactura(
    IdDevolucionFactura int NOT NULL AUTO_INCREMENT,
    IdFactura int,
    Consecutivo VARCHAR(100),
    Tipo VARCHAR(20),
    Motivo VARCHAR(200),
    Fecha date,
    IdSerie int,
    SerieConsecutivo VARCHAR(100),
    UNIQUE(IdDevolucionFactura),
    Unique(SerieConsecutivo),
    PRIMARY key (IdDevolucionFactura),
    FOREIGN key (IdFactura) REFERENCES Factura(IdFactura)
);
create table DetalleDevolucionFactura(
    IdDetalleDevolucion int NOT NULL AUTO_INCREMENT,
    IdDevolucionFactura int,
    IdProducto int,
    Cantidad decimal(18,4),
    UNIQUE(IdDetalleDevolucion),
    primary key (IdDetalleDevolucion),
    FOREIGN key (IdDetalleDevolucion) REFERENCES DevolucionFactura(IdDevolucionFactura)
);








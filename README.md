Decidir SDK .Net
=======

Modulo para conexión con gateway de pago DECIDIR

  * [Instalación](#instalación)
  * [Manual de Integración](#manual-de-integración)
  * [Generalidades](#generalidades)
  * [SendAuthorizeRequest](#sendauthorizerequest)
    * [Medios de Pago](#medios-de-pago)
      * [Tarjetas de Crédito](#tarjetas-de-crédito)
      * [Rapipago](#rapipago)
      * [Pago Fácil](#pago-fácil)
      * [Pago mis Cuentas](#pago-mis-cuentas)
    * [Integración con Cybersource](#integración-con-cybersource)
	  * [Parámetros Comunes](#parámetros-comunes)
      * [Retail](#retail)
      * [Travel](#travel)
      * [Ticketing](#ticketing)
      * [Services](#services)
      * [Digital Goods](#digital-goods)
    * [Comercios Agregadores](#comercios-agregadores)
    * [Split de Transacciones](#split-de-transacciones)
      * [Monto Fijo](#monto-fijo)
      * [Porcentaje](#porcentaje)	  
  * [GetAuthorizeAnswer] (#getauthorizeanswer) 
  * [Execute](#execute)
    * [Anulación](#anulación)
    * [Devolución Total](#devolución-total)
    * [Devolución Parcial](#devolución-parcial)
  * [GetByOperationId](#getbyoperationid)
  * [Tablas de referencia](#tablas-de-referencia)
    * [Códigos de Medios de Pago](#códigos-de-medios-de-pago)
    * [Códigos de Estado](#códigos-de-estado)
    * [Provincias](#provincias)
 
 
## Instalación
Se debe descargar la última versión del SDK desde el botón Download ZIP, branch master.		
Una vez descargado y descomprimido, debe incluirse al proyecto.		
<br />		

[Volver al inicio](#decidir-sdk-C#)

## Manual de Integración

Se encuentra disponible en Gitbook el **[Manual de Integración Decidir] (https://www.gitbook.com/book/decidir/documentacion/details)** para su consulta online o descarga, donde se detalla el proceso de integración. En el mismo se explican los servicios y operaciones disponibles, con ejemplos de requerimientos y respuestas, aquí se ejemplificará la forma de llamar a los distintos servicios usando la presente SDK.

[Volver al inicio](#decidir-sdk-C#)

## Generalidades
La versión implementada de la SDK, esta testeada para versiones desde .net 4.5.1 C#.
Instanciación de la clase 'Decidir'
La misma recibe como parámetros el Header HTTP provisto por Decidir para el comercio y un numero entero que representa el Endpoint en el que se realizaran las operaciones.

```C#
	using Decidir_SDK;
	/*
	....
	*/
	
		int endpoint = Decidir.sandbox;//Developer sandbox
		//int endpoint = Decidir.production; //produccion
		decidir = new Decidir(endpoint, getHeaders());
	}
	
	public static Dictionary<string, string> getHeaders()
        {
            var headers = new Dictionary<String, String>();
            headers.Add("Authorization", authorization);
            //Add here aditional HTTP Headers
            return headers;
        }
		
```

[Volver al inicio](#decidir-sdk-C#)

## SendAuthorizeRequest

La operación SendAuthorizeRequest que forma parte del servicio Authorize, envía el requerimiento inical de autorización para comenzar con el ciclo de pago de la transacción, debe llamarse de la siguiente manera:
Primero se debe inicializar el conector.
```C#
	decidir.initAuthorize();
```
Luego Crear los datos a enviar:
```C#
	using Decidir_SDK.RequestData;
	/*
	...
	*/

	private static SendAuthorizeRequestData initSendAuthorizeRequestData() {
		
		SendAuthorizeRequestData sar = new SendAuthorizeRequestData();
		
		sar.setEncodingMethod(ENCODINGMETHOD);
		sar.setMerchant(MERCHANT);
		sar.setSecurity(SECURITY);
		sar.setUrl_error("http://someurl.com/error/");
		sar.setUrl_ok("http://someurl.com/ok/");
		
		return sar;
	}
```

Luego se debe invocar al servicio pasándole como parámetro el objeto anteriormente creado

```C#
	SendAuthorizeRequestResponse sarResponse = decidir.sendAuthorizeRequest(initSendAuthorizeRequestData());
```
El mismo devolverá una instalcia de la clase `SendAuthorizeRequestResponse`

```C#
	Console.WriteLine("Status Code: " + sarResponse.getStatusCode());
	Console.WriteLine("StatusMessage: " + sarResponse.getStatusMessage());
	Console.WriteLine("PublicRequestKey: " + sarResponse.getPublicRequestKey());
	Console.WriteLine("RequestKey: " + sarResponse.getRequestKey());
	Console.WriteLine("URLRequest: " + sarResponse.getURLRequest());
```

[Volver al inicio](#decidir-sdk-C#)

### Medios de Pago

En la operación SendAuthorizeRequest deben enviarse datos adicionales dependiendo de los distintos medios de pago que se utilicen, para ello se proveen clases específicas para cada medio de pago que deben agregarse al objeto de datos.

[Volver al inicio](#decidir-sdk-C#)

#### Tarjetas de Crédito

Para utilizar tarjetas de crédito como medio de pago, se debe instanciar un objeto de la clase `TarjetaCredito`, con los siguientes parámetros

```C#
	using Decidir_SDK.MeidioDePago;
	/*
	...
	*/

	MedioDePago medioDePago = new TarjetaCredito("1"/* Mandatorio. Código del tipo de tarjeta a utilizar. [Tabla Medios de Pago] (#tablas-medios-de-pago)*/
													, "6"/*Mandatorio. Nro. de cuotas en los que se hará la operacion*/);
	//Se puede pasar como parametro adicional el BIN:
	MedioDePago medioDePago = new TarjetaCredito("1"/* Mandatorio. Código del tipo de tarjeta a utilizar. [Tabla Medios de Pago] (#tablas-medios-de-pago)*/
													, "6"/*Mandatorio. Nro. de cuotas en los que se hará la operacion*/
													, "450799");/*Opcional. Código BIN que identifica al emisor de la tarjeta de crédito. Permite al comercio operar con promociones bancarias.*/

```

Luego se debe incluir la información del medio de pago en el objeto de datos

```C#
	sar.setMedioPago(medioDePago);
		
```

[Volver al inicio](#decidir-sdk-C#)

#### Rapipago

Para utilizar Rapipago como medio de pago, se debe instanciar un objeto de la clase `Rapipago`, con los siguientes parámetros

```C#
	MedioDePago medioDePago = new Rapipago("26"/*Mandatorio. Código del tipo de tarjeta a utilizar. [Tabla Medios de Pago] (#tablas-medios-de-pago)*/
											, "10" /*Mandatorio. Son los días que existen entre el 1ra y 2da vencimiento de la factura. Poner "00" si la factura no tiene 2do vencimiento.*/
											, "12" /*Mandatorio. Son los días después del 1Âº vencimiento y hasta el que el cliente puede pagar la factura por Rapipago.*/
											, "22.00" /*Mandatorio. Recargo por vencimiento del plazo. Es un monto (no un porcentaje).*/
											, "1601010" /*Mandatorio. Fecha de vencimiento para el pago del cupón. Formato AAMMDD*/
											, "12345678"/*Mandatorio. Código de cliente provisto por Rapipago al momento de habilitar el comercio.*/
											);
									
```

Luego se debe incluir la información del medio de pago en el objeto de datos
```C#
	sar.setMedioPago(medioDePago);		
```
}
[Volver al inicio](#decidir-sdk-C#)

#### Pago Fácil

Para utilizar Pago Fácil como medio de pago, se debe instanciar un objeto de la clase `PagoFacil`, con los siguientes parámetros

```C#
	MedioDePago medioDePago = PagoFacil("26"
										, "2500" /*Mandatorio. Se debe enviar el monto toal para el segundo vencimiento.*/
										, "1601010"/*Mandatorio. Fecha de vencimiento para el pago del cupón. Formato AAMMDD*/
										, "1601010"/*Mandatorio. Fecha del segundo vencimiento para el pago del cupón. Formato AAMMDD*/
										);
```

[Volver al inicio](#decidir-sdk-C#)

#### Pago mis Cuentas

Para utilizar Pago Mis Cuentas como medio de pago, se debe instanciar un objeto de la clase `PagoMisCuentas`, con los siguientes parámetros

```C#
	MedioDePago medioDePago = PagoMisCuentas("26", "1601010" /*Mandatorio. Fecha y hora de vencimiento de la factura. En formato DDMMYY HHMM. Puede omitirse las "horas" y "minutos", informando solo la fecha con formato DDMMYY*/ );											
```

[Volver al inicio](#decidir-sdk-C#)

### Integración con Cybersource

Para utilizar el Servicio de Control de Fraude Cybersource, en la operación SendAuthorizeRequest, deben enviarse datos adicionales sobre la operación de compra que se quiere realizar.
Se han definido cinco verticales de negocio que requieren parámetros específicos, así como también parámetros comunes a todas las verticales.

[Volver al inicio](#decidir-sdk-C#)

#### Parámetros Comunes

Los parámetros comunes a todas las verticales deben enviarse junto con los datos específicos de cada uno. A continuación, describiremos los párametros comúnes que se deberan agregar a los datos de cada vertical al momento de instanciar la clase correspondiente.

```C#

	CyberSourceData fcd = new CyberSourceData();

	fcd.add(CyberSourceData.CSBTCITY, "Villa General Belgrano"); //Ciudad de facturación, MANDATORIO.
	fcd.add(CyberSourceData.CSBTCOUNTRY, "AR"); //País de facturación. MANDATORIO. Código ISO. (http://apps.cybersource.com/library/documentation/sbc/quickref/countries_alpha_list.pdf)
	fcd.add(CyberSourceData.CSBTCUSTOMERID, "453458"); //Identificador del usuario al que se le emite la factura. MANDATORIO. No puede contener un correo electrónico
	fcd.add(CyberSourceData.CSBTEMAIL, "decidir@hotmail.com"); //Mail del usuario al que se le emite la factura. MANDATORIO.
	fcd.add(CyberSourceData.CSBTFIRSTNAME, "Juan"); //Nombre del usuario al que se le emite la factura. MANDATORIO.
	fcd.add(CyberSourceData.CSBTLASTNAME, "Perez"); //Apellido del usuario al que se le emite la factura. MANDATORIO.
	fcd.add(CyberSourceData.CSBTIPADDRESS, "194.0.0.4"); //IP de la PC del comprador. MANDATORIO.
	fcd.add(CyberSourceData.CSBTPHONENUMBER, "541160913988"); //Teléfono del usuario al que se le emite la factura. No utilizar guiones, puntos o espacios. Incluir código de país. MANDATORIO.
	fcd.add(CyberSourceData.CSBTPOSTALCODE, "1010"); //Código Postal de la dirección de facturación. MANDATORIO.
	fcd.add(CyberSourceData.CSBTSTATE, "B"); //Provincia de la dirección de facturación. MANDATORIO. Ver tabla anexa de provincias.
	fcd.add(CyberSourceData.CSBTSTREET1, "Cerrito 740"); //Domicilio de facturación (calle y nro). MANDATORIO.
	fcd.add(CyberSourceData.CSBTSTREET2, "Piso 8"); //Complemento del domicilio. (piso, departamento). NO MANDATORIO. 
	fcd.add(CyberSourceData.CSPTCURRENCY, "ARS"); ////Moneda. MANDATORIO.
	fcd.add(CyberSourceData.CSPTGRANDTOTALAMOUNT, "125.38"); //Con decimales opcional usando el puntos como separador de decimales. No se permiten comas, ni como separador de miles ni como separador de decimales. MANDATORIO. (Ejemplos:$125,38-> 125.38 $12-> 12 o 12.00)
	fcd.add(CyberSourceData.device_fingerprint, "dj94utjg93"); // Device Fingerprint Id. MANDATORIO.
	fcd.add(CyberSourceData.CSMDD6, "Mobile"); // Canal de venta. NO MANDATORIO. (Valores posibles: Web, Mobile, Telefonica)
	fcd.add(CyberSourceData.CSMDD7, ""); // Fecha registro comprador(num Dias). NO MANDATORIO.
	fcd.add(CyberSourceData.CSMDD8, "Y"); //Usuario Guest? (Y/N). En caso de ser Y, el campo CSMDD9 no deberá enviarse. NO MANDATORIO.
	fcd.add(CyberSourceData.CSMDD9, ""); //Customer password Hash: criptograma asociado al password del comprador final. NO MANDATORIO.
	fcd.add(CyberSourceData.CSMDD10, ""); //Histórica de compras del comprador (Num transacciones). NO MANDATORIO.
	fcd.add(CyberSourceData.CSMDD11, ""); //Customer Cell Phone. NO MANDATORIO.
```
Para incorporar estos datos en el requerimiento inicial:
```C#
	sar.setCyberSourceData(fcd);
```

[Volver al inicio](#decidir-sdk-C#)

#### Retail

Los siguientes parámetros se deben enviar específicamente para la vertical Retail. Además se deben enviar datos específicos de cada producto involucrado en la transacción.

```C#

	CyberSourceRetail fc = new CyberSourceRetail();
		
	fc.add(CyberSourceRetail.CSSTCITY, "Rosario"); //Ciudad de envío de la orden. MANDATORIO
	fc.add(CyberSourceRetail.CSSTCOUNTRY, "AR"); //País de envío de la orden. MANDATORIO.
	fc.add(CyberSourceRetail.CSSTEMAIL, "mail@someurl.com"); //Mail del destinatario, MANDATORIO.
	fc.add(CyberSourceRetail.CSSTFIRSTNAME, "Jose"); //Nombre del destinatario. MANDATORIO.
	fc.add(CyberSourceRetail.CSSTLASTNAME, "Perez"); //Apellido del destinatario. MANDATORIO.
	fc.add(CyberSourceRetail.CSSTPHONENUMBER, "541155893737"); //Número de teléfono del destinatario. MANDATORIO.
	fc.add(CyberSourceRetail.CSSTPOSTALCODE, "1414"); //Código postal del domicilio de envío. MANDATORIO.
	fc.add(CyberSourceRetail.CSSTSTATE, "D"); //Provincia de envío. MANDATORIO. Son de 1 caracter
	fc.add(CyberSourceRetail.CSSTSTREET1, "San Martin 123"); //Domicilio de envío. MANDATORIO.
	fc.add(CyberSourceRetail.CSSTSTREET2, "San Luis"); //Localidad de envío. NO MANDATORIO.
	
	fc.add(CyberSourceRetail.CSMDD12, value); //Shipping DeadLine (Num Dias). NO MADATORIO.
	fc.add(CyberSourceRetail.CSMDD13, value); //Método de Despacho. NO MANDATORIO.
	fc.add(CyberSourceRetail.CSMDD14, value); //Customer requires Tax Bill ? (Y/N). NO MANDATORIO.
	fc.add(CyberSourceRetail.CSMDD15, value); //Customer Loyality Number. NO MANDATORIO.
	fc.add(CyberSourceRetail.CSMDD16, value); //Promotional / Coupon Code. NO MANDATORIO.
	
	fc.add(CyberSourceRetail.CSITPRODUCTCODE, "electronic_good"); //Código de producto. MANDATORIO. Valores posibles(adult_content;coupon;default;electronic_good;electronic_software;gift_certificate;handling_only;service;shipping_and_handling;shipping_only;subscription)
	fc.add(CyberSourceRetail.CSITPRODUCTDESCRIPTION, "Some Product Description"); //Descripción del producto. MANDATORIO.
	fc.add(CyberSourceRetail.CSITPRODUCTNAME, "Product Name"); //Nombre del producto. MANDATORIO.
	fc.add(CyberSourceRetail.CSITPRODUCTSKU, "PRDSKU123"); //Código identificador del producto. MANDATORIO.
	fc.add(CyberSourceRetail.CSITQUANTITY, "1"); //Cantidad del producto. MANDATORIO.
	fc.add(CyberSourceRetail.CSITTOTALAMOUNT, "120.00"); //CSITTOTALAMOUNT=CSITUNITPRICE*CSITQUANTITY "999999[.CC]" Con decimales opcional usando el puntos como separador de decimales. No se permiten comas, ni como separador de miles ni como separador de decimales. MANDATORIO.
	fc.add(CyberSourceRetail.CSITUNITPRICE, "120.00"); //Formato Idem CSITTOTALAMOUNT. MANDATORIO
	
		
```

Para incorporar estos datos en el requerimiento inicial:
```C#
	sar.setCyberSourceVertical(fc);
```

[Volver al inicio](#decidir-sdk-C#)

#### Travel

Los siguientes parámetros se deben enviar específicamente para la vertical Travel. Además se deben enviar datos específicos de cada pasajero involucrado en la transacción.

```C#
	CyberSourceTravel fc = new CyberSourceTravel();
	fc.add(CyberSourceTravel.CSADNUMBEROFPASSENGERS, "4"); //Cantidad total de pasajeros. MANDATORIO.
	fc.add(CyberSourceTravel.CSDMCOMPLETEROUTE, "JFK-SFO:SFO-LAX"); //Ruta completa del viaje, ORIG1-DEST1[:ORIG2-DEST2...:ORIGn-DESTn]. MANDATORIO.
	fc.add(CyberSourceTravel.CSDMDEPARTUREDATETIME, "2011-03-20 11:30pm GMT"); /* Fecha y hora del primer tramo del viaje. Utilizar GMT.
									Formato: yyyy-MM-dd hh:mma z donde: 
									hh = hora en formato 12-horas
									a = am o pm
									z = huso horario del vuelo de salida. Por ejemplo: Si la compaÃ±ía tiene su sede en la ciudad de A, pero el vuelo sale de la ciudad B, z es el horario de la ciudad B al momento de la salida
									MANDATORIO */
	fc.add(CyberSourceTravel.CSDMJOURNEYTYPEY, "round trip"); //Tipo de viaje. valores posibles: round trip o one way. MANDATORIO.
	
	fc.add(CyberSourceTravel.CSMDD17, "AWHWNV"); //Código de Reserva (PNR). MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD18, "N"); //3rd Party Booking? (Y/N). MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD19, value); //Departure City. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD20, value); //Final Destination City. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD21, value); //International Flight. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD22, value); //Frequent Flyer Number. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD23, value); //Class of Service. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD24, value); //Day of week of Flight. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD25, value); //Week of year of Flight. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD26, value); //Airline Code. NO MANDATORIO.
	fc.add(CyberSourceTravel.CSMDD27, value); //Code Share. NO MANDATORIO.
	
	fc.add(CyberSourceTravel.CSITPASSENGEREMAIL, "jperez@hotmail.com"); //Email del pasajero. MANDATORIO
	fc.add(CyberSourceTravel.CSITPASSENGERFIRSTNAME, "Jose"); //Nombre del pasajero. MANDATORIO.
	fc.add(CyberSourceTravel.CSITPASSENGERLASTNAME, "Perez"); //Apellido del pasajero. MANDATORIO.
	fc.add(CyberSourceTravel.CSITPASSENGERID, "21457547"); //Número de pasaporte. NO MANDATORIO.	
	fc.add(CyberSourceTravel.CSITPASSENGERPHONE, "541160913988"); //Número de teléfono del pasajero. MANDATORIO.
	fc.add(CyberSourceTravel.CSITPASSENGERSTATUS, "gold"); //Clasificación del pasajero dentro de la empresa. MANDATORIO.
	fc.add(CyberSourceTravel.CSITPASSENGERTYPE, "INF"); //Tipo de pasajero asociado al precio del pasaje. MANDATORIO.(ADT: Adult,CNN: Child,INF: Infant,YTH: Youth,STU: Student,SCR: Senior Citizen,MIL: Military)

```

Para incorporar estos datos en el requerimiento inicial:

```C#
	sar.setCyberSourceVertical(fc);
```

[Volver al inicio](#decidir-sdk-C#)

#### Ticketing

Los siguientes parámetros se deben enviar específicamente para la vertical Ticketing. Además se deben enviar datos específicos de cada producto involucrado en la transacción.

```C#

	CyberSourceTicketing fc = new CyberSourceTicketing();
	
	fc.add(CyberSourceTicketing.CSMDD33, "15"); //Número de días en los que se desarrollara el evento. MANDATORIO
	fc.add(CyberSourceTicketing.CSMDD34, "Email"); //Tipo de envío. MANDATORIO. Valores posibles: Pick up, Email, Smartphone, Other
	
	fc.add(CyberSourceTicketing.CSITPRODUCTCODE, "electronic_good"); //Código de producto. MANDATORIO. Valores posibles(adult_content;coupon;default;electronic_good;electronic_software;gift_certificate;handling_only;service;shipping_and_handling;shipping_only;subscription)
	fc.add(CyberSourceTicketing.CSITPRODUCTDESCRIPTION, "Product Description"); //Descripción del producto. MANDATORIO.
	fc.add(CyberSourceTicketing.CSITPRODUCTNAME, "Product Name"); //Nombre del producto. MANDATORIO.
	fc.add(CyberSourceTicketing.CSITPRODUCTSKU, "PRDSKU987"); //Código identificador del producto. MANDATORIO.
	fc.add(CyberSourceTicketing.CSITQUANTITY, "1"); //Cantidad del producto. MANDATORIO.
	fc.add(CyberSourceTicketing.CSITTOTALAMOUNT, "10.00"); //CSITTOTALAMOUNT=CSITUNITPRICE*CSITQUANTITY "999999[.CC]" Con decimales opcional usando el puntos como separador de decimales. No se permiten comas, ni como separador de miles ni como separador de decimales. MANDATORIO.
	fc.add(CyberSourceTicketing.CSITUNITPRICE, "10.00"); //Formato Idem CSITTOTALAMOUNT. MANDATORIO

```

Para incorporar estos datos en el requerimiento inicial:
```C#
	sar.setCyberSourceVertical(fc);
```

[Volver al inicio](#decidir-sdk-C#)

#### Services

Los siguientes parámetros se deben enviar específicamente para la vertical Services. Además se deben enviar datos específicos de cada producto involucrado en la transacción.

```C#
	CyberSourceServicios fc = new CyberSourceServicios();
	
	fc.add(CyberSourceServicios.CSMDD28, "Gas"); //Tipo de Servicio. MANDATORIO. Valores posibles: Luz, Gas, Telefono, Agua, TV, Cable, Internet, Impuestos.
	fc.add(CyberSourceServicios.CSMDD29, value); //Referencia de pago del servicio 1. NO MANDATORIO.
	fc.add(CyberSourceServicios.CSMDD30, value); //Referencia de pago del servicio 2. NO MANDATORIO.
	fc.add(CyberSourceServicios.CSMDD31, value); //Referencia de pago del servicio 3. NO MANDATORIO.
	
	
	fc.add(CyberSourceServicios.CSITPRODUCTCODE, "electronic_good"); //Código de producto. MANDATORIO. Valores posibles(adult_content;coupon;default;electronic_good;electronic_software;gift_certificate;handling_only;service;shipping_and_handling;shipping_only;subscription)
	fc.add(CyberSourceServicios.CSITPRODUCTDESCRIPTION, "PRD Description"); //Descripción del producto. MANDATORIO.
	fc.add(CyberSourceServicios.CSITPRODUCTNAME, "PRD Name"); //Nombre del producto. MANDATORIO.
	fc.add(CyberSourceServicios.CSITPRODUCTSKU, "PRDSKU741"); //Código identificador del producto. MANDATORIO.
	fc.add(CyberSourceServicios.CSITQUANTITY, "1"); //Cantidad del producto. MANDATORIO.
	fc.add(CyberSourceServicios.CSITTOTALAMOUNT, "10.00"); //CSITTOTALAMOUNT=CSITUNITPRICE*CSITQUANTITY "999999[.CC]" Con decimales opcional usando el puntos como separador de decimales. No se permiten comas, ni como separador de miles ni como separador de decimales. MANDATORIO.
	fc.add(CyberSourceServicios.CSITUNITPRICE, "10.00"); //Formato Idem CSITTOTALAMOUNT. MANDATORIO
```

Para incorporar estos datos en el requerimiento inicial:
```C#
	sar.setCyberSourceVertical(fc);
```

[Volver al inicio](#decidir-sdk-C#)

#### Digital Goods

Los siguientes parámetros se deben enviar específicamente para la vertical Digital Goods. Además se deben enviar datos específicos de cada producto involucrado en la transacción.

```C#
	CyberSourceBienesDigitales fc = new CyberSourceBienesDigitales();
	
	fc.add(CyberSourceBienesDigitales.CSMDD31, "Email"); //Tipo de delivery. MANDATORIO. Valores posibles: WEB Session, Email, SmartPhone
	
	fc.add(CyberSourceBienesDigitales.CSITPRODUCTCODE, "electronic_good"); //Código de producto. MANDATORIO. Valores posibles(adult_content;coupon;default;electronic_good;electronic_software;gift_certificate;handling_only;service;shipping_and_handling;shipping_only;subscription)
	fc.add(CyberSourceBienesDigitales.CSITPRODUCTDESCRIPTION, "PRD Description"); //Descripción del producto. MANDATORIO.
	fc.add(CyberSourceBienesDigitales.CSITPRODUCTNAME, "PRD Name"); //Nombre del producto. MANDATORIO.
	fc.add(CyberSourceBienesDigitales.CSITPRODUCTSKU, "PRDSKU741"); //Código identificador del producto. MANDATORIO.
	fc.add(CyberSourceBienesDigitales.CSITQUANTITY, "1"); //Cantidad del producto. MANDATORIO.
	fc.add(CyberSourceBienesDigitales.CSITTOTALAMOUNT, "10.00"); //CSITTOTALAMOUNT=CSITUNITPRICE*CSITQUANTITY "999999[.CC]" Con decimales opcional usando el puntos como separador de decimales. No se permiten comas, ni como separador de miles ni como separador de decimales. MANDATORIO.
	fc.add(CyberSourceBienesDigitales.CSITUNITPRICE, "10.00"); //Formato Idem CSITTOTALAMOUNT. MANDATORIO

```

Para incorporar estos datos en el requerimiento inicial:
```C#
	sar.setCyberSourceVertical(fc);
```
[Volver al inicio](#decidir-sdk-C#)

### Comercios Agregadores

Se debe añadir al requerimiento inicial del SendAuthorizeRequest los siguientes datos adicionales de VISA para comercios agregadores.

Debe instanciarse un objeto de la clase `ComerciosAgregadores` con los parámetros específicos.

```C#
	ComerciosAgregadores c = new ComerciosAgregadores();
	
	c.add(ComerciosAgregadores.acodcanal, ""); //Código de canal. Alfanumérico de 3 caracteres.
	c.add(ComerciosAgregadores.acodgeografico, ""); //Código geográfico del vendedor. Alfanumérico de 5 caracteres.
	c.add(ComerciosAgregadores.acodpostal, "H3509XAP"); //Código postal. Alfanumérico de 8 caracteres.
	c.add(ComerciosAgregadores.adocumento, "2325xxxxxx9"); //Número de CUIT, CUIL o Número Único(en el último caso se debe completar con ceros a la izquierda)
	c.add(ComerciosAgregadores.adomiciliocomercio, "Salta"); //Dirección del comercio o vendedor. Alfanumérico 20 caracteres.
	c.add(ComerciosAgregadores.afactdevol, "c0000234320"); // Número de factura de anulación/devolución,
	c.add(ComerciosAgregadores.afactpagar, "c0000234321"); //Número de factura a pagar. Alfanumérico de 12 caracteres.
	c.add(ComerciosAgregadores.aindicador, "0"); //Indicador del tipo de documento. Numérico, 1 dígito. Valores posibles(0:cuit, 1:cuil, 2:número único).
	c.add(ComerciosAgregadores.anombrecom, "jorge/Rufalo"); //Nombre del comercio o nombre y apellido del vendedor. Alfanumérico 20 caracteres. en el caso de nombre y apellido debe estar separado por "/".
	c.add(ComerciosAgregadores.anropuerta, "153"); //Número de puerta. Alfanumérico 6 caracteres
	c.add(ComerciosAgregadores.arubro, ""); //Código de actividad (rubro). Alfanumérico de 5 caracteres.
	
```

Luego se debe incluir esta información en el objeto de datos

```C#
	sar.setComerciosAgregadores(c);
```

[Volver al inicio](#decidir-sdk-C#)

### Split de Transacciones

Se debe añadir al requerimiento inicial del SendAuthorizeRequest los siguientes datos adicionales para realizar el Split de Transacciones.

[Volver al inicio](#decidir-sdk-C#)

#### Monto Fijo

Debe instanciarse un objeto de la clase `MontoFijo` con los parámetros específicos.

```C#
	SplitData s = new MontoFijo();
		
	s.add(MontoFijo.cuotasdist, "01#06#24"); //cantidad de cuotas para cada subcomercio. Decimal de 2 dígitos.
	s.add(MontoFijo.idmodalidad, "S"); // indica si la transacción es distribuida. (S= transacción distribuida; N y null = no distribida)
	s.add(MontoFijo.impdist, "123.4#12#12.05"); //Importe de cada una de las substransacciones. Los importes deben postearse separados por "#".
	s.add(MontoFijo.nrocomercio, "12345678"); //Número de comercio padre provisto por SPS DECIDIR. Alfanumérico de 8 caracteres.
	s.add(MontoFijo.sitedist, "00100511#0234803245#00230031"); //Número de comercio de cada uno de los subcomercios asociados al comercio padre
	
```

Luego se debe incluir esta información en el objeto de datos

```C#
	sar.setSplit(s);
```

[Volver al inicio](#decidir-sdk-C#)

#### Porcentaje

Debe instanciarse un objeto de la clase `Porcentaje` con los parámetros específicos.

```C#
	SplitData s = new Porcentaje();
	s.add(Porcentaje.idmodalidad, "S");// indica si la transacción es distribuida. (S= transacción distribuida; N y null = no distribida)

```

Luego se debe incluir esta información en el objeto de datos

```C#
	sar.setSplit(s);
```

[Volver al inicio](#decidir-sdk-C#)

## GetAuthorizeAnswer

La operación GetAuthorizeAnswer que forma parte del servicio Authorize, debe llamarse de la siguiente manera:

```C#

	private static GetAuthorizeAnswerData initGetAuthorizeAnswerData() {
		GetAuthorizeAnswerData gaa = new GetAuthorizeAnswerData();
		gaa.setMerchant("22067736");// Mandatorio. Nro. de Comercio provisto por Decidir
		gaa.setSecurity("RV82RVHO5T0O5CZUUTX2FLHU");// Mandatorio. Código provisto por Decidir
		gaa.setRequestKey("cdf96aaf-dd1c-195b-eeee-130a3df96110"); // Mandatorio. Private Request Key devuelta por el requerimiento SendAuthorizeRequest
		gaa.setAnswerKey("77215fe6-f9d5-f1c2-372b-c0065e0c4429"); // Mandatorio. Answer Key devuelta por la función callback del formulario de pago.
		return gaa;
	}
	
```

Luego se debe invocar al servicio pasándole como parámetro el objeto anteriormente creado

```C#
	GetAuthorizeAnswerResponse gaaResponse = decidir.getAuthorizeAnswer(initGetAuthorizeAnswerData());
		
```
El mismo devolverá una instalcia de la clase `GetAuthorizeAnswerResponse`

```C#
	Console.WriteLine("Status Code: " + gaaResponse.getStatusCode());
	Console.WriteLine("AuthorizationKey: " + gaaResponse.getAuthorizationKey());
	Console.WriteLine("EncodingMethod: " + gaaResponse.getEncodingMethod());
	Console.WriteLine("StatusMessage: " + gaaResponse.getStatusMessage());
	Console.WriteLine("Payload: " + gaaResponse.getPayload());
```

[Volver al inicio](#decidir-sdk-C#)

## Execute

La operación Execute que forma parte del servicio Authorize, permite realizar distintas operaciones sobre una transacción, las cuales se describen a continuación.

[Volver al inicio](#decidir-sdk-C#)

### Anulación
Para realizar la anulación de una transacción, debe crearse una instancia de la clase `ExecuteAnulacion`, con lo parámetros de la solicitud

```C#
	using Decidir_SDK.RequestData.Execute;
	/*
	....
	*/

	ExecuteData ex = new ExecuteAnulacion("22067736" /*Mandatorio. Nro. de Comercio provisto por Decidir*/
										, "123456" /*Mandatorio. Nro. de Operación*/
										, SECURITY /*Mandatorio. Código provisto por Decidir*/ 
										);
```

Luego se debe invocar al servicio pasándole como parámetro el objeto anteriormente creado

```C#
	ExecuteResponse exResponse = decidir.execute(ex);
```
El mismo devolverá una instalcia de la clase `ExecuteResponse`

```C#
	Console.WriteLine("Status Code: " + exResponse.getStatusCode());
	Console.WriteLine("StatusMessage: " + exResponse.getStatusMessage());
	Console.WriteLine("AuthorizationKey: " + exResponse.getAuthorizationKey());
	Console.WriteLine("EncodingMethod: " + exResponse.getEncoding());
	Console.WriteLine("Payload: " + exResponse.getPayload());
	
```

[Volver al inicio](#decidir-sdk-C#)

### Devolución Total
Para realizar la devolución de una transacción, debe crearse una instancia de la clase `Decidir\Authorize\Execute\Devolucion\Total`, con lo parámetros de la solicitud

```C#
	ExecuteData ex = new ExecuteDevolucion("22067736" /*Mandatorio. Nro. de Comercio provisto por Decidir*/
										, "123456" /*Mandatorio. Nro. de Operación*/
										, "RV82RVHO5T0O5CZUUTX2FLHU" /*Mandatorio. Código provisto por Decidir*/
										);									
```

Luego se debe invocar al servicio pasándole como parámetro el objeto anteriormente creado

```C#
	ExecuteResponse exResponse = decidir.execute(ex);
```

El mismo devolverá una instalcia de la clase `Decidir\Authorize\Execute\Response`

```C#
	Console.WriteLine("Status Code: " + exResponse.getStatusCode());
	Console.WriteLine("StatusMessage: " + exResponse.getStatusMessage());
	Console.WriteLine("AuthorizationKey: " + exResponse.getAuthorizationKey());
	Console.WriteLine("EncodingMethod: " + exResponse.getEncoding());
	Console.WriteLine("Payload: " + exResponse.getPayload());	
```

[Volver al inicio](#decidir-sdk-C#)

### Devolución Parcial
Para realizar la devolución parcial de una transacción, debe crearse una instancia de la clase `Decidir\Authorize\Execute\Devolucion\Parcial`, con lo parámetros de la solicitud

```php
	ExecuteData ex = new ExecuteDevolucion("22067736" /*Mandatorio. Nro. de Comercio provisto por Decidir*/
										, "123456" /*Mandatorio. Nro. de Operación.*/ 
										, "10.00" /*Mandatorio. Monto a devolver*/
										, "RV82RVHO5T0O5CZUUTX2FLHU"/*Mandatorio. Código provisto por Decidir*/
										);
```

Luego se debe invocar al servicio pasándole como parámetro el objeto anteriormente creado

```C#
	ExecuteResponse exResponse = decidir.execute(ex);
```

El mismo devolverá una instalcia de la clase `Decidir\Authorize\Execute\Response`

```C#
	Console.WriteLine("Status Code: " + exResponse.getStatusCode());
	Console.WriteLine("StatusMessage: " + exResponse.getStatusMessage());
	Console.WriteLine("AuthorizationKey: " + exResponse.getAuthorizationKey());
	Console.WriteLine("EncodingMethod: " + exResponse.getEncoding());
	Console.WriteLine("Payload: " + exResponse.getPayload());	
```

[Volver al inicio](#decidir-sdk-C#)

## GetByOperationId

La operación GetByOperationId que forma parte del servicio Operation, permite consultar el último estado de una transacción de forma online, debe llamarse de la siguiente manera:
Primero se debe inicializar el conector pasando como parametro la ubicación del WSDL(incluida en la SDK)
```C#
	decidir.initOperation();
```
Luego se debe instanciar la clase GetByOperationData de la siguiente manera:
```C#
	GetByOperationData data = new GetByOperationData(MERCHANT, "123456");
```

Luego se debe invocar al servicio pasándole como parámetro el objeto anteriormente creado

```C#
	object[] ops = decidir.get(data);
```
El mismo devolverá una arreglos de objetos, dentro se encuentran los datos de la transacción

[Volver al inicio](#decidir-sdk-C#)

## Tablas de Referencia

### Códigos de Medios de pago

| MEDIO DE PAGO | NOMBRE |
----------------|--------
| 1 | VISA |
| 6 | AMEX |
| 8 | DINERS |
| 15 | MASTERCARD |
| 20 | MASTERCARD TEST |
| 23 | TARJETA SHOPPING |
| 24 | TARJETA NARANJA |
| 25 | PAGO FACIL |
| 26 | RAPIPAGO |
| 27 | CABAL |
| 29 | ITALCRED |
| 30 | ARGENCARD |
| 31 | VISA DEBITO |
| 34 | COOPEPLUS |
| 36 | ARCASH |
| 37 | NEXO |
| 38 | CREDIMAS |
| 39 | NEVADA |
| 41 | PAGOMISCUENTAS |
| 42 | NATIVA |
| 43 | TARJETA MAS/CENCOSUD |
| 44 | CETELEM |
| 45 | NACIONPYMES |
| 46 | PAYSAFECARD |
| 47 | MONEDERO ONLINE |
| 48 | CAJA DE PAGOS |

[Volver al inicio](#decidir-sdk-C#)

### Códigos de Estado

| IdEstado | Descripción |
|----------|-------------|
| 1 | Ingresada | 
| 2 | A procesar | 
| 3 | Procesada | 
| 4 | Autorizada | 
| 5 | Rechazada | 
| 6 | Acreditada | 
| 7 | Anulada | 
| 8 | Anulación Confirmada | 
| 9 | Devuelta | 
| 10 | Devolución Confirmada | 
| 11 | Pre autorizada | 
| 12 | Vencida | 
| 13 | Acreditación no cerrada | 
| 14 | Autorizada * | 
| 15 | A reversar | 
| 16 | A registar en Visa | 
| 17 | Validación iniciada en Visa | 
| 18 | Enviada a validar en Visa | 
| 19 | Validada OK en Visa | 
| 20 | Recibido desde Visa | 
| 21 | Validada no OK en Visa | 
| 22 | Factura generada | 
| 23 | Factura no generada | 
| 24 | Rechazada no autenticada | 
| 25 | Rechazada datos inválidos | 
| 28 | A registrar en IdValidador | 
| 29 | Enviada a IdValidador | 
| 32 | Rechazada no validada | 
| 38 | Timeout de compra | 
| 50 | Ingresada Distribuida | 
| 51 | Rechazada por grupo | 
| 52 | Anulada por grupo | 

[Volver al inicio](#decidir-sdk-C#)

### Provincias

| Provincia | Código |
|----------|-------------|
| CABA | C | 
| Buenos Aires | B | 
| Catamarca | K | 
| Chaco | H | 
| Chubut | U | 
| Córdoba | X | 
| Corrientes | W | 
| Entre Ríos | R | 
| Formosa | P | 
| Jujuy | Y | 
| La Pampa | L | 
| La Rioja | F | 
| Mendoza | M | 
| Misiones | N | 
| Neuquén | Q | 
| Río Negro | R | 
| Salta | A | 
| San Juan | J | 
| San Luis | D | 
| Santa Cruz | Z | 
| Santa Fe | S | 
| Santiago del Estero | G | 
| Tierra del Fuego | V | 
| Tucumán | T | 	

[Volver al inicio](#decidir-sdk-C#)
# Banco de sangre

Aplicación para la gestión de un banco de sangre realizada con .NET Core (5.0)
<br></br>
Estas son las tecnologías utilizadas:

<table>
  <tr>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
  </tr>
  <tr>
    <td align="center">Lenguaje C#</td>
    <td align="center">EF Core</td>
    <td align="center">WPF</td>
    <td align="center">Bold Reports</td>
    <td align="center">Visual Studio</td>
  </tr>
  <tr>
    <td align="center"><img src="https://1.bp.blogspot.com/-gwHkzj-47wA/WBBlZVYIIvI/AAAAAAAAN6g/DVlI0B-TpP81Phrvk4E3Ud2YcgSeEU7BwCPcB/s1600/2p4i.png" width="55%" height="55%"></td>
    <td align="center"><img src="https://dagope.com/public/uploads/2018/11/efcore.png" width="110%" height="110%"></td>
    <td align="center"><img src="https://www.programandoamedianoche.com/wp-content/uploads/2009/09/develop-wpf-and-xaml-programs.jpg" width="100%" height="100%"></td>
    <td align="center"><img src="https://www.boldreports.com/wp-content/uploads/2019/08/bold-reports-logo.svg" width="800" height="100"></td>
    <td align="center"><img src="https://mteheran.files.wordpress.com/2017/12/visualstudio.png" width="80%" height="80%"></td>
  </tr>
  <tr>
    <td align="center">.NET Core</td>
    <td align="center">SQL Server</td>
    <td align="center">XAML Toolkit</td>
    <td align="center">Syncfusion WPF UI Controls</td>
    <td align="center">Mockaroo</td>
  </tr>
  <tr>
    <td align="center"><img src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/1024px-.NET_Core_Logo.svg.png" width="40%" height="40%"></td>
    <td align="center"><img src="https://www.dataprix.com/files/uploads/103image/logo_sqlserver.png" width="80%" height="80%"></td>
    <td align="center"><img src="https://lh3.googleusercontent.com/proxy/UDiRtaGJyklsHQeW5LZKcKKmxBSPHG1qHGhUpdhY_I7hPp4HFQbZcCe7PC6wZPeoXHXRYXaOMwUL7yNo3JjCG0C7yPPlQUBVsD0" width="80%" height="80%"></td>
    <td align="center"><img src="https://cdn.syncfusion.com/content/images/company-logos/Syncfusion_Logo_Image.png" width="80%" height="80%"></td>
    <td align="center"><img src="https://assets-global.website-files.com/6009f6f109d51e60b911ba53/606e2c19fbba751849f85f40_mockaroo-logo.png" width="90%" height="90%"></td>
  </tr>
</table>

La aplicación está dividida en 4 pestañas:

- Gestión de datos
- Reportes
- Dashboard
- Compatibilidad
<br></br>
### 1. Gestión de datos
Se gestionan tanto los datos de los donantes como de las donaciones que éstos han realizado. Aparte de contar con un CRUD, he implementado un sistema de búsqueda avanzado y un sistema de filtros especializado.

##### DONANTES
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_1.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_2.jpg" width="40%" height="40%">
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_3.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_4.jpg" width="40%" height="40%">
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_5.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_6.jpg" width="40%" height="40%">
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_7.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_8.jpg" width="40%" height="40%">

##### DONACIONES
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_Donacion_1.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_Donacion_2.jpg" width="40%" height="40%">
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_Donacion_3.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_Donacion_4.jpg" width="40%" height="40%">
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_Donacion_5.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_Donacion_6.jpg" width="40%" height="40%">
<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/GestionDatos_Donacion_7.jpg" width="40%" height="40%">

### 2. Reportes
Se pueden crear reportes tanto de los donantes como de las donaciones seleccionando los filtros deseados. Además, es posible exportar el documento en los siguientes formatos:

+ CSV
+ HTML
+ XML
+ PDF
+ DOC

<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/Reportes.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/Reportes_2.jpg" width="40%" height="40%">

### 3. Dashboard
Este apartado nos ofrece información visual tanto de las cantidades de sangre que quedan en el inventario, como de la cantidad de donantes regulares de los que dispone el centro.

<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/Dashborad_1.jpg" width="40%" height="40%"> <img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/Dashborad_2.jpg" width="40%" height="40%">

### 4. Compatibilidad
Se muestra la compatibilidad entre los diferentes tipos de sangre.

<img src="https://github.com/srepeto/ProyectoFinDeGrado_NetCore/blob/master/Capturas/Compatibilidad.jpg" width="40%" height="40%">

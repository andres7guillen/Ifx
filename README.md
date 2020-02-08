# IfxBackEnd
Api REST para la administracion de entidades, hecha en .net Core 2.2
El contexto de datos fue hecho con Entity framework 2.2, para crear la base de datos se debe modificar el connection string 
de nombre "IfxConnection",que esta en el archivo "appsettings.json" del proyecto del web Api,una vez modificado el connection
 string se debe abrir la consola de administrador de paquetes apuntando al proyecto de IfxData y una vez ahi ejecutar el comando
 "update-database -migration sistema_Logueo", despues la migracion "update-database -migration RenombrarAEntidades".

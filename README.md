<h1>
"# MiniServer" 
</h1>

Grupo Nº 

Integrantes:
    Brenda LOPEZ (brendakeilalopez@gmail.com)
    Cristian Mauro FABREGAT (cmfabregat@gmail.com)

Requisitos:
1. Debe poder atender un número indefinido de solicitudes en forma concurrente. 
2. Por defecto, deberá servir el archivo index.html, si la URL no especifica el archivo. 
3. La carpeta desde donde se servirán los archivos debe ser configurable desde un archivo de configuración externo. 
4. El puerto de escucha debe ser configurable desde un archivo de configuración externo. 
5. En caso de que el usuario haya solicitado un archivo inexistente, deberá devolver un 
código de error 404 y un documento personalizado indicando el error. 
6. Debe aceptar solicitudes de tipo GET y POST. En el caso de solicitudes POST, sólo deben loguearse los datos recibidos. 
7. Debe manejar parámetros de consulta desde la URL. En este caso, los parámetros solo deberán loguearse. 
8. Debe utilizar compresión de archivos para responder a las solicitudes. 
9. Los datos de todas las solicitudes deben loguearse en un archivo por día, incluyendo la IP de origen. 
10. Sólo deben usar sockets (directamente en la capa de transporte) y se deben parsear las solicitudes HTTP. No se debe utilizar ninguna herramienta adicional.

Para probarlo:
    http://127.0.0.1:8080

Para realizar pruebas
    curl -X GET http://localhost:8080/
    curl -X GET http://localhost:8080/index.html
    curl -X GET http://localhost:8080/cualquiercosa.html
    curl -X GET http://localhost:8080/param/test?debug=true
    curl -X POST http://localhost:8080/api/test?debug=true -d "nombre=Brenda&rol=dev"
    
Herramientas:
    Visual Studio 2022

Investigación
    https://chatgpt.com/share/6830e5e3-c66c-800e-aa49-f93ffcb5f0ed

---

Creo que falta:
8. TODO
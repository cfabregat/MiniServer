<body class="bg-gray-50 text-gray-900 min-h-screen py-8 px-4 sm:px-6 lg:px-8">
    <div class="max-w-4xl mx-auto bg-white shadow-lg rounded-lg p-6">
        <h1 class="text-4xl font-extrabold text-center text-blue-600 mb-8">MiniServer</h1>
        <section class="mb-8">
            <h2 class="text-2xl font-bold text-gray-800 mb-4 border-b-2 border-blue-500 pb-2">Información del Grupo</h2>
            <p class="text-lg text-gray-600 mb-4">Grupo Nº: <span class="font-semibold">Pendiente</span></p>
            <h3 class="text-xl font-semibold text-gray-700 mb-2">Integrantes:</h3>
            <ul class="list-disc pl-6">
                <li class="mb-2 text-gray-700">Brenda Lopez (<a href="mailto:brendakeilalopez@gmail.com" class="text-blue-500 hover:underline">brendakeilalopez@gmail.com</a>)</li>
                <li class="mb-2 text-gray-700">Cristian Mauro Fabregat (<a href="mailto:cmfabregat@gmail.com" class="text-blue-500 hover:underline">cmfabregat@gmail.com</a>)</li>
            </ul>
        </section>
        <section class="mb-8">
            <h2 class="text-2xl font-bold text-gray-800 mb-4 border-b-2 border-blue-500 pb-2">Requisitos</h2>
            <ul class="list-decimal pl-6">
                <li class="mb-2 text-gray-700">Debe poder atender un número indefinido de solicitudes en forma concurrente.</li>
                <li class="mb-2 text-gray-700">Por defecto, deberá servir el archivo <code>index.html</code>, si la URL no especifica el archivo.</li>
                <li class="mb-2 text-gray-700">La carpeta desde donde se servirán los archivos debe ser configurable desde un archivo de configuración externo.</li>
                <li class="mb-2 text-gray-700">El puerto de escucha debe ser configurable desde un archivo de configuración externo.</li>
                <li class="mb-2 text-gray-700">En caso de que el usuario haya solicitado un archivo inexistente, deberá devolver un código de error 404 y un documento personalizado indicando el error.</li>
                <li class="mb-2 text-gray-700">Debe aceptar solicitudes de tipo GET y POST. En el caso de solicitudes POST, solo deben loguearse los datos recibidos.</li>
                <li class="mb-2 text-gray-700">Debe manejar parámetros de consulta desde la URL. En este caso, los parámetros solo deberán loguearse.</li>
                <li class="mb-2 text-gray-700">Debe utilizar compresión de archivos para responder a las solicitudes. <span class="text-red-500 font-semibold">[TODO]</span></li>
                <li class="mb-2 text-gray-700">Los datos de todas las solicitudes deben loguearse en un archivo por día, incluyendo la IP de origen.</li>
                <li class="mb-2 text-gray-700">Solo deben usar sockets (directamente en la capa de transporte) y se deben parsear las solicitudes HTTP. No se debe utilizar ninguna herramienta adicional.</li>
            </ul>
        </section>
        <section class="mb-8">
            <h2 class="text-2xl font-bold text-gray-800 mb-4 border-b-2 border-blue-500 pb-2">Pruebas</h2>
            <p class="text-lg text-gray-600 mb-2">URL base para probar:</p>
            <p class="bg-gray-100 p-4 rounded-lg text-sm font-mono text-gray-800 overflow-x-auto"><a href="http://127.0.0.1:8080" class="text-blue-500 hover:underline">http://127.0.0.1:8080</a></p>
            <p class="text-lg text-gray-600 mb-2 mt-4">Comandos para pruebas con <code>curl</code>:</p>
            <div class="bg-gray-100 p-4 rounded-lg text-sm font-mono text-gray-800 overflow-x-auto">
                <p>curl -X GET http://localhost:8080/</p>
                <p>curl -X GET http://localhost:8080/index.html</p>
                <p>curl -X GET http://localhost:8080/cualquiercosa.html</p>
                <p>curl -X GET http://localhost:8080/param/test?debug=true</p>
                <p>curl -X POST http://localhost:8080/api/test?debug=true -d "nombre=Brenda&rol=dev"</p>
            </div>
        </section>
        <section class="mb-8">
            <h2 class="text-2xl font-bold text-gray-800 mb-4 border-b-2 border-blue-500 pb-2">Herramientas</h2>
            <p class="mb-2 text-gray-700">Visual Studio 2022</p>
        </section>
        <section class="mb-8">
            <h2 class="text-2xl font-bold text-gray-800 mb-4 border-b-2 border-blue-500 pb-2">Investigación</h2>
            <p class="mb-2 text-gray-700">Referencia: <a href="https://chatgpt.com/share/6830e5e3-c66c-800e-aa49-f93ffcb5f0ed" class="text-blue-500 hover:underline">ChatGPT</a></p>
        </section>
        <section>
            <h2 class="text-2xl font-bold text-gray-800 mb-4 border-b-2 border-blue-500 pb-2">Notas</h2>
            <p class="mb-2 text-gray-700 text-red-500 font-semibold">Todo probado.</p>
        </section>
    </div>
</body>

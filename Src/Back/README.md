# Para execução via docker

No diretório raiz do projeto `/Src/Back/` executar os seguintes comandos:

`docker build --force-rm -t backoffice-api .`

`docker run -p 8080:8080 backoffice-api`

Testar a aplicação pela url [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)

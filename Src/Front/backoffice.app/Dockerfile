# Usar uma imagem base oficial do Node.js
FROM node:16-alpine

# Definir o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiar package.json e yarn.lock (ou package-lock.json) para o diretório de trabalho
COPY package*.json ./

# Instalar as dependências
RUN npm install

# Copiar o restante do código da aplicação para o diretório de trabalho
COPY . .

# Construir a aplicação React
RUN npm run build

# Instalar o servidor HTTP estático para servir os arquivos construídos
RUN npm install -g serve

# Definir a porta que o contêiner irá expor
EXPOSE 3000

# Comando para rodar o servidor estático e servir a aplicação
CMD ["serve", "-s", "build", "-l", "3000"]

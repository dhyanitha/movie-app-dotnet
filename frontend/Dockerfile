#Base Image
FROM stefanscherer/node-windows
#Working directory
WORKDIR /app 
#Copy Package JSON
COPY package.json /app
#install dependencies
RUN npm install
#Copy rest of the code
COPY . /app
CMD npm start
FROM node:16.3.0 as build

WORKDIR /app

COPY ./Services/Web/React /app/

RUN npm install

ENV PATH /app/node_modules/.bin:$PATH

RUN envsubst < /app/src/config.json | tee /app/src/config.json

RUN npm run build

FROM nginx:alpine

WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

COPY --from=build /app/dist .
RUN rm /etc/nginx/conf.d/default.conf

COPY ./DevOps/Infrastructure/Docker/Recipe.Web.nginx.conf /etc/nginx/conf.d

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

#EntryPoint
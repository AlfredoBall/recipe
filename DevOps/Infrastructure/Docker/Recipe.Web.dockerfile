FROM node:16.3.0 as build

WORKDIR /app

COPY ./Services/Web/React/package.json package.json
COPY ./Services/Web/React/package-lock.json package-lock.json

RUN npm install

COPY ./Services/Web/React .

ENV NODE_PATH=/node_modules
ENV PATH=$PATH:/node_modules/.bin

RUN npm run build

FROM nginx:alpine

WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

COPY ./DevOps/Infrastructure/Docker/Recipe.Web.sh /usr/bin
COPY ./DevOps/Infrastructure/Docker/.env .
RUN chmod +x /usr/bin/Recipe.Web.sh

COPY --from=build /app/dist .

RUN rm /etc/nginx/conf.d/default.conf

COPY ./DevOps/Infrastructure/Docker/Recipe.Web.nginx.conf /etc/nginx/conf.d

RUN apk add --no-cache bash

EXPOSE 80

ENV JQ_VERSION=1.6
RUN wget --no-check-certificate https://github.com/stedolan/jq/releases/download/jq-${JQ_VERSION}/jq-linux64 -O /tmp/jq-linux64
RUN cp /tmp/jq-linux64 /usr/bin/jq
RUN chmod +x /usr/bin/jq

ENTRYPOINT ["/bin/bash", "-c", "/usr/bin/Recipe.Web.sh && nginx -g \"daemon off;\""]

# https://github.com/facebook/create-react-app/issues/2353#issuecomment-467145976 
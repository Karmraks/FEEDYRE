FROM node:20.10.0-alpine as build-env

WORKDIR /app

COPY . .
RUN npm install
RUN npm run build
FROM nginx:alpine
COPY --from=build-env /app/dist/feedyre/browser /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
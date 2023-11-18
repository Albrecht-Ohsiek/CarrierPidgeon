# Creating and starting up docker container
docker compose up -d

# If its not working due to a port conflict try
docker run --rm -it -p 8080:4000/tcp carrierpidgeon:latest
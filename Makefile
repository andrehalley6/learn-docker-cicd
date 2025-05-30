.PHONY: test run-local run-docker build docker-build docker-up docker-down

# Run unit tests
test:
	dotnet test

# Run app locally without docker
run-local:
	ASPNETCORE_URLS=http://localhost:5093 dotnet run --project LearnDockerCiCd.Api

# Build app and run docker-compose
docker-build:
	docker-compose build

docker-up:
	docker-compose up

docker-down:
	docker-compose down

# Build and run containerized app
run-docker: docker-build docker-up

# Clean (optional)
clean:
	dotnet clean
